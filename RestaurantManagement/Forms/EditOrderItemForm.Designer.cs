namespace PO2_RestaurantOrderSystem.Forms
{
    partial class EditOrderItemForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.ComboBox comboBoxMenu;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
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
            this.lblMenu = new System.Windows.Forms.Label();
            this.comboBoxMenu = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // 
            // lblMenu
            // 
            this.lblMenu.Text = "Pozycja z menu:";
            this.lblMenu.Location = new System.Drawing.Point(20, 20);
            this.lblMenu.Size = new System.Drawing.Size(100, 23);

            // 
            // comboBoxMenu
            // 
            this.comboBoxMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMenu.Location = new System.Drawing.Point(130, 20);
            this.comboBoxMenu.Size = new System.Drawing.Size(220, 23);
            this.comboBoxMenu.SelectedIndexChanged += new System.EventHandler(this.comboBoxMenu_SelectedIndexChanged);

            // 
            // lblPrice
            // 
            this.lblPrice.Text = "Cena:";
            this.lblPrice.Location = new System.Drawing.Point(20, 60);
            this.lblPrice.Size = new System.Drawing.Size(200, 23);

            // 
            // lblQuantity
            // 
            this.lblQuantity.Text = "Ilość:";
            this.lblQuantity.Location = new System.Drawing.Point(20, 100);
            this.lblQuantity.Size = new System.Drawing.Size(50, 23);

            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(130, 100);
            this.txtQuantity.Size = new System.Drawing.Size(60, 23);

            // 
            // btnOK
            // 
            this.btnOK.Text = "Zapisz";
            this.btnOK.Location = new System.Drawing.Point(50, 150);
            this.btnOK.Size = new System.Drawing.Size(90, 30);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.Location = new System.Drawing.Point(170, 150);
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // EditOrderItemForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 200);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.comboBoxMenu);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Text = "Pozycja zamówienia";
        }
    }
}