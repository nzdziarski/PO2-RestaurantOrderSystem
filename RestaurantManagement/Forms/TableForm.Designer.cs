namespace PO2_RestaurantOrderSystem.Forms
{
    partial class TableForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnEditTable;
        private System.Windows.Forms.Button btnDeleteTable;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnEditTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();

            // 
            // listBoxTables
            // 
            this.listBoxTables.FormattingEnabled = true;
            this.listBoxTables.ItemHeight = 24;
            this.listBoxTables.Location = new System.Drawing.Point(20, 20);
            this.listBoxTables.Size = new System.Drawing.Size(350, 300);

            // Dodaj obsługę DoubleClick
            this.listBoxTables.DoubleClick += new System.EventHandler(this.listBoxTables_DoubleClick);

            // 
            // btnAddTable
            // 
            this.btnAddTable.Text = "Dodaj stolik";
            this.btnAddTable.Location = new System.Drawing.Point(400, 20);
            this.btnAddTable.Size = new System.Drawing.Size(150, 40);
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);

            // 
            // btnEditTable
            // 
            this.btnEditTable.Text = "Edytuj stolik";
            this.btnEditTable.Location = new System.Drawing.Point(400, 70);
            this.btnEditTable.Size = new System.Drawing.Size(150, 40);
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);

            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Text = "Usuń stolik";
            this.btnDeleteTable.Location = new System.Drawing.Point(400, 120);
            this.btnDeleteTable.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);

            // 
            // TableForm
            // 
            this.ClientSize = new System.Drawing.Size(580, 350);
            this.Controls.Add(this.listBoxTables);
            this.Controls.Add(this.btnAddTable);
            this.Controls.Add(this.btnEditTable);
            this.Controls.Add(this.btnDeleteTable);
            this.Name = "TableForm";
            this.Text = "Zarządzanie stolikami";
        }
    }
}