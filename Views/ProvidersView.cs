using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_mvp.Views
{
    public partial class ProvidersView : Form, IProvidersView
    {
        private bool isEdit;
        private bool isSuccesful;
        private string message;
        public ProvidersView()
        {
            InitializeComponent();
            SalirP.Click += delegate { this.Close(); };

            AssociateAndRaiseViewEvents();

            tabControl1.TabPages.Remove(tabSingleViewProviders);
            NuevoP.Click += NuevoP_Click;
        }

        

        private void AssociateAndRaiseViewEvents()
        {
            BuscarP.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };

            BuscarP.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            //agregar llame el evento AddNewEvent cuando se haga clic en el boton BtnNew
            NuevoP.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);

                // Remueve la pestaña de lista si está presente
                if (tabControl1.TabPages.Contains(tabSingleViewProviders))
                {
                    tabControl1.TabPages.Remove(tabListViewProviders);
                }

                // Añade la pestaña de detalles si no está ya añadida
                if (!tabControl1.TabPages.Contains(tabSingleViewProviders))
                {
                    tabControl1.TabPages.Add(tabListViewProviders);
                }

                tabSingleViewProviders.Text = "Agregar nuevo Providers";
            };
            EditarP.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty); // Esto debería invocar el método en el presenter.

                tabControl1.TabPages.Remove(tabListViewProviders);
                tabControl1.TabPages.Add(tabSingleViewProviders);
                tabSingleViewProviders.Text = "Editar Providers";

                IsEdit = true; // Aquí debe establecerse en true.
            };

            GuardarP.Click += delegate
            {


                if (string.IsNullOrWhiteSpace(TextName.Text.Trim()) || string.IsNullOrWhiteSpace(TextAddress.Text.Trim()))
                {
                    MessageBox.Show("Provider are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Invoca el evento de guardado
                SaveEvent?.Invoke(this, EventArgs.Empty);

                // Verifica si la operación fue exitosa
                if (IsSuccessful)
                {
                    // Guardado exitoso, volver a la lista de modos de pago
                    tabControl1.TabPages.Remove(tabSingleViewProviders);
                    tabControl1.TabPages.Add(tabListViewProviders);
                    MessageBox.Show("Providers successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };


            CancelarP.Click += delegate
            {
                // Cancelar y volver a la lista
                CancelEvent?.Invoke(this, EventArgs.Empty);

                tabControl1.TabPages.Remove(tabSingleViewProviders);
                tabControl1.TabPages.Add(tabListViewProviders);
            };

        }
        private static ProvidersView _instance;
        public static ProvidersView GetInstance(Form parentContainer)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new ProvidersView();
                _instance.MdiParent = parentContainer;
                _instance.FormBorderStyle = FormBorderStyle.None;
                _instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (_instance.WindowState == FormWindowState.Minimized)
                {
                    _instance.WindowState = FormWindowState.Normal;
                }
                _instance.BringToFront();
            }
            return _instance;
        }

        private void ProvidersView_Load(object sender, EventArgs e)
        {
            // Si estamos en modo de edición, se cargará la pestaña de edición
            if (isEdit)
            {
                if (!tabControl1.TabPages.Contains(tabSingleViewProviders))
                {
                    tabControl1.TabPages.Add(tabSingleViewProviders);
                }               

                tabSingleViewProviders.Text = "Editar Providers";
            }
            else
            {
                if (!tabControl1.TabPages.Contains(tabSingleViewProviders))
                {
                    tabControl1.TabPages.Add(tabSingleViewProviders);
                }

                tabSingleViewProviders.Text = "Agregar nuevo Providers";
            }


        }

        public int ProviderId 
        {
            get{return int.TryParse(TextProviderId.Text, out int id) ? id : 0; }

            set { TextProviderId.Text = value.ToString(); }
        }
        public string Name
        {
            get { return TextName.Text; }
            set{ TextName.Text = value.ToString(); }
        }
        public string Address
        {
            get { return TextAddress.Text; }
            set { TextAddress.Text = value.ToString(); }
        }

        
        public string PhoneNumber 
        {
            get { return TextPhoneNumber.Text; }
            set { TextPhoneNumber.Text = value.ToString(); }
        }
        public string Email 
        {
            get { return TextEmail.Text; }
            set { TextEmail.Text = value.ToString(); }
        }
        public string SearchValue 
        {
            get { return BuscarP.Text; }
            set { BuscarP.Text = value; }
        }
        public bool IsEdit 
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessful 
        {
            get { return isSuccesful; }
            set { isSuccesful = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        private void BuscarP_Click(object sender, EventArgs e)
        {
            // Invoca el evento SearchEvent que debe ser manejado por el presenter.
            SearchEvent?.Invoke(this, EventArgs.Empty);

            // Puedes añadir una lógica adicional si lo deseas, como mostrar un mensaje de búsqueda.
            MessageBox.Show("Se ha realizado la búsqueda.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NuevoP_Click(object sender, EventArgs e)
        {
            // Llama al evento para agregar una nueva categoría.
            AddNewEvent?.Invoke(this, EventArgs.Empty);

            // Cambia a la pestaña de detalles para agregar la nueva categoría.
            if (!tabControl1.TabPages.Contains(tabSingleViewProviders))
            {
                tabControl1.TabPages.Add(tabSingleViewProviders);
            }

            tabControl1.SelectedTab = tabSingleViewProviders;  // Selecciona la pestaña de detalles.
            tabSingleViewProviders.Text = "Agregar nuevo Providers";

            // Limpia los campos para asegurarse de que no haya datos previos.
            ProviderId = 0;  // Establece el ID en 0 para nuevos elementos.
            TextName.Text = string.Empty;
            TextAddress.Text = string.Empty;
            TextPhoneNumber.Text = string.Empty;
            TextEmail.Text = string.Empty;

        }

        private void EliminarP_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "¿Está seguro que desea eliminar el Provider seleccionado?",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Invoca el evento de eliminación.
                DeleteEvent?.Invoke(this, EventArgs.Empty);

                // Muestra un mensaje de éxito o maneja los errores si es necesario.
                if (IsSuccessful)
                {
                    MessageBox.Show("Provider eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SalirC_Click(object sender, EventArgs e)
        {
            // Cierra el formulario.
            this.Close();
        }

        public void SetProvidersListBildingSource(BindingSource providersList)
        {
            dataGridView1.DataSource = providersList;
        }
        private void GuardarP_Click(object sender, EventArgs e)
        {
            // Asegúrate de validar los campos
            if (string.IsNullOrWhiteSpace(TextName.Text) || string.IsNullOrWhiteSpace(TextAddress.Text))
            {
                MessageBox.Show("El nombre del proveedor y la dirección son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Invoca el evento SaveEvent que será manejado por el Presenter
            SaveEvent?.Invoke(this, EventArgs.Empty);

            // Verifica si la operación fue exitosa
            if (isSuccesful) // Si la operación de guardado fue exitosa
            {
                MessageBox.Show("Categoría guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Regresar a la pestaña principal de la lista
                tabControl1.TabPages.Remove(tabSingleViewProviders);
                tabControl1.TabPages.Add(tabListViewProviders);
            }
            else
            {
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
