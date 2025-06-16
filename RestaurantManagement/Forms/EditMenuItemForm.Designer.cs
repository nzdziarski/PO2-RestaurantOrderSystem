namespace PO2_RestaurantOrderSystem.Forms
{
    partial class EditMenuItemForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtDescription;
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // 
            // lblName
            // 
            this.lblName.Text = "Nazwa:";
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Size = new System.Drawing.Size(80, 23);

            // 
            // lblPrice
            // 
            this.lblPrice.Text = "Cena:";
            this.lblPrice.Location = new System.Drawing.Point(20, 60);
            this.lblPrice.Size = new System.Drawing.Size(80, 23);

            // 
            // lblCategory
            // 
            this.lblCategory.Text = "Kategoria:";
            this.lblCategory.Location = new System.Drawing.Point(20, 100);
            this.lblCategory.Size = new System.Drawing.Size(80, 23);

            // 
            // lblDescription
            // 
            this.lblDescription.Text = "Opis:";
            this.lblDescription.Location = new System.Drawing.Point(20, 140);
            this.lblDescription.Size = new System.Drawing.Size(80, 23);

            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 20);
            this.txtName.Size = new System.Drawing.Size(200, 23);

            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(110, 60);
            this.txtPrice.Size = new System.Drawing.Size(200, 23);

            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(110, 100);
            this.txtCategory.Size = new System.Drawing.Size(200, 23);

            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 140);
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.Multiline = true;

            // 
            // btnOK
            // 
            this.btnOK.Text = "Zapisz";
            this.btnOK.Location = new System.Drawing.Point(60, 220);
            this.btnOK.Size = new System.Drawing.Size(100, 35);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.Location = new System.Drawing.Point(180, 220);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // EditMenuItemForm
            // 
            this.ClientSize = new System.Drawing.Size(340, 280);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "EditMenuItemForm";
            this.Text = "Edycja pozycji menu";
        }
    }
}