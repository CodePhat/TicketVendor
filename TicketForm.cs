
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketVendorDemo
{
    public partial class TicketForm : Form
    {
        string connStr = "Data Source=.;Initial Catalog=LabDB;Integrated Security=True";

        public TicketForm()
        {
            InitializeComponent();
            LoadDestinations();
        }

        private void LoadDestinations()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM Destinations", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbDestination.Items.Add(new ComboBoxItem(reader["Name"].ToString(), reader["Id"].ToString()));
                }
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            var selected = cmbDestination.SelectedItem as ComboBoxItem;
            string cardNum = txtCard.Text;
            int destId = int.Parse(selected.Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand getPrice = new SqlCommand("SELECT Price FROM Destinations WHERE Id=@id", conn);
                getPrice.Parameters.AddWithValue("@id", destId);
                decimal price = (decimal)getPrice.ExecuteScalar();

                SqlCommand insertTxn = new SqlCommand(
                    "INSERT INTO Transactions (DestinationId, CardNumber, Amount) OUTPUT INSERTED.Id VALUES (@dest, @card, @amount)", conn);
                insertTxn.Parameters.AddWithValue("@dest", destId);
                insertTxn.Parameters.AddWithValue("@card", cardNum);
                insertTxn.Parameters.AddWithValue("@amount", price);
                int txnId = (int)insertTxn.ExecuteScalar();

                string ticketCode = "TKT" + DateTime.Now.Ticks.ToString().Substring(10);
                SqlCommand insertTkt = new SqlCommand(
                    "INSERT INTO Tickets (TransactionId, TicketCode) VALUES (@txn, @code)", conn);
                insertTkt.Parameters.AddWithValue("@txn", txnId);
                insertTkt.Parameters.AddWithValue("@code", ticketCode);
                insertTkt.ExecuteNonQuery();

                txtReport.Text = $"✅ Ticket Purchased!\nDestination: {selected.Text}\nAmount: {price:C}\nTicket Code: {ticketCode}";
            }
        }

        public class ComboBoxItem
        {
            public string Text { get; }
            public string Value { get; }

            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }
    }
}
