namespace PO2_RestaurantOrderSystem.Forms
{
    partial class EditTableForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.CheckBox chkReserved;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.chkReserved = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // lblNumber
            this.lblNumber.Text = "Numer stolika:";
            this.lblNumber.Location = new System.Drawing.Point(20, 20);
            this.lblNumber.Size = new System.Drawing.Size(90, 23);

            // txtNumber
            this.txtNumber.Location = new System.Drawing.Point(120, 20);
            this.txtNumber.Size = new System.Drawing.Size(160, 23);

            // chkReserved
            this.chkReserved.Text = "Zarezerwowany";
            this.chkReserved.Location = new System.Drawing.Point(120, 60);
            this.chkReserved.Size = new System.Drawing.Size(130, 25);

            // btnOK
            this.btnOK.Text = "OK";
            this.btnOK.Location = new System.Drawing.Point(40, 110);
            this.btnOK.Size = new System.Drawing.Size(90, 35);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.Location = new System.Drawing.Point(160, 110);
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // EditTableForm
            this.ClientSize = new System.Drawing.Size(320, 170);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.chkReserved);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "EditTableForm";
            this.Text = "Stolik";
        }
    }
}