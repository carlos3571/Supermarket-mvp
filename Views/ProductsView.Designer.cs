namespace Supermarket_mvp.Views
{
    partial class ProductsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsView));
            tabControl1 = new TabControl();
            tabListViewProduct = new TabPage();
            tabSingleViewProduct = new TabPage();
            Label1 = new Label();
            TextProductId = new TextBox();
            BuscarP = new Button();
            dataGridView1 = new DataGridView();
            NuevoP = new Button();
            EditarP = new Button();
            EliminarP = new Button();
            SalirP = new Button();
            label2 = new Label();
            TextProductId1 = new TextBox();
            label3 = new Label();
            TextName = new TextBox();
            label4 = new Label();
            TextDescription = new TextBox();
            label5 = new Label();
            TextPrice = new TextBox();
            label6 = new Label();
            TextCategoryId = new TextBox();
            GuardarP = new Button();
            CancelarP = new Button();
            tabControl1.SuspendLayout();
            tabListViewProduct.SuspendLayout();
            tabSingleViewProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabListViewProduct);
            tabControl1.Controls.Add(tabSingleViewProduct);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabListViewProduct
            // 
            tabListViewProduct.Controls.Add(SalirP);
            tabListViewProduct.Controls.Add(EliminarP);
            tabListViewProduct.Controls.Add(EditarP);
            tabListViewProduct.Controls.Add(NuevoP);
            tabListViewProduct.Controls.Add(dataGridView1);
            tabListViewProduct.Controls.Add(BuscarP);
            tabListViewProduct.Controls.Add(TextProductId);
            tabListViewProduct.Controls.Add(Label1);
            tabListViewProduct.Location = new Point(4, 24);
            tabListViewProduct.Name = "tabListViewProduct";
            tabListViewProduct.Padding = new Padding(3);
            tabListViewProduct.Size = new Size(792, 422);
            tabListViewProduct.TabIndex = 0;
            tabListViewProduct.Text = "ListViewProduct";
            tabListViewProduct.UseVisualStyleBackColor = true;
            // 
            // tabSingleViewProduct
            // 
            tabSingleViewProduct.Controls.Add(CancelarP);
            tabSingleViewProduct.Controls.Add(GuardarP);
            tabSingleViewProduct.Controls.Add(TextCategoryId);
            tabSingleViewProduct.Controls.Add(label6);
            tabSingleViewProduct.Controls.Add(TextPrice);
            tabSingleViewProduct.Controls.Add(label5);
            tabSingleViewProduct.Controls.Add(TextDescription);
            tabSingleViewProduct.Controls.Add(label4);
            tabSingleViewProduct.Controls.Add(TextName);
            tabSingleViewProduct.Controls.Add(label3);
            tabSingleViewProduct.Controls.Add(TextProductId1);
            tabSingleViewProduct.Controls.Add(label2);
            tabSingleViewProduct.Location = new Point(4, 24);
            tabSingleViewProduct.Name = "tabSingleViewProduct";
            tabSingleViewProduct.Padding = new Padding(3);
            tabSingleViewProduct.Size = new Size(792, 422);
            tabSingleViewProduct.TabIndex = 1;
            tabSingleViewProduct.Text = "SingleViewProduct";
            tabSingleViewProduct.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label1.Location = new Point(17, 18);
            Label1.Name = "Label1";
            Label1.Size = new Size(171, 20);
            Label1.TabIndex = 0;
            Label1.Text = "Search Product Id";
            // 
            // TextProductId
            // 
            TextProductId.BackColor = SystemColors.InactiveCaption;
            TextProductId.Location = new Point(17, 53);
            TextProductId.Name = "TextProductId";
            TextProductId.PlaceholderText = "Data to search";
            TextProductId.Size = new Size(363, 23);
            TextProductId.TabIndex = 1;
            // 
            // BuscarP
            // 
            BuscarP.BackgroundImage = (Image)resources.GetObject("BuscarP.BackgroundImage");
            BuscarP.BackgroundImageLayout = ImageLayout.Zoom;
            BuscarP.Location = new Point(413, 26);
            BuscarP.Name = "BuscarP";
            BuscarP.Size = new Size(75, 50);
            BuscarP.TabIndex = 2;
            BuscarP.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Info;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 97);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(471, 317);
            dataGridView1.TabIndex = 3;
            // 
            // NuevoP
            // 
            NuevoP.BackgroundImage = (Image)resources.GetObject("NuevoP.BackgroundImage");
            NuevoP.BackgroundImageLayout = ImageLayout.Zoom;
            NuevoP.Location = new Point(570, 98);
            NuevoP.Name = "NuevoP";
            NuevoP.Size = new Size(75, 56);
            NuevoP.TabIndex = 4;
            NuevoP.UseVisualStyleBackColor = true;
            // 
            // EditarP
            // 
            EditarP.BackgroundImage = (Image)resources.GetObject("EditarP.BackgroundImage");
            EditarP.BackgroundImageLayout = ImageLayout.Zoom;
            EditarP.Location = new Point(570, 188);
            EditarP.Name = "EditarP";
            EditarP.Size = new Size(75, 58);
            EditarP.TabIndex = 5;
            EditarP.UseVisualStyleBackColor = true;
            // 
            // EliminarP
            // 
            EliminarP.BackgroundImage = (Image)resources.GetObject("EliminarP.BackgroundImage");
            EliminarP.BackgroundImageLayout = ImageLayout.Zoom;
            EliminarP.Location = new Point(570, 275);
            EliminarP.Name = "EliminarP";
            EliminarP.Size = new Size(75, 56);
            EliminarP.TabIndex = 6;
            EliminarP.UseVisualStyleBackColor = true;
            EliminarP.Click += button3_Click;
            // 
            // SalirP
            // 
            SalirP.BackColor = Color.RosyBrown;
            SalirP.BackgroundImage = Properties.Resources.salirr;
            SalirP.BackgroundImageLayout = ImageLayout.Zoom;
            SalirP.Location = new Point(570, 359);
            SalirP.Name = "SalirP";
            SalirP.Size = new Size(75, 55);
            SalirP.TabIndex = 7;
            SalirP.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 14);
            label2.Name = "label2";
            label2.Size = new Size(95, 18);
            label2.TabIndex = 0;
            label2.Text = "ProductId";
            // 
            // TextProductId1
            // 
            TextProductId1.BackColor = SystemColors.ActiveCaption;
            TextProductId1.Location = new Point(18, 35);
            TextProductId1.Name = "TextProductId1";
            TextProductId1.ReadOnly = true;
            TextProductId1.Size = new Size(357, 23);
            TextProductId1.TabIndex = 1;
            TextProductId1.Text = "0";
            TextProductId1.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 84);
            label3.Name = "label3";
            label3.Size = new Size(49, 18);
            label3.TabIndex = 2;
            label3.Text = "Name";
            label3.Click += label3_Click;
            // 
            // TextName
            // 
            TextName.BackColor = SystemColors.ActiveCaption;
            TextName.Location = new Point(18, 105);
            TextName.Name = "TextName";
            TextName.PlaceholderText = "Name";
            TextName.Size = new Size(357, 23);
            TextName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(18, 162);
            label4.Name = "label4";
            label4.Size = new Size(105, 18);
            label4.TabIndex = 4;
            label4.Text = "Description";
            // 
            // TextDescription
            // 
            TextDescription.BackColor = SystemColors.ActiveCaption;
            TextDescription.Location = new Point(18, 183);
            TextDescription.Name = "TextDescription";
            TextDescription.PlaceholderText = "Description";
            TextDescription.Size = new Size(357, 23);
            TextDescription.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 237);
            label5.Name = "label5";
            label5.Size = new Size(51, 18);
            label5.TabIndex = 6;
            label5.Text = "Price";
            // 
            // TextPrice
            // 
            TextPrice.BackColor = SystemColors.ActiveCaption;
            TextPrice.Location = new Point(18, 258);
            TextPrice.Name = "TextPrice";
            TextPrice.PlaceholderText = "Price";
            TextPrice.Size = new Size(189, 23);
            TextPrice.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(18, 327);
            label6.Name = "label6";
            label6.Size = new Size(100, 18);
            label6.TabIndex = 8;
            label6.Text = "CategoryId";
            // 
            // TextCategoryId
            // 
            TextCategoryId.BackColor = SystemColors.ActiveCaption;
            TextCategoryId.Location = new Point(18, 348);
            TextCategoryId.Name = "TextCategoryId";
            TextCategoryId.PlaceholderText = "CategoryId";
            TextCategoryId.Size = new Size(357, 23);
            TextCategoryId.TabIndex = 9;
            // 
            // GuardarP
            // 
            GuardarP.BackgroundImage = (Image)resources.GetObject("GuardarP.BackgroundImage");
            GuardarP.BackgroundImageLayout = ImageLayout.Zoom;
            GuardarP.Location = new Point(530, 35);
            GuardarP.Name = "GuardarP";
            GuardarP.Size = new Size(100, 93);
            GuardarP.TabIndex = 10;
            GuardarP.UseVisualStyleBackColor = true;
            // 
            // CancelarP
            // 
            CancelarP.BackgroundImage = (Image)resources.GetObject("CancelarP.BackgroundImage");
            CancelarP.BackgroundImageLayout = ImageLayout.Zoom;
            CancelarP.Location = new Point(530, 224);
            CancelarP.Name = "CancelarP";
            CancelarP.Size = new Size(100, 102);
            CancelarP.TabIndex = 11;
            CancelarP.UseVisualStyleBackColor = true;
            // 
            // ProductsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "ProductsView";
            Text = "ProductsView";
            tabControl1.ResumeLayout(false);
            tabListViewProduct.ResumeLayout(false);
            tabListViewProduct.PerformLayout();
            tabSingleViewProduct.ResumeLayout(false);
            tabSingleViewProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabListViewProduct;
        private Label Label1;
        private TabPage tabSingleViewProduct;
        private TextBox TextProductId;
        private Button BuscarP;
        private Button SalirP;
        private Button EliminarP;
        private Button EditarP;
        private Button NuevoP;
        private DataGridView dataGridView1;
        private Label label2;
        private TextBox TextProductId1;
        private TextBox TextName;
        private Label label3;
        private TextBox TextDescription;
        private Label label4;
        private TextBox TextCategoryId;
        private Label label6;
        private TextBox TextPrice;
        private Label label5;
        private Button CancelarP;
        private Button GuardarP;
    }
}