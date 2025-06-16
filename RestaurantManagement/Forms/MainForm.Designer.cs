namespace RestaurantManagement.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        public System.Windows.Forms.PictureBox pictureBoxBanner;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainLayout = new TableLayoutPanel();
            labelTitle = new Label();
            pictureBoxBanner = new PictureBox();
            buttonPanel = new FlowLayoutPanel();
            btnMenu = new Button();
            btnOrder = new Button();
            btnTables = new Button();
            // mainLayout
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 3;
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainLayout.Controls.Add(labelTitle, 0, 0);
            mainLayout.Controls.Add(pictureBoxBanner, 0, 1);
            mainLayout.Controls.Add(buttonPanel, 0, 2);
            // labelTitle
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Text = "Restauracja";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            // pictureBoxBanner
            pictureBoxBanner.Dock = DockStyle.Fill;
            pictureBoxBanner.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBanner.BackColor = Color.LightGray;
            // buttonPanel
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.FlowDirection = FlowDirection.LeftToRight;
            buttonPanel.WrapContents = false;
            buttonPanel.AutoSize = true;
            buttonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonPanel.Controls.Add(btnMenu);
            buttonPanel.Controls.Add(btnOrder);
            buttonPanel.Controls.Add(btnTables);
            buttonPanel.Padding = new Padding(50, 50, 50, 50);
            buttonPanel.Anchor = AnchorStyles.Top;
            // btnMenu
            btnMenu.Text = "Zobacz menu";
            btnMenu.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnMenu.Size = new Size(250, 80);
            btnMenu.Margin = new Padding(40, 0, 40, 0);
            btnMenu.Click += btnMenu_Click;
            // btnOrder
            btnOrder.Text = "Nowe zamówienie";
            btnOrder.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnOrder.Size = new Size(250, 80);
            btnOrder.Margin = new Padding(40, 0, 40, 0);
            btnOrder.Click += btnOrder_Click;
            // btnTables
            btnTables.Text = "Dostępne stoliki";
            btnTables.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnTables.Size = new Size(250, 80);
            btnTables.Margin = new Padding(40, 0, 40, 0);
            btnTables.Click += btnTables_Click;
            // MainForm
            Controls.Add(mainLayout);
            Name = "MainForm";
            Text = "Restauracja";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }
    }
}