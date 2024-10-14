using Supermarket_mvp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            SalirC.Click += delegate { this.Close(); };

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
                EditEvent?.Invoke(this, EventArgs.Empty); // Esto debería invocar el método en el presenter.

                tabControl1.TabPages.Remove(tabListViewCategory);
                tabControl1.TabPages.Add(tabSingleViewCategory);
                tabSingleViewCategory.Text = "Editar categoría";

                IsEdit = true; // Aquí debe establecerse en true.
            };



            GuardarC.Click += delegate
            {
              

                if (string.IsNullOrWhiteSpace(txtCategoryName.Text.Trim()) || string.IsNullOrWhiteSpace(txtDescription.Text.Trim()))
                {
                    MessageBox.Show("Categoria are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                // Invoca el evento de guardado
                SaveEvent?.Invoke(this, EventArgs.Empty);

                // Verifica si la operación fue exitosa
                if (IsSuccessful)
                {
                    // Guardado exitoso, volver a la lista de modos de pago
                    tabControl1.TabPages.Remove(tabSingleViewCategory);
                    tabControl1.TabPages.Add(tabListViewCategory);
                    MessageBox.Show("Categoria successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CategoryView_Load(object sender, EventArgs e)
        {
            // Si estamos en modo de edición, se cargará la pestaña de edición
            if (isEdit)
            {
                if (!tabControl1.TabPages.Contains(tabSingleViewCategory))
                {
                    tabControl1.TabPages.Add(tabSingleViewCategory);
                }

                tabSingleViewCategory.Text = "Editar Categoria";
            }
            else
            {
                if (!tabControl1.TabPages.Contains(tabSingleViewCategory))
                {
                    tabControl1.TabPages.Add(tabSingleViewCategory);
                }

                tabSingleViewCategory.Text = "Agregar nueva categoria";
            }


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

        string ICategoriaView.Name 
        {
            get { return txtCategoryName.Text; }
            set { txtCategoryName.Text = value; }
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

        
        public void SetCategoryListBildingSource(BindingSource categoryList)
        {
            dataGridView1.DataSource = categoryList;
        }

        //private void GuardarC_Click(object sender, EventArgs e)
        //{
        //    // Validar que los campos no estén vacíos y que cumplan con las restricciones del modelo
        //    if (string.IsNullOrWhiteSpace(txtCategoryName.Text) || txtCategoryName.Text.Length < 3 || string.IsNullOrWhiteSpace(txtDescription.Text) || txtDescription.Text.Length < 3)
        //    {
        //        MessageBox.Show("El nombre de la categoría debe tener al menos 3 caracteres y la descripción también.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // Asignar los valores del formulario al modelo
        //    var categories = new Categories
        //    {
        //        Name = txtCategoryName.Text,
        //        Description = txtDescription.Text
        //    };

        //    // Invocar el evento de guardado, el presenter maneja la lógica de persistencia
        //    SaveEvent?.Invoke(this, EventArgs.Empty);

        //    // Verificar si la operación fue exitosa
        //    if (IsSuccessful)
        //    {
        //        MessageBox.Show("Categoría guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        tabControl1.TabPages.Remove(tabSingleViewCategory);
        //        tabControl1.TabPages.Add(tabListViewCategory);
        //    }
        //    else
        //    {
        //        MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void GuardarC_Click(object sender, EventArgs e)
        //{
        //    // Validar que el nombre de la categoría y la descripción no estén vacíos
        //    if (string.IsNullOrWhiteSpace(txtCategoryName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
        //    {
        //        MessageBox.Show("El nombre de la categoría y la descripción son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return; // Detener el proceso de guardado si los campos están vacíos
        //    }

        //    // Crear una instancia del modelo y asignar valores
        //    var categories = new Categories
        //    {
        //        CategoryId = int.TryParse(txtCategoryId.Text, out int id) ? id : 0,  // Asignar el ID de la categoría
        //        Name = txtCategoryName.Text,    // Asignar el nombre de la categoría
        //        Description = txtDescription.Text  // Asignar la descripción
        //    };

        //    // Aquí podrías realizar una validación de las anotaciones de datos si es necesario.
        //    var context = new ValidationContext(categories, null, null);
        //    var results = new List<ValidationResult>();
        //    if (!Validator.TryValidateObject(categories, context, results, true))
        //    {
        //        // Mostrar el primer error de validación encontrado
        //        MessageBox.Show(results[0].ErrorMessage, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // Invoca el evento de guardado, que debería manejar el presenter
        //    SaveEvent?.Invoke(this, EventArgs.Empty);

        //    // Verifica si la operación fue exitosa
        //    if (IsSuccessful)
        //    {
        //        MessageBox.Show("Categoría guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        tabControl1.TabPages.Remove(tabSingleViewCategory);
        //        tabControl1.TabPages.Add(tabListViewCategory);
        //    }
        //    else
        //    {
        //        MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void GuardarC_Click(object sender, EventArgs e)
        {
            // Asegúrate de validar los campos
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("El nombre de la categoría y la descripción son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Invoca el evento SaveEvent que será manejado por el Presenter
            SaveEvent?.Invoke(this, EventArgs.Empty);

            // Verifica si la operación fue exitosa
            if (isSuccesful) // Si la operación de guardado fue exitosa
            {
                MessageBox.Show("Categoría guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Regresar a la pestaña principal de la lista
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
