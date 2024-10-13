namespace Supermarket_mvp.Views
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            panel1 = new Panel();
            Productos = new Button();
            Categoria = new Button();
            BtnExit = new Button();
            pictureBox1 = new PictureBox();
            BtnPayMode = new Button();
            Proveedores = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Proveedores);
            panel1.Controls.Add(Productos);
            panel1.Controls.Add(Categoria);
            panel1.Controls.Add(BtnExit);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(BtnPayMode);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 450);
            panel1.TabIndex = 0;
            // 
            // Productos
            // 
            Productos.BackgroundImage = (Image)resources.GetObject("Productos.BackgroundImage");
            Productos.BackgroundImageLayout = ImageLayout.Zoom;
            Productos.Location = new Point(0, 218);
            Productos.Name = "Productos";
            Productos.Size = new Size(197, 75);
            Productos.TabIndex = 6;
            Productos.UseVisualStyleBackColor = true;
            // 
            // Categoria
            // 
            Categoria.BackgroundImage = (Image)resources.GetObject("Categoria.BackgroundImage");
            Categoria.BackgroundImageLayout = ImageLayout.Zoom;
            Categoria.Location = new Point(3, 146);
            Categoria.Name = "Categoria";
            Categoria.Size = new Size(194, 66);
            Categoria.TabIndex = 5;
            Categoria.UseVisualStyleBackColor = true;
            // 
            // BtnExit
            // 
            BtnExit.BackgroundImage = Properties.Resources.cerrar_sesion;
            BtnExit.BackgroundImageLayout = ImageLayout.Zoom;
            BtnExit.Dock = DockStyle.Bottom;
            BtnExit.Location = new Point(0, 390);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(200, 60);
            BtnExit.TabIndex = 4;
            BtnExit.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(194, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // BtnPayMode
            // 
            BtnPayMode.BackgroundImage = (Image)resources.GetObject("BtnPayMode.BackgroundImage");
            BtnPayMode.BackgroundImageLayout = ImageLayout.Zoom;
            BtnPayMode.Location = new Point(3, 59);
            BtnPayMode.Name = "BtnPayMode";
            BtnPayMode.Size = new Size(194, 81);
            BtnPayMode.TabIndex = 2;
            BtnPayMode.UseVisualStyleBackColor = true;
            BtnPayMode.Click += BtnPayMode_Click;
            // 
            // Proveedores
            // 
            Proveedores.BackgroundImage = (Image)resources.GetObject("Proveedores.BackgroundImage");
            Proveedores.BackgroundImageLayout = ImageLayout.Zoom;
            Proveedores.Location = new Point(3, 299);
            Proveedores.Name = "Proveedores";
            Proveedores.Size = new Size(194, 77);
            Proveedores.TabIndex = 7;
            Proveedores.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            IsMdiContainer = true;
            Name = "MainView";
            Text = "Supermarket";
            WindowState = FormWindowState.Maximized;
            Load += MainView_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button BtnPayMode;
        private Button BtnExit;
        private Button Categoria;
        private Button Productos;
        private Button Proveedores;
    }
}