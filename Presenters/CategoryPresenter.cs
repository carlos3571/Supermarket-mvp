using Supermarket_mvp._Repositories;
using Supermarket_mvp.Models;
using Supermarket_mvp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_mvp.Presenters
{
    internal class CategoryPresenter
    {
        private ICategoriaView iCategoryView;
        private ICategoriesRepository iCategoryRepository;
        private BindingSource categoryBindingSource;
        private IEnumerable<Categories> categoryList;
        public CategoryPresenter(ICategoriaView view, ICategoriesRepository repository)
        {
            this.categoryBindingSource = new BindingSource();
            this.iCategoryView = view;
            this.iCategoryRepository = repository;


            this.iCategoryView.AddNewEvent += AddNewPayMode;
            this.iCategoryView.SaveEvent += SaveCategory;
            this.iCategoryView.EditEvent += LoadSelectCategoryToEdit;
            this.iCategoryView.DeleteEvent += EliminarSelectedCategories;
            this.iCategoryView.SearchEvent += Buscar;
            this.iCategoryView.CancelEvent += CancelAction;

            this.iCategoryView.SetCategoryListBildingSource(categoryBindingSource);

            LoadAllcategoryList();
            this.iCategoryView.Show();
        }
        private void LoadAllcategoryList()
        {
            categoryList = iCategoryRepository.GetAll();
            categoryBindingSource.DataSource = categoryList;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveCategory(object sender, EventArgs e)
        {
            var categories = new Categories
            {
                CategoryId = iCategoryView.CategoryId,
                Name = iCategoryView.Name,
                Description = iCategoryView.Description
            };

            try
            {
                if (iCategoryView.IsEdit)
                {
                    iCategoryRepository.Edit(categories);  // Se llama al método Edit del repositorio
                    iCategoryView.Message = "Categoría editada exitosamente.";
                }
                else
                {
                    iCategoryRepository.Add(categories);
                    iCategoryView.Message = "Categoría agregada exitosamente.";
                }

                iCategoryView.IsSuccessful = true;
                LoadAllcategoryList();  // Refrescar la lista después de guardar
                CleanViewFields();
            }
            catch (Exception ex)
            {
                iCategoryView.IsSuccessful = false;
                iCategoryView.Message = $"Error inesperado: {ex.Message}";
            }
        }



        private void CleanViewFields()
        {
            iCategoryView.CategoryId = 0;
            iCategoryView.Name = string.Empty;
            iCategoryView.Description = string.Empty;
        }

        private void LoadSelectCategoryToEdit(object? sender, EventArgs e)
        {
            if (categoryBindingSource.Current == null)
            {
                iCategoryView.Message = "No se ha seleccionado ningún modo de pago para editar.";
                return;
            }

            var categories = (Categories)categoryBindingSource.Current;
            iCategoryView.CategoryId = categories.CategoryId;
            iCategoryView.Name = categories.Name ?? string.Empty;
            iCategoryView.Description = categories.Description ?? string.Empty;
            iCategoryView.IsEdit = true;
        }


        public void AddNewPayMode(object sender, EventArgs e)
        {
            // Asegúrate de que todas las propiedades existan en la vista
            iCategoryView.CategoryId = 0; // Establece el ID en 0 para nuevos elementos.
            iCategoryView.Name = string.Empty; // Limpia el campo de nombre.
            iCategoryView.Description = string.Empty; // Limpia el campo de observación.

            iCategoryView.IsEdit = false; // Establece el modo de edición en falso.
        }

        private void Buscar(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.iCategoryView.SearchValue);
            if (emptyValue == false)
            {
                categoryList = iCategoryRepository.GetByValue(this.iCategoryView.SearchValue);
            }
            else
            {
                categoryList = iCategoryRepository.GetAll();
            }

            categoryBindingSource.DataSource = categoryList;
        }

        private void EliminarSelectedCategories(object? sender, EventArgs e)
        {
            if (categoryBindingSource.Current == null)
            {
                iCategoryView.Message = "No hay un modo de pago seleccionado para eliminar.";
                iCategoryView.IsSuccessful = false;
                return;
            }

            try
            {
                // Se recupera el objeto de la fila seleccionada del dataviewgrid
                var categories = (Categories)categoryBindingSource.Current;

                // Se invoca el método Delete del repositorio pasando el ID del pay mode
                iCategoryRepository.Delete(categories.CategoryId);
                iCategoryView.IsSuccessful = true;
                iCategoryView.Message = "Modo de pago eliminado exitosamente";
                LoadAllcategoryList();
            }
            catch (Exception ex)
            {
                iCategoryView.IsSuccessful = false;
                iCategoryView.Message = $"Ocurrió un error: {ex.Message}";
            }
        }
    }
}
    

