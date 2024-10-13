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
    public partial class CategoryView : Form, ICategoriaView
    {

        private bool isEdit;
        private bool isSuccesful;
        private string message;

        public CategoryView()
        {
            InitializeComponent();
           
            AssociateAndRaiseViewEvents();

            tabControl1.TabPages.Remove(tabSingleViewCategory);
            NuevoC.Click += NuevoC_Click;
        }
        private void AssociateAndRaiseViewEvents()
        {
            //buscar llame  al metodo SearchEvent cuando se haga clic en el boton Btnsearch

            Buscar.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };

            Buscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };        



            //agregar llame el evento AddNewEvent cuando se haga clic en el boton BtnNew
            NuevoC.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);

                // Remueve la pestaña de lista si está presente
                if (tabControl1.TabPages.Contains(tabSingleViewCategory))
                {
                    tabControl1.TabPages.Remove(tabListViewCategory);
                }

                // Añade la pestaña de detalles si no está ya añadida
                if (!tabControl1.TabPages.Contains(tabSingleViewCategory))
                {
                    tabControl1.TabPages.Add(tabListViewCategory);
                }

                tabSingleViewCategory.Text = "Agregar nueva categoria";
            };




            EditarC.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);

                tabControl1.TabPages.Remove(tabListViewCategory);
                tabControl1.TabPages.Add(tabSingleViewCategory);
                tabListViewCategory.Text = "Editar modo de pago";
                //Camnia el tituloo de la pestaña
            };




            GuardarC.Click += delegate
            {
                // Verifica si los campos están vacíos antes de intentar guardar
                if (string.IsNullOrWhiteSpace(txtCategoryName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Pay Mode txtCategoryName and Pay Mode Observation are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detener el proceso de guardado
                }

                // Invoca el evento de guardado
                SaveEvent?.Invoke(this, EventArgs.Empty);

                // Verifica si la operación fue exitosa
                if (IsSuccessful)
                {
                    // Guardado exitoso, volver a la lista de modos de pago
                    tabControl1.TabPages.Remove(tabSingleViewCategory);
                    tabControl1.TabPages.Add(tabListViewCategory);
                    MessageBox.Show("Pay Mode saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };



            CancelarC.Click += delegate
            {
                // Cancelar y volver a la lista
                CancelEvent?.Invoke(this, EventArgs.Empty);

                tabControl1.TabPages.Remove(tabSingleViewCategory);
                tabControl1.TabPages.Add(tabListViewCategory);
            };

            






        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        private static CategoryView _instance;
        public static CategoryView GetInstance(Form parentContainer)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new CategoryView();
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
        public int CategoryId
        {
            get { return int.TryParse(textCategoryId.Text, out int id) ? id : 0; }
            set { textCategoryId.Text = value.ToString(); }
        }
        //string ICategoriaView.Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        // public string SearchValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SearchValue
        {
            get { return Buscar.Text; }
            set { Buscar.Text = value; }
        }
        //public bool IsEdit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        //public bool IsSuccessful { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
        //public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        private void Buscar_Click(object sender, EventArgs e)
        {
            // Invoca el evento SearchEvent que debe ser manejado por el presenter.
            SearchEvent?.Invoke(this, EventArgs.Empty);

            // Puedes añadir una lógica adicional si lo deseas, como mostrar un mensaje de búsqueda.
            MessageBox.Show("Se ha realizado la búsqueda.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NuevoC_Click(object sender, EventArgs e)
        {
            // Llama al evento para agregar una nueva categoría.
            AddNewEvent?.Invoke(this, EventArgs.Empty);

            // Cambia a la pestaña de detalles para agregar la nueva categoría.
            if (!tabControl1.TabPages.Contains(tabSingleViewCategory))
            {
                tabControl1.TabPages.Add(tabSingleViewCategory);
            }

            tabControl1.SelectedTab = tabSingleViewCategory;  // Selecciona la pestaña de detalles.
            tabSingleViewCategory.Text = "Agregar nueva categoría";

            // Limpia los campos para asegurarse de que no haya datos previos.
            CategoryId = 0;  // Establece el ID en 0 para nuevos elementos.
            txtCategoryName.Text = string.Empty;
            Description = string.Empty;
        }


        // Evento que se dispara al hacer clic en el botón de Editar.
        private void EditarC_Click(object sender, EventArgs e)
        {
            // Invoca el evento de edición.
            EditEvent?.Invoke(this, EventArgs.Empty);

            // Cambia a la pestaña de detalles para editar la categoría seleccionada.
            if (!tabControl1.TabPages.Contains(tabSingleViewCategory))
            {
                tabControl1.TabPages.Add(tabSingleViewCategory);
            }

            tabControl1.SelectedTab = tabSingleViewCategory;  // Selecciona la pestaña de detalles.
            tabSingleViewCategory.Text = "Editar categoría";

            // Asegúrate de que los campos se llenen con los valores seleccionados para editar.
        }


        private void EliminarC_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "¿Está seguro que desea eliminar la categoría seleccionada?",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Invoca el evento de eliminación.
                DeleteEvent?.Invoke(this, EventArgs.Empty);

                // Muestra un mensaje de éxito o maneja los errores si es necesario.
                if (IsSuccessful)
                {
                    MessageBox.Show("Categoría eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento que se dispara al hacer clic en el botón de Salir.
        private void SalirC_Click(object sender, EventArgs e)
        {
            // Cierra el formulario.
            this.Close();
        }

        //public void SetPayModeListBildingSource(BindingSource categoryList)
        //{
        //    throw new NotImplementedException();
        //}
        public void SetCategoryListBildingSource(BindingSource categoryList)
        {
            dataGridView1.DataSource = categoryList;
        }

        private void GuardarC_Click(object sender, EventArgs e)
        {
            // Validar campos antes de guardar
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("El nombre de la categoría y la descripción son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detener el proceso de guardado si hay un error
            }

            // Invoca el evento de guardado
            SaveEvent?.Invoke(this, EventArgs.Empty);

            // Verifica si la operación fue exitosa
            if (IsSuccessful)
            {
                MessageBox.Show("Categoría guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.TabPages.Remove(tabSingleViewCategory);
                tabControl1.TabPages.Add(tabListViewCategory);
            }
            else
            {
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
