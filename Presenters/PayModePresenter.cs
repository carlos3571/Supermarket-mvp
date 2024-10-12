using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Supermarket_mvp.Views;
using Supermarket_mvp.Models;
using System.ComponentModel.DataAnnotations;

namespace Supermarket_mvp.Presenters
{
    internal class PayModePresenter
    {
        private IPayModeView view;
        private IPayModeRepository repository;
        private BindingSource payModeBindingSource;
        private IEnumerable<PayModeModel> payModeList;

        public PayModePresenter(IPayModeView view, IPayModeRepository repository)
        {
            this.payModeBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //this.view.SearchEvent += SearchPayMode;
            //this.view.AddNewEvent += AddNewPayMode;
            //this.view.EditEvent += LoadSelectPayModeToEdit;
            //this.view.SaveEvent += SavePayMode;
            //this.view.CancelEvent += CancelAction;
            this.view.AddNewEvent += AddNewPayMode;
            this.view.SaveEvent += SavePayMode;
            this.view.EditEvent += LoadSelectPayModeToEdit;
            this.view.DeleteEvent += DelectedSelectedPayMode;
            this.view.SearchEvent += SearchPayMode;
            this.view.CancelEvent += CancelAction;

            this.view.SetPayModeListBildingSource(payModeBindingSource);

            LoadAllPayModeList();
            this.view.Show();
        }

        private void LoadAllPayModeList()
        {
            payModeList = repository.GetAll();
            payModeBindingSource.DataSource = payModeList;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SavePayMode(object? sender, EventArgs e)
        {
            var payMode = new PayModeModel
            {
                Id = Convert.ToInt32(view.PayModeId),
                PayModeName = view.PayModeName,
                PayModeObservation = view.PayModeObservation
            };

            try
            {
                // Validación antes de guardar
                new Common.ModelDataValidation().Validate(payMode);

                if (view.IsEdit)
                {
                    repository.Edit(payMode);
                    view.Message = "Modo de pago editado exitosamente";
                }
                else
                {
                    repository.Add(payMode);
                    view.Message = "Modo de pago agregado exitosamente";
                }

                view.IsSuccessful = true;
                LoadAllPayModeList();
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
            view.PayModeId = "0";
            view.PayModeName = string.Empty;
            view.PayModeObservation = string.Empty;
        }

        private void LoadSelectPayModeToEdit(object? sender, EventArgs e)
        {
            // Se verifica que el objeto seleccionado no sea nulo.
            if (payModeBindingSource.Current == null)
            {
                view.Message = "No se ha seleccionado ningún modo de pago para editar.";
                return;
            }

            var payMode = (PayModeModel)payModeBindingSource.Current;

            // Asignar valores a los campos
            view.PayModeId = payMode.Id.ToString();
            view.PayModeName = payMode.PayModeName ?? string.Empty;
            view.PayModeObservation = payMode.PayModeObservation ?? string.Empty;

            view.IsEdit = true;
        }

        public void AddNewPayMode(object sender, EventArgs e)
        {
            // Asegúrate de que todas las propiedades existan en la vista
            view.PayModeId = "0"; // Establece el ID en 0 para nuevos elementos.
            view.PayModeName = string.Empty; // Limpia el campo de nombre.
            view.PayModeObservation = string.Empty; // Limpia el campo de observación.

            view.IsEdit = false; // Establece el modo de edición en falso.
        }

        private void SearchPayMode(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
            {
                payModeList = repository.GetByValue(this.view.SearchValue);
            }
            else
            {
                payModeList = repository.GetAll();
            }

            payModeBindingSource.DataSource = payModeList;
        }

        private void DelectedSelectedPayMode(object? sender, EventArgs e)
        {
            if (payModeBindingSource.Current == null)
            {
                view.Message = "No hay un modo de pago seleccionado para eliminar.";
                view.IsSuccessful = false;
                return;
            }

            try
            {
                // Se recupera el objeto de la fila seleccionada del dataviewgrid
                var payMode = (PayModeModel)payModeBindingSource.Current;

                // Se invoca el método Delete del repositorio pasando el ID del pay mode
                repository.Delete(payMode.Id);
                view.IsSuccessful = true;
                view.Message = "Modo de pago eliminado exitosamente";
                LoadAllPayModeList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = $"Ocurrió un error: {ex.Message}";
            }
        }
    }
}
