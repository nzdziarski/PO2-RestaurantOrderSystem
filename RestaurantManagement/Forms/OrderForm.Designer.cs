namespace PO2_RestaurantOrderSystem.Forms
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxMenu;
        private System.Windows.Forms.ListBox listBoxOrder;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnAddToOrder;
        private System.Windows.Forms.Button btnRemoveFromOrder;
        private System.Windows.Forms.Button btnSubmitOrder;
        private System.Windows.Forms.Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxMenu = new System.Windows.Forms.ListBox();
            this.listBoxOrder = new System.Windows.Forms.ListBox();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblMenu = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblTables = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnAddToOrder = new System.Windows.Forms.Button();
            this.btnRemoveFromOrder = new System.Windows.Forms.Button();
            this.btnSubmitOrder = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();

            // lblMenu
            this.lblMenu.Text = "Menu:";
            this.lblMenu.Location = new System.Drawing.Point(20, 20);
            this.lblMenu.Size = new System.Drawing.Size(100, 23);

            // listBoxMenu
            this.listBoxMenu.FormattingEnabled = true;
            this.listBoxMenu.ItemHeight = 24;
            this.listBoxMenu.Location = new System.Drawing.Point(20, 45);
            this.listBoxMenu.Size = new System.Drawing.Size(300, 250);

            // lblTables
            this.lblTables.Text = "Stolik:";
            this.lblTables.Location = new System.Drawing.Point(20, 310);
            this.lblTables.Size = new System.Drawing.Size(50, 23);

            // comboBoxTables
            this.comboBoxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTables.Location = new System.Drawing.Point(80, 310);
            this.comboBoxTables.Size = new System.Drawing.Size(240, 28);

            // lblQuantity
            this.lblQuantity.Text = "Ilość:";
            this.lblQuantity.Location = new System.Drawing.Point(340, 45);
            this.lblQuantity.Size = new System.Drawing.Size(50, 23);

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(400, 45);
            this.txtQuantity.Size = new System.Drawing.Size(50, 23);

            // btnAddToOrder
            this.btnAddToOrder.Text = "Dodaj do zamówienia";
            this.btnAddToOrder.Location = new System.Drawing.Point(340, 80);
            this.btnAddToOrder.Size = new System.Drawing.Size(170, 35);
            this.btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click);

            // lblOrder
            this.lblOrder.Text = "Aktualne zamówienie:";
            this.lblOrder.Location = new System.Drawing.Point(340, 130);
            this.lblOrder.Size = new System.Drawing.Size(200, 23);

            // listBoxOrder
            this.listBoxOrder.FormattingEnabled = true;
            this.listBoxOrder.ItemHeight = 24;
            this.listBoxOrder.Location = new System.Drawing.Point(340, 155);
            this.listBoxOrder.Size = new System.Drawing.Size(300, 140);

            // btnRemoveFromOrder
            this.btnRemoveFromOrder.Text = "Usuń z zamówienia";
            this.btnRemoveFromOrder.Location = new System.Drawing.Point(340, 310);
            this.btnRemoveFromOrder.Size = new System.Drawing.Size(170, 35);
            this.btnRemoveFromOrder.Click += new System.EventHandler(this.btnRemoveFromOrder_Click);

            // lblTotal
            this.lblTotal.Text = "Łącznie: 0 zł";
            this.lblTotal.Location = new System.Drawing.Point(340, 360);
            this.lblTotal.Size = new System.Drawing.Size(100, 23);

            // btnSubmitOrder
            this.btnSubmitOrder.Text = "Zapisz zamówienie";
            this.btnSubmitOrder.Location = new System.Drawing.Point(470, 355);
            this.btnSubmitOrder.Size = new System.Drawing.Size(170, 35);
            this.btnSubmitOrder.Click += new System.EventHandler(this.btnSubmitOrder_Click);

            // OrderForm
            this.ClientSize = new System.Drawing.Size(670, 410);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.listBoxMenu);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnAddToOrder);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.listBoxOrder);
            this.Controls.Add(this.btnRemoveFromOrder);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnSubmitOrder);
            this.Name = "OrderForm";
            this.Text = "Nowe zamówienie";
        }
    }
}