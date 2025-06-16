namespace PO2_RestaurantOrderSystem.Forms
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxMenu;
        private System.Windows.Forms.Button btnAddMenuItem;
        private System.Windows.Forms.Button btnEditMenuItem;
        private System.Windows.Forms.Button btnDeleteMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxMenu = new System.Windows.Forms.ListBox();
            this.btnAddMenuItem = new System.Windows.Forms.Button();
            this.btnEditMenuItem = new System.Windows.Forms.Button();
            this.btnDeleteMenuItem = new System.Windows.Forms.Button();

            // 
            // listBoxMenu
            // 
            this.listBoxMenu.FormattingEnabled = true;
            this.listBoxMenu.ItemHeight = 24;
            this.listBoxMenu.Location = new System.Drawing.Point(20, 20);
            this.listBoxMenu.Size = new System.Drawing.Size(350, 300);

            // 
            // btnAddMenuItem
            // 
            this.btnAddMenuItem.Text = "Dodaj pozycję";
            this.btnAddMenuItem.Location = new System.Drawing.Point(400, 20);
            this.btnAddMenuItem.Size = new System.Drawing.Size(150, 40);
            this.btnAddMenuItem.Click += new System.EventHandler(this.btnAddMenuItem_Click);

            // 
            // btnEditMenuItem
            // 
            this.btnEditMenuItem.Text = "Edytuj pozycję";
            this.btnEditMenuItem.Location = new System.Drawing.Point(400, 70);
            this.btnEditMenuItem.Size = new System.Drawing.Size(150, 40);
            this.btnEditMenuItem.Click += new System.EventHandler(this.btnEditMenuItem_Click);

            // 
            // btnDeleteMenuItem
            // 
            this.btnDeleteMenuItem.Text = "Usuń pozycję";
            this.btnDeleteMenuItem.Location = new System.Drawing.Point(400, 120);
            this.btnDeleteMenuItem.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteMenuItem.Click += new System.EventHandler(this.btnDeleteMenuItem_Click);

            // 
            // MenuForm
            // 
            this.ClientSize = new System.Drawing.Size(580, 350);
            this.Controls.Add(this.listBoxMenu);
            this.Controls.Add(this.btnAddMenuItem);
            this.Controls.Add(this.btnEditMenuItem);
            this.Controls.Add(this.btnDeleteMenuItem);
            this.Name = "MenuForm";
            this.Text = "Zarządzanie menu";
        }
    }
}