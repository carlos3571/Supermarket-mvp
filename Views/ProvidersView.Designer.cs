namespace Supermarket_mvp.Views
{
    partial class ProvidersView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProvidersView));
            tabControl1 = new TabControl();
            tabListViewProviders = new TabPage();
            tabSingleViewProviders = new TabPage();
            label1 = new Label();
            TextProviderId = new TextBox();
            BuscarP = new Button();
            dataGridView1 = new DataGridView();
            NuevoP = new Button();
            EditarP = new Button();
            EliminarP = new Button();
            SalirP = new Button();
            label2 = new Label();
            TextProviderId1 = new TextBox();
            label3 = new Label();
            TextName = new TextBox();
            label4 = new Label();
            TextAddress = new TextBox();
            label5 = new Label();
            TextPhoneNumber = new TextBox();
            label6 = new Label();
            TextEmail = new TextBox();
            GuardarP = new Button();
            CancelarP = new Button();
            tabControl1.SuspendLayout();
            tabListViewProviders.SuspendLayout();
            tabSingleViewProviders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabListViewProviders);
            tabControl1.Controls.Add(tabSingleViewProviders);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabListViewProviders
            // 
            tabListViewProviders.Controls.Add(SalirP);
            tabListViewProviders.Controls.Add(EliminarP);
            tabListViewProviders.Controls.Add(EditarP);
            tabListViewProviders.Controls.Add(NuevoP);
            tabListViewProviders.Controls.Add(dataGridView1);
            tabListViewProviders.Controls.Add(BuscarP);
            tabListViewProviders.Controls.Add(TextProviderId);
            tabListViewProviders.Controls.Add(label1);
            tabListViewProviders.Location = new Point(4, 24);
            tabListViewProviders.Name = "tabListViewProviders";
            tabListViewProviders.Padding = new Padding(3);
            tabListViewProviders.Size = new Size(792, 422);
            tabListViewProviders.TabIndex = 0;
            tabListViewProviders.Text = "ListViewProviders";
            tabListViewProviders.UseVisualStyleBackColor = true;
            // 
            // tabSingleViewProviders
            // 
            tabSingleViewProviders.Controls.Add(CancelarP);
            tabSingleViewProviders.Controls.Add(GuardarP);
            tabSingleViewProviders.Controls.Add(TextEmail);
            tabSingleViewProviders.Controls.Add(label6);
            tabSingleViewProviders.Controls.Add(TextPhoneNumber);
            tabSingleViewProviders.Controls.Add(label5);
            tabSingleViewProviders.Controls.Add(TextAddress);
            tabSingleViewProviders.Controls.Add(label4);
            tabSingleViewProviders.Controls.Add(TextName);
            tabSingleViewProviders.Controls.Add(label3);
            tabSingleViewProviders.Controls.Add(TextProviderId1);
            tabSingleViewProviders.Controls.Add(label2);
            tabSingleViewProviders.Location = new Point(4, 24);
            tabSingleViewProviders.Name = "tabSingleViewProviders";
            tabSingleViewProviders.Padding = new Padding(3);
            tabSingleViewProviders.Size = new Size(792, 422);
            tabSingleViewProviders.TabIndex = 1;
            tabSingleViewProviders.Text = "SingleViewProviders";
            tabSingleViewProviders.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 17);
            label1.Name = "label1";
            label1.Size = new Size(163, 18);
            label1.TabIndex = 0;
            label1.Text = "search Provider Id";
            // 
            // TextProviderId
            // 
            TextProviderId.BackColor = SystemColors.ActiveCaption;
            TextProviderId.Location = new Point(19, 47);
            TextProviderId.Name = "TextProviderId";
            TextProviderId.PlaceholderText = "Search Provider Id";
            TextProviderId.Size = new Size(319, 23);
            TextProviderId.TabIndex = 1;
            // 
            // BuscarP
            // 
            BuscarP.BackgroundImage = (Image)resources.GetObject("BuscarP.BackgroundImage");
            BuscarP.BackgroundImageLayout = ImageLayout.Zoom;
            BuscarP.Location = new Point(380, 17);
            BuscarP.Name = "BuscarP";
            BuscarP.Size = new Size(75, 53);
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
            dataGridView1.GridColor = SystemColors.GradientActiveCaption;
            dataGridView1.Location = new Point(19, 91);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(436, 323);
            dataGridView1.TabIndex = 3;
            // 
            // NuevoP
            // 
            NuevoP.BackgroundImage = (Image)resources.GetObject("NuevoP.BackgroundImage");
            NuevoP.BackgroundImageLayout = ImageLayout.Zoom;
            NuevoP.Location = new Point(535, 91);
            NuevoP.Name = "NuevoP";
            NuevoP.Size = new Size(75, 52);
            NuevoP.TabIndex = 4;
            NuevoP.UseVisualStyleBackColor = true;
            // 
            // EditarP
            // 
            EditarP.BackgroundImage = (Image)resources.GetObject("EditarP.BackgroundImage");
            EditarP.BackgroundImageLayout = ImageLayout.Zoom;
            EditarP.Location = new Point(535, 177);
            EditarP.Name = "EditarP";
            EditarP.Size = new Size(75, 61);
            EditarP.TabIndex = 5;
            EditarP.UseVisualStyleBackColor = true;
            // 
            // EliminarP
            // 
            EliminarP.BackgroundImage = (Image)resources.GetObject("EliminarP.BackgroundImage");
            EliminarP.BackgroundImageLayout = ImageLayout.Zoom;
            EliminarP.Location = new Point(535, 266);
            EliminarP.Name = "EliminarP";
            EliminarP.Size = new Size(75, 61);
            EliminarP.TabIndex = 6;
            EliminarP.UseVisualStyleBackColor = true;
            // 
            // SalirP
            // 
            SalirP.BackgroundImage = Properties.Resources.cerrar_sesion;
            SalirP.BackgroundImageLayout = ImageLayout.Zoom;
            SalirP.Location = new Point(535, 354);
            SalirP.Name = "SalirP";
            SalirP.Size = new Size(75, 60);
            SalirP.TabIndex = 7;
            SalirP.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 18);
            label2.Name = "label2";
            label2.Size = new Size(103, 18);
            label2.TabIndex = 0;
            label2.Text = "Provider Id";
            // 
            // TextProviderId1
            // 
            TextProviderId1.BackColor = SystemColors.Info;
            TextProviderId1.Location = new Point(17, 39);
            TextProviderId1.Name = "TextProviderId1";
            TextProviderId1.PlaceholderText = "ProviderId";
            TextProviderId1.ReadOnly = true;
            TextProviderId1.Size = new Size(200, 23);
            TextProviderId1.TabIndex = 1;
            TextProviderId1.Text = "0";
            TextProviderId1.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 83);
            label3.Name = "label3";
            label3.Size = new Size(49, 18);
            label3.TabIndex = 2;
            label3.Text = "Name";
            // 
            // TextName
            // 
            TextName.BackColor = SystemColors.Info;
            TextName.Location = new Point(17, 104);
            TextName.Name = "TextName";
            TextName.PlaceholderText = "Name";
            TextName.Size = new Size(337, 23);
            TextName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 150);
            label4.Name = "label4";
            label4.Size = new Size(74, 18);
            label4.TabIndex = 4;
            label4.Text = "Address";
            // 
            // TextAddress
            // 
            TextAddress.BackColor = SystemColors.Info;
            TextAddress.Location = new Point(20, 171);
            TextAddress.Name = "TextAddress";
            TextAddress.PlaceholderText = "Address";
            TextAddress.Size = new Size(334, 23);
            TextAddress.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 229);
            label5.Name = "label5";
            label5.Size = new Size(123, 18);
            label5.TabIndex = 6;
            label5.Text = "PhoneNumber";
            // 
            // TextPhoneNumber
            // 
            TextPhoneNumber.BackColor = SystemColors.Info;
            TextPhoneNumber.Location = new Point(20, 250);
            TextPhoneNumber.Name = "TextPhoneNumber";
            TextPhoneNumber.PlaceholderText = "PhoneNumber";
            TextPhoneNumber.Size = new Size(334, 23);
            TextPhoneNumber.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 303);
            label6.Name = "label6";
            label6.Size = new Size(52, 18);
            label6.TabIndex = 8;
            label6.Text = "Email";
            // 
            // TextEmail
            // 
            TextEmail.BackColor = SystemColors.Info;
            TextEmail.Location = new Point(20, 324);
            TextEmail.Name = "TextEmail";
            TextEmail.PlaceholderText = "Email";
            TextEmail.Size = new Size(334, 23);
            TextEmail.TabIndex = 9;
            // 
            // GuardarP
            // 
            GuardarP.BackgroundImage = (Image)resources.GetObject("GuardarP.BackgroundImage");
            GuardarP.BackgroundImageLayout = ImageLayout.Zoom;
            GuardarP.Location = new Point(529, 39);
            GuardarP.Name = "GuardarP";
            GuardarP.Size = new Size(101, 88);
            GuardarP.TabIndex = 10;
            GuardarP.UseVisualStyleBackColor = true;
            // 
            // CancelarP
            // 
            CancelarP.BackgroundImage = (Image)resources.GetObject("CancelarP.BackgroundImage");
            CancelarP.BackgroundImageLayout = ImageLayout.Zoom;
            CancelarP.Location = new Point(529, 250);
            CancelarP.Name = "CancelarP";
            CancelarP.Size = new Size(101, 97);
            CancelarP.TabIndex = 11;
            CancelarP.UseVisualStyleBackColor = true;
            // 
            // ProvidersView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "ProvidersView";
            Text = "ProvidersView";
            tabControl1.ResumeLayout(false);
            tabListViewProviders.ResumeLayout(false);
            tabListViewProviders.PerformLayout();
            tabSingleViewProviders.ResumeLayout(false);
            tabSingleViewProviders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabListViewProviders;
        private TabPage tabSingleViewProviders;
        private Label label1;
        private Button BuscarP;
        private TextBox TextProviderId;
        private DataGridView dataGridView1;
        private Button SalirP;
        private Button EliminarP;
        private Button EditarP;
        private Button NuevoP;
        private TextBox TextProviderId1;
        private Label label2;
        private Label label3;
        private TextBox TextAddress;
        private Label label4;
        private TextBox TextName;
        private Label label5;
        private Button CancelarP;
        private Button GuardarP;
        private TextBox TextEmail;
        private Label label6;
        private TextBox TextPhoneNumber;
    }
}