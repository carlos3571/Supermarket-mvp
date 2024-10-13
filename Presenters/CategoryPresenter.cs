using Supermarket_mvp.Models;
using Supermarket_mvp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Presenters
{
    internal class CategoryPresenter
    {
        private ICategoriaView view;
        private ICategoriesRepository repository;
        private BindingSource categoryBindingSource;
        private IEnumerable<Categories> categoryList;
        public CategoryPresenter(ICategoriaView view, ICategoriesRepository repository)
        {
            this.categoryBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;


            this.view.AddNewEvent += AddNewPayMode;
            this.view.SaveEvent += SavePayMode;
            this.view.EditEvent += LoadSelectPayModeToEdit;
            this.view.DeleteEvent += EliminarSelectedCategories;
            this.view.SearchEvent += Buscar;
            this.view.CancelEvent += CancelAction;

            this.view.SetCategoryListBildingSource(categoryBindingSource);

            LoadAllcategoryList();
            this.view.Show();
        }
        private void LoadAllcategoryList()
        {
            categoryList = repository.GetAll();
            categoryBindingSource.DataSource = categoryList;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SavePayMode(object? sender, EventArgs e)
        {
            var categories = new Categories
            {
                CategoryId = Convert.ToInt32(view.CategoryId),
                Name = view.Name,
                Description = view.Description
            };

            try
            {
                // Validación antes de guardar
                new Common.ModelDataValidation().Validate(categories);

                if (view.IsEdit)
                {
                    repository.Edit(categories);
                    view.Message = "Categoria editada exitosamente";
                }
                else
                {
                    repository.Add(categories);
                    view.Message = "Categoria  agregada exitosamente";
                }

                view.IsSuccessful = true;
                LoadAllcategoryList();
                CleanViewFields();
            }
            catch (ValidationException ex)
            {
                view.IsSuccessful = false;
                view.Message = $"Error de validación: {ex.Message}";
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = $"Error inesperado: {ex.Message}";
            }
        }

        private void CleanViewFields()
        {
            view.CategoryId = 0;
            view.Name = string.Empty;
            view.Description = string.Empty;
        }

        private void LoadSelectPayModeToEdit(object? sender, EventArgs e)
        {
            // Se verifica que el objeto seleccionado no sea nulo.
            if (categoryBindingSource.Current == null)
            {
                view.Message = "No se ha seleccionado ningún modo de pago para editar.";
                return;
            }

            var categories = (Categories)categoryBindingSource.Current;

            // Asignar valores a los campos
            view.CategoryId = categories.CategoryId;
            view.Name = categories.Name ?? string.Empty;
            view.Description = categories.Description ?? string.Empty;

            view.IsEdit = true;
        }

        public void AddNewPayMode(object sender, EventArgs e)
        {
            // Asegúrate de que todas las propiedades existan en la vista
            view.CategoryId = 0; // Establece el ID en 0 para nuevos elementos.
            view.Name = string.Empty; // Limpia el campo de nombre.
            view.Description = string.Empty; // Limpia el campo de observación.

            view.IsEdit = false; // Establece el modo de edición en falso.
        }

        private void Buscar(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
            {
                categoryList = repository.GetByValue(this.view.SearchValue);
            }
            else
            {
                categoryList = repository.GetAll();
            }

            categoryBindingSource.DataSource = categoryList;
        }

        private void EliminarSelectedCategories(object? sender, EventArgs e)
        {
            if (categoryBindingSource.Current == null)
            {
                view.Message = "No hay un modo de pago seleccionado para eliminar.";
                view.IsSuccessful = false;
                return;
            }

            try
            {
                // Se recupera el objeto de la fila seleccionada del dataviewgrid
                var categories = (Categories)categoryBindingSource.Current;

                // Se invoca el método Delete del repositorio pasando el ID del pay mode
                repository.Delete(categories.CategoryId);
                view.IsSuccessful = true;
                view.Message = "Modo de pago eliminado exitosamente";
                LoadAllcategoryList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = $"Ocurrió un error: {ex.Message}";
            }
        }
    }
}
    

