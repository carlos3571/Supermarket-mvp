using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Supermarket_mvp.Views;
using Supermarket_mvp.Models;

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

            this.view.SearchEvent += SearchPayMode;
            this.view.AddNewEvent += AddNewPayMode;
            this.view.EditEvent += LoadSelectPayModeToEdit;
            this.view.SaveEvent += SavePayMode;
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
            var payMode = new PayModeModel();
            payMode.Id = Convert.ToInt32(view.PayModeId);
            payMode.Name = view.PayModeName;
            payMode.Observation = view.PayModeObservation;

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
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }


        private void CleanViewFields()
        {
            view.PayModeId = "0";
            view.PayModeName = "";
            view.PayModeObservation = "";
        }

        private void LoadSelectPayModeToEdit(object? sender, EventArgs e)
        {
            // Se verifica que el objeto seleccionado no sea nulo.
            if (payModeBindingSource.Current != null)
            {
                // Se obtiene el objeto del datagridview que se encuentra seleccionado.
                var payMode = (PayModeModel)payModeBindingSource.Current;

                // Se valida que los campos no sean nulos antes de asignarlos.
                view.PayModeId = payMode.Id.ToString();
                view.PayModeName = payMode.Name ?? string.Empty;
                view.PayModeObservation = payMode.Observation ?? string.Empty;

                // Se establece el modo como edición.
                view.IsEdit = true;
            }
            else
            {
                // Si no hay un modo de pago seleccionado, lanzar un mensaje de error o manejar la situación.
                view.Message = "No se ha seleccionado ningún modo de pago para editar.";
            }
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
            try
            {
                //se recupera el objeto de la fila seleccionada del dataviewgrid
                var payMode = (PayModeModel)payModeBindingSource.Current;

                //se invoca el metodo Delete del repositorio pasando el ID del pay mode
                repository.Delete(payMode.Id);
                view.IsSuccessful = true;
                view.Message = "modo de pago eliminado exitosamente";
                LoadAllPayModeList();
            }
            catch (Exception ex) 
            {
                view.IsSuccessful = false;
                view.Message = "ocurrió un error, no se pudo eliminar el modo de pago";
            }
            
            
        }
    }
}

