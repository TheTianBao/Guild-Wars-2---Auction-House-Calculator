namespace Guild_Wars_2___Auction_House_Calculator
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            groupBox1 = new GroupBox();
            Button_Wiki = new Button();
            Button_Save = new Button();
            Button_Load = new Button();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            DataGrid_Calculation = new DataGridView();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrid_Calculation).BeginInit();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Button_Wiki);
            groupBox1.Controls.Add(Button_Save);
            groupBox1.Controls.Add(Button_Load);
            groupBox1.Location = new Point(1955, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(227, 372);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // Button_Wiki
            // 
            Button_Wiki.Location = new Point(6, 70);
            Button_Wiki.Name = "Button_Wiki";
            Button_Wiki.Size = new Size(206, 34);
            Button_Wiki.TabIndex = 4;
            Button_Wiki.Text = "Wiki";
            Button_Wiki.UseVisualStyleBackColor = true;
            Button_Wiki.Click += Button_Wiki_Click;
            // 
            // Button_Save
            // 
            Button_Save.Location = new Point(112, 30);
            Button_Save.Name = "Button_Save";
            Button_Save.Size = new Size(100, 34);
            Button_Save.TabIndex = 1;
            Button_Save.Text = "Save";
            Button_Save.UseVisualStyleBackColor = true;
            Button_Save.Click += Button_Save_Click;
            // 
            // Button_Load
            // 
            Button_Load.Location = new Point(6, 30);
            Button_Load.Name = "Button_Load";
            Button_Load.Size = new Size(100, 34);
            Button_Load.TabIndex = 0;
            Button_Load.Text = "Load";
            Button_Load.UseVisualStyleBackColor = true;
            Button_Load.Click += Button_Load_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(1955, 390);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(583, 567);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Additional Information";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 357);
            label3.Name = "label3";
            label3.Size = new Size(509, 50);
            label3.TabIndex = 2;
            label3.Text = "ℹ️Data is saved automatically on close and loaded on startup.\r\nℹ️Calculation is done automatically after entering data.\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 191);
            label2.Name = "label2";
            label2.Size = new Size(456, 150);
            label2.TabIndex = 1;
            label2.Text = resources.GetString("label2.Text");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(322, 150);
            label1.TabIndex = 0;
            label1.Text = "\U0001f9ee Fee Structure:\r\n\r\nThe Trading Post charges two fees:\r\n- Listing Fee: 5% of the sell price\r\n- Transaction Fee: 15% of the sell price .\r\n- Total Fees = 20% of the sell Price.";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(DataGrid_Calculation);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1937, 945);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Calculation";
            // 
            // DataGrid_Calculation
            // 
            DataGrid_Calculation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGrid_Calculation.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            DataGrid_Calculation.BackgroundColor = SystemColors.ScrollBar;
            DataGrid_Calculation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid_Calculation.Dock = DockStyle.Fill;
            DataGrid_Calculation.Location = new Point(3, 27);
            DataGrid_Calculation.Name = "DataGrid_Calculation";
            DataGrid_Calculation.RowHeadersWidth = 62;
            DataGrid_Calculation.Size = new Size(1931, 915);
            DataGrid_Calculation.TabIndex = 0;
            DataGrid_Calculation.CellEndEdit += DataGrid_Calculation_CellEndEdit;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(525, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(8, 8);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(0, 0);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(0, 0);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.GW2_Auction_House_Calculator;
            pictureBox1.Location = new Point(2188, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(350, 350);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2549, 968);
            Controls.Add(pictureBox1);
            Controls.Add(tabControl1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Guild Wars 2 – Auction House Calculator";
            FormClosing += Main_Form_FormClosing;
            Load += Main_Form_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGrid_Calculation).EndInit();
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button Button_Wiki;
        private Button Button_Save;
        private Button Button_Load;
        private FolderBrowserDialog folderBrowserDialog1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView DataGrid_Calculation;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
    }
}