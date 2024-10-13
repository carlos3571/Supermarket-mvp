using Supermarket_mvp._Repositories;
using Supermarket_mvp.Models;
using Supermarket_mvp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Presenters
{
    internal class ProvidersPresenter
    {
        private IProvidersView iProvidersView;
        private IProvidersRepository iProvidersRepository;
        private BindingSource providersBindingSource;
        private IEnumerable<Providers> providersList;

        public ProvidersPresenter(IProvidersView iPorvidersView, IProvidersRepository iProvidersRepository)
        {
            this.providersBindingSource = new BindingSource();
            this.iProvidersView = iPorvidersView;
            this.iProvidersRepository = iProvidersRepository;


            this.iProvidersView.AddNewEvent += AddNewPayMode;
            this.iProvidersView.SaveEvent += SaveCategory;
            this.iProvidersView.EditEvent += LoadSelectCategoryToEdit;
            this.iProvidersView.DeleteEvent += EliminarSelectedCategories;
            this.iProvidersView.SearchEvent += Buscar;
            this.iProvidersView.CancelEvent += CancelAction;

            this.iProvidersView.SetProvidersListBildingSource(providersBindingSource);

            LoadAllProvidersList();
            this.iProvidersView.Show();
        }
        private void LoadAllProvidersList()
        {
            providersList = iProvidersRepository.GetAll();
            providersBindingSource.DataSource = providersList;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveCategory(object sender, EventArgs e)
        {
            var providers = new Providers
            {
                ProviderId = iProvidersView.ProviderId,
                Name = iProvidersView.Name,
                Address = iProvidersView.Address,
                Email = iProvidersView.Email,
                PhoneNumber=iProvidersView.PhoneNumber,

            };

            try
            {
                if (iProvidersView.IsEdit)
                {
                    iProvidersRepository.Edit(providers);  // Se llama al método Edit del repositorio
                    iProvidersView.Message = "Categoría editada exitosamente.";
                }
                else
                {
                    iProvidersRepository.Add(providers);
                    iProvidersView.Message = "Categoría agregada exitosamente.";
                }

                iProvidersView.IsSuccessful = true;
                LoadAllProvidersList();  // Refrescar la lista después de guardar
                CleanViewFields();
            }
            catch (Exception ex)
            {
                iProvidersView.IsSuccessful = false;
                iProvidersView.Message = $"Error inesperado: {ex.Message}";
            }
        }



        private void CleanViewFields()
        {
            iProvidersView.ProviderId = 0;
            iProvidersView.Name = string.Empty;
            iProvidersView.Address = string.Empty;
            iProvidersView.Email = string.Empty; 
            iProvidersView.PhoneNumber = string.Empty;
        }

        private void LoadSelectCategoryToEdit(object? sender, EventArgs e)
        {
            if (providersBindingSource.Current == null)
            {
                iProvidersView.Message = "No se ha seleccionado ningún modo de pago para editar.";
                return;
            }

            var providers = (Providers)providersBindingSource.Current;
            iProvidersView.ProviderId = providers.ProviderId;
            iProvidersView.Name = providers.Name ?? string.Empty;
            iProvidersView.Address = providers.Address; 
            iProvidersView.Email = providers.Email;
            iProvidersView.PhoneNumber = providers.PhoneNumber;
            iProvidersView.IsEdit = true;
        }


        public void AddNewPayMode(object sender, EventArgs e)
        {
            // Asegúrate de que todas las propiedades existan en la vista
            iProvidersView.ProviderId = 0; // Establece el ID en 0 para nuevos elementos.
            iProvidersView.Name = string.Empty; // Limpia el campo de nombre.
            iProvidersView.Address = string.Empty; // Limpia el campo de observación.
            iProvidersView.PhoneNumber= string.Empty;
            iProvidersView.Email= string.Empty;
            iProvidersView.IsEdit = false; // Establece el modo de edición en falso.
        }

        private void Buscar(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.iProvidersView.SearchValue);
            if (emptyValue == false)
            {
                providersList = iProvidersRepository.GetByValue(this.iProvidersView.SearchValue);
            }
            else
            {
                providersList = iProvidersRepository.GetAll();
            }

            providersBindingSource.DataSource = providersList;
        }

        private void EliminarSelectedCategories(object? sender, EventArgs e)
        {
            if (providersBindingSource.Current == null)
            {
                iProvidersView.Message = "No hay un modo de pago seleccionado para eliminar.";
                iProvidersView.IsSuccessful = false;
                return;
            }

            try
            {
                // Se recupera el objeto de la fila seleccionada del dataviewgrid
                var categories = (Categories)providersBindingSource.Current;

                // Se invoca el método Delete del repositorio pasando el ID del pay mode
                iProvidersRepository.Delete(categories.CategoryId);
                iProvidersView.IsSuccessful = true;
                iProvidersView.Message = "Modo de pago eliminado exitosamente";
                LoadAllProvidersList();
            }
            catch (Exception ex)
            {
                iProvidersView.IsSuccessful = false;
                iProvidersView.Message = $"Ocurrió un error: {ex.Message}";
            }
        }
    }
}

