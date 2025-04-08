
namespace TicketVendorDemo
{
    partial class TicketForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.TextBox txtReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbDestination
            // 
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(30, 30);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(200, 24);
            this.cmbDestination.TabIndex = 0;
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(30, 70);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(200, 22);
            this.txtCard.TabIndex = 1;
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(30, 110);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(200, 30);
            this.btnPurchase.TabIndex = 2;
            this.btnPurchase.Text = "Purchase Ticket";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(30, 160);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(300, 100);
            this.txtReport.TabIndex = 3;
            // 
            // TicketForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 280);
            this.Controls.Add(this.cmbDestination);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.txtReport);
            this.Name = "TicketForm";
            this.Text = "Ticket Vendor Machine";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
