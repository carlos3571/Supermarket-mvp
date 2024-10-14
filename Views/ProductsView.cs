using Supermarket_mvp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_mvp.Views
{
    public partial class ProductsView : Form, IProductView
    {

        private bool isEdit;
        private bool isSuccesful;
        private string message;
        public ProductsView()
        {
            InitializeComponent();

            AssociateAndRaiseViewEvents();

            tabControl1.TabPages.Remove(tabSingleViewProduct);
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
                if (tabControl1.TabPages.Contains(tabSingleViewProduct))
                {
                    tabControl1.TabPages.Remove(tabListViewProduct);
                }

                // Añade la pestaña de detalles si no está ya añadida
                if (!tabControl1.TabPages.Contains(tabSingleViewProduct))
                {
                    tabControl1.TabPages.Add(tabListViewProduct);
                }

                tabSingleViewProduct.Text = "Agregar nuevo Providers";
            };
            EditarP.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty); // Esto debería invocar el método en el presenter.

                tabControl1.TabPages.Remove(tabListViewProduct);
                tabControl1.TabPages.Add(tabSingleViewProduct);
                tabSingleViewProduct.Text = "Editar Providers";

                isEdit = true; // Aquí debe establecerse en true.
            };

            GuardarP.Click += delegate
            {


                if (string.IsNullOrWhiteSpace(TextName.Text.Trim()) || string.IsNullOrWhiteSpace(TextDescription.Text.Trim()))
                {
                    MessageBox.Show("Provider are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Invoca el evento de guardado
                SaveEvent?.Invoke(this, EventArgs.Empty);

                // Verifica si la operación fue exitosa
                if (IsSuccesful)
                {
                    // Guardado exitoso, volver a la lista de modos de pago
                    tabControl1.TabPages.Remove(tabSingleViewProduct);
                    tabControl1.TabPages.Add(tabListViewProduct);
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

                tabControl1.TabPages.Remove(tabSingleViewProduct);
                tabControl1.TabPages.Add(tabListViewProduct);
            };



        }

        private static ProductsView _instance;
        public static ProductsView GetInstance(Form parentContainer)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new ProductsView();
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
                if (!tabControl1.TabPages.Contains(tabListViewProduct))
                {
                    tabControl1.TabPages.Add(tabListViewProduct);
                }

                tabSingleViewProduct.Text = "Editar producto";
            }
            else
            {
                if (!tabControl1.TabPages.Contains(tabSingleViewProduct))
                {
                    tabControl1.TabPages.Add(tabSingleViewProduct);
                }

                tabSingleViewProduct.Text = "Agregar nuevo producto";
            }


        }
        public int ProducId
        {
            get { return int.TryParse(TextProductId.Text, out int id) ? id : 0; }

            set { TextProductId.Text = value.ToString(); }
        }
        public string Name
        {
            get { return TextName.Text; }
            set { TextName.Text = value.ToString(); }
        }

        public decimal Price
        {
            get
            {
                // Intentar convertir el texto a decimal. Si falla, devolver 0 o algún valor por defecto.
                if (decimal.TryParse(TextPrice.Text, out decimal price))
                {
                    return price;
                }
                else
                {
                    return 0; // o algún valor que tenga sentido en tu contexto
                }
            }
            set
            {
                // Convertir el valor decimal a string
                TextPrice.Text = value.ToString("F2"); // F2 para 2 decimales, puedes ajustar el formato si es necesario
            }
        }

        public string Description
        {
            get { return TextDescription.Text; }
            set { TextDescription.Text = value.ToString(); }
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
        public bool IsSuccesful
        {
            get { return isSuccesful; }
            set { isSuccesful = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        
       
        public int CategoryId 
        {
            get { return int.TryParse(TextCategoryId.Text, out int id) ? id : 0; }
            set { TextProductId.Text = value.ToString(); }
        }
        public bool IsSuccessful
        {
            get { return isSuccesful; }
            set { isSuccesful = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;


        

        public void SetProductListBildingSource(BindingSource productList)
        {
            dataGridView1.DataSource = productList;
        }

        private void NuevoP_Click(object sender, EventArgs e)
        {
            // Llama al evento para agregar una nueva categoría.
            AddNewEvent?.Invoke(this, EventArgs.Empty);

            // Cambia a la pestaña de detalles para agregar la nueva categoría.
            if (!tabControl1.TabPages.Contains(tabSingleViewProduct))
            {
                tabControl1.TabPages.Add(tabSingleViewProduct);
            }

            tabControl1.SelectedTab = tabSingleViewProduct;  // Selecciona la pestaña de detalles.
            tabSingleViewProduct.Text = "Agregar nuevo Providers";

            // Limpia los campos para asegurarse de que no haya datos previos.
            ProducId = 0;  // Establece el ID en 0 para nuevos elementos.
            TextName.Text = string.Empty;
            TextDescription.Text = string.Empty;
            TextPrice.Text = string.Empty;
            CategoryId =0;

        }


        private void BuscarP_Click(object sender, EventArgs e)
        {
            // Invoca el evento SearchEvent que debe ser manejado por el presenter.
            SearchEvent?.Invoke(this, EventArgs.Empty);

            // Puedes añadir una lógica adicional si lo deseas, como mostrar un mensaje de búsqueda.
            MessageBox.Show("Se ha realizado la búsqueda.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void EliminarP_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "¿Está seguro que desea eliminar el Prodcuto selecionado seleccionado?",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Invoca el evento de eliminación.
                DeleteEvent?.Invoke(this, EventArgs.Empty);

                // Muestra un mensaje de éxito o maneja los errores si es necesario.
                if (IsSuccessful)
                {
                    MessageBox.Show("Prodcuto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
