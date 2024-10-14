using Supermarket_mvp.Models;
using Supermarket_mvp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Presenters
{
    internal class Productpresenter
    {

        private IProductView iProductView;
        private IProductRepository iProductRepository;
        private BindingSource productBindingSource;
        private IEnumerable<Product> productList;
        public Productpresenter(IProductView productView, IProductRepository repository)
        {
            this.productBindingSource = new BindingSource();
            this.iProductView = productView;
            this.iProductRepository = repository;


            this.iProductView.AddNewEvent += AddNewPayMode;
            this.iProductView.SaveEvent += SaveCategory;
            this.iProductView.EditEvent += LoadSelectCategoryToEdit;
            this.iProductView.DeleteEvent += EliminarSelectedCategories;
            this.iProductView.SearchEvent += Buscar;
            this.iProductView.CancelEvent += CancelAction;

            this.iProductView.SetProductListBildingSource(productBindingSource);

            LoadAllcategoryList();
            this.iProductView.Show();
        }
        private void LoadAllcategoryList()
        {
            productList = iProductRepository.GetAll();
            productBindingSource.DataSource = productList;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveCategory(object sender, EventArgs e)
        {
            var categories = new Product
            {
                CategoryId = iProductView.CategoryId,
                Name = iProductView.Name,
                Description = iProductView.Description
            };

            try
            {
                if (iProductView.IsEdit)
                {
                    iProductRepository.Edit(categories);  // Se llama al método Edit del repositorio
                    iProductView.Message = "Categoría editada exitosamente.";
                }
                else
                {
                    iProductRepository.Add(categories);
                    iProductView.Message = "Categoría agregada exitosamente.";
                }

                iProductView.IsSuccesful = true;
                LoadAllcategoryList();  // Refrescar la lista después de guardar
                CleanViewFields();
            }
            catch (Exception ex)
            {
                iProductView.IsSuccesful = false;
                iProductView.Message = $"Error inesperado: {ex.Message}";
            }
        }



        private void CleanViewFields()
        {
            iProductView.CategoryId = 0;
            iProductView.Name = string.Empty;
            iProductView.Description = string.Empty;
        }

        private void LoadSelectCategoryToEdit(object? sender, EventArgs e)
        {
            if (productBindingSource.Current == null)
            {
                iProductView.Message = "No se ha seleccionado ningún modo de pago para editar.";
                return;
            }

            var product = (Product)productBindingSource.Current;
            iProductView.ProducId = product.ProductId;
            iProductView.Name = product.Name ?? string.Empty;            
            iProductView.Description = product.Description ?? string.Empty;
            iProductView.Price= product.Price;
            iProductView.CategoryId = product.CategoryId;
            iProductView.IsEdit = true;
        }


        public void AddNewPayMode(object sender, EventArgs e)
        {
            // Asegúrate de que todas las propiedades existan en la vista
            iProductView.CategoryId = 0; // Establece el ID en 0 para nuevos elementos.
            iProductView.Name = string.Empty; // Limpia el campo de nombre.
            iProductView.Description = string.Empty; // Limpia el campo de observación.

            iProductView.IsEdit = false; // Establece el modo de edición en falso.
        }

        private void Buscar(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.iProductView.SearchValue);
            if (emptyValue == false)
            {
                productList = iProductRepository.GetByValue(this.iProductView.SearchValue);
            }
            else
            {
                productList = iProductRepository.GetAll();
            }

            productBindingSource.DataSource = productList;
        }

        private void EliminarSelectedCategories(object? sender, EventArgs e)
        {
            if (productBindingSource.Current == null)
            {
                iProductView.Message = "No hay un modo de pago seleccionado para eliminar.";
                iProductView.IsSuccesful = false;
                return;
            }

            try
            {
                // Se recupera el objeto de la fila seleccionada del dataviewgrid
                var categories = (Product)productBindingSource.Current;

                // Se invoca el método Delete del repositorio pasando el ID del pay mode
                iProductRepository.Delete(categories.CategoryId);
                iProductView.IsSuccesful = true;
                iProductView.Message = "Modo de pago eliminado exitosamente";
                LoadAllcategoryList();
            }
            catch (Exception ex)
            {
                iProductView.IsSuccesful = false;
                iProductView.Message = $"Ocurrió un error: {ex.Message}";
            }
        }
    }
   
}


