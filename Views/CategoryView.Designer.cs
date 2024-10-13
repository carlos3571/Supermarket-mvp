namespace Supermarket_mvp.Views
{
    partial class CategoryView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryView));
            tabControl1 = new TabControl();
            tabListViewCategory = new TabPage();
            SalirC = new Button();
            EliminarC = new Button();
            EditarC = new Button();
            NuevoC = new Button();
            dataGridView1 = new DataGridView();
            Buscar = new Button();
            textCategoryId = new TextBox();
            label1 = new Label();
            tabSingleViewCategory = new TabPage();
            CancelarC = new Button();
            GuardarC = new Button();
            txtDescription = new TextBox();
            Label4 = new Label();
            txtCategoryName = new TextBox();
            label3 = new Label();
            txtCategoryId = new TextBox();
            label2 = new Label();
            tabControl1.SuspendLayout();
            tabListViewCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabSingleViewCategory.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabListViewCategory);
            tabControl1.Controls.Add(tabSingleViewCategory);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabListViewCategory
            // 
            tabListViewCategory.Controls.Add(SalirC);
            tabListViewCategory.Controls.Add(EliminarC);
            tabListViewCategory.Controls.Add(EditarC);
            tabListViewCategory.Controls.Add(NuevoC);
            tabListViewCategory.Controls.Add(dataGridView1);
            tabListViewCategory.Controls.Add(Buscar);
            tabListViewCategory.Controls.Add(textCategoryId);
            tabListViewCategory.Controls.Add(label1);
            tabListViewCategory.Location = new Point(4, 24);
            tabListViewCategory.Name = "tabListViewCategory";
            tabListViewCategory.Padding = new Padding(3);
            tabListViewCategory.Size = new Size(792, 422);
            tabListViewCategory.TabIndex = 0;
            tabListViewCategory.Text = "ListViewCategory";
            tabListViewCategory.UseVisualStyleBackColor = true;
            // 
            // SalirC
            // 
            SalirC.BackgroundImage = (Image)resources.GetObject("SalirC.BackgroundImage");
            SalirC.BackgroundImageLayout = ImageLayout.Zoom;
            SalirC.Location = new Point(540, 352);
            SalirC.Name = "SalirC";
            SalirC.Size = new Size(75, 55);
            SalirC.TabIndex = 7;
            SalirC.UseVisualStyleBackColor = true;
            SalirC.Click += SalirC_Click;
            // 
            // EliminarC
            // 
            EliminarC.BackgroundImage = Properties.Resources.eliminar;
            EliminarC.BackgroundImageLayout = ImageLayout.Zoom;
            EliminarC.Location = new Point(540, 271);
            EliminarC.Name = "EliminarC";
            EliminarC.Size = new Size(75, 57);
            EliminarC.TabIndex = 6;
            EliminarC.UseVisualStyleBackColor = true;
            EliminarC.Click += EliminarC_Click;
            // 
            // EditarC
            // 
            EditarC.BackgroundImage = Properties.Resources.editar;
            EditarC.BackgroundImageLayout = ImageLayout.Zoom;
            EditarC.Location = new Point(540, 183);
            EditarC.Name = "EditarC";
            EditarC.Size = new Size(75, 62);
            EditarC.TabIndex = 5;
            EditarC.UseVisualStyleBackColor = true;
            EditarC.Click += EditarC_Click;
            // 
            // NuevoC
            // 
            NuevoC.BackgroundImage = Properties.Resources.agregar_producto;
            NuevoC.BackgroundImageLayout = ImageLayout.Zoom;
            NuevoC.Location = new Point(540, 100);
            NuevoC.Name = "NuevoC";
            NuevoC.Size = new Size(75, 53);
            NuevoC.TabIndex = 4;
            NuevoC.UseVisualStyleBackColor = true;
            NuevoC.Click += NuevoC_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(430, 307);
            dataGridView1.TabIndex = 3;
            // 
            // Buscar
            // 
            Buscar.BackgroundImage = Properties.Resources.search;
            Buscar.BackgroundImageLayout = ImageLayout.Zoom;
            Buscar.Location = new Point(355, 25);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(97, 52);
            Buscar.TabIndex = 2;
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // textCategoryId
            // 
            textCategoryId.BackColor = SystemColors.InactiveCaption;
            textCategoryId.Location = new Point(22, 48);
            textCategoryId.Name = "textCategoryId";
            textCategoryId.PlaceholderText = "CategoryId";
            textCategoryId.Size = new Size(302, 23);
            textCategoryId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 25);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 0;
            label1.Text = "CategoryIdlbl";
            // 
            // tabSingleViewCategory
            // 
            tabSingleViewCategory.Controls.Add(CancelarC);
            tabSingleViewCategory.Controls.Add(GuardarC);
            tabSingleViewCategory.Controls.Add(txtDescription);
            tabSingleViewCategory.Controls.Add(Label4);
            tabSingleViewCategory.Controls.Add(txtCategoryName);
            tabSingleViewCategory.Controls.Add(label3);
            tabSingleViewCategory.Controls.Add(txtCategoryId);
            tabSingleViewCategory.Controls.Add(label2);
            tabSingleViewCategory.Location = new Point(4, 24);
            tabSingleViewCategory.Name = "tabSingleViewCategory";
            tabSingleViewCategory.Padding = new Padding(3);
            tabSingleViewCategory.Size = new Size(792, 422);
            tabSingleViewCategory.TabIndex = 1;
            tabSingleViewCategory.Text = "SingleViewCategory";
            tabSingleViewCategory.UseVisualStyleBackColor = true;
            // 
            // CancelarC
            // 
            CancelarC.BackgroundImage = Properties.Resources.cancelar;
            CancelarC.BackgroundImageLayout = ImageLayout.Zoom;
            CancelarC.Location = new Point(487, 255);
            CancelarC.Name = "CancelarC";
            CancelarC.Size = new Size(108, 94);
            CancelarC.TabIndex = 7;
            CancelarC.UseVisualStyleBackColor = true;
            //CancelarC.Click += CancelarC_Click;
            // 
            // GuardarC
            // 
            GuardarC.BackgroundImage = Properties.Resources.guardar;
            GuardarC.BackgroundImageLayout = ImageLayout.Zoom;
            GuardarC.Location = new Point(487, 73);
            GuardarC.Name = "GuardarC";
            GuardarC.Size = new Size(108, 99);
            GuardarC.TabIndex = 6;
            GuardarC.UseVisualStyleBackColor = true;
            GuardarC.Click += GuardarC_Click;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = SystemColors.InactiveCaption;
            txtDescription.Location = new Point(17, 295);
            txtDescription.Name = "Description";
            txtDescription.PlaceholderText = "Description";
            txtDescription.Size = new Size(361, 23);
            txtDescription.TabIndex = 5;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label4.Location = new Point(14, 255);
            Label4.Name = "Label4";
            Label4.Size = new Size(116, 20);
            Label4.TabIndex = 4;
            Label4.Text = "Description";
            // 
            // txtCategoryName
            // 
            txtCategoryName.BackColor = SystemColors.InactiveCaption;
            txtCategoryName.Location = new Point(18, 174);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.PlaceholderText = "txtCategoryName";
            txtCategoryName.Size = new Size(360, 23);
            txtCategoryName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 141);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 2;
            label3.Text = "txtCategoryName";
            // 
            // CategoryIdTextbox
            // 
            txtCategoryId.BackColor = SystemColors.InactiveCaption;
            txtCategoryId.Location = new Point(18, 73);
            txtCategoryId.Name = "CategoryId";
            txtCategoryId.PlaceholderText = "CategoryId";
            txtCategoryId.Size = new Size(360, 23);
            txtCategoryId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 34);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 0;
            label2.Text = "CategoryId";
            // 
            // CategoryView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            //txtCategoryName = "CategoryView";
            Text = "CategoryView";
            tabControl1.ResumeLayout(false);
            tabListViewCategory.ResumeLayout(false);
            tabListViewCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabSingleViewCategory.ResumeLayout(false);
            tabSingleViewCategory.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabListViewCategory;
        private TextBox textCategoryId;
        private Label label1;
        private TabPage tabSingleViewCategory;
        private Button SalirC;
        private Button EliminarC;
        private Button EditarC;
        private Button NuevoC;
        private DataGridView dataGridView1;
        private Button Buscar;
        private TextBox txtDescription;
        private Label Label4;
        private TextBox txtCategoryName;
        private Label label3;
        private TextBox txtCategoryId;
        private Label label2;
        private Button CancelarC;
        private Button GuardarC;
    }
}