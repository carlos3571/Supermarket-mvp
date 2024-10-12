using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_mvp.Views
{
    public partial class PayModeView : Form, IPayModeView
    {
        // agregando propiedades
        private bool isEdit;
        private bool isSuccesful;
        private string message;

        public PayModeView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

            tabControl1.TabPages.Remove(tabPagePayModeDetail);
            BtnNew.Click += BtnNew_Click;
        }

        // métodos de la clase
        private void AssociateAndRaiseViewEvents()
        {
            //buscar llame  al metodo SearchEvent cuando se haga clic en el boton Btnsearch

            BtnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };

            TxtSearch.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        SearchEvent?.Invoke(this, EventArgs.Empty);
                    }
                };
            //agregar llame el evento AddNewEvent cuando se haga clic en el boton BtnNew
            BtnNew.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty); // Lanza el evento que será manejado en el Presenter.
                tabControl1.TabPages.Remove(tabPagePayModeList); // Oculta la lista de modos de pago.
                tabControl1.TabPages.Add(tabPagePayModeDetail); // Muestra la pestaña para agregar nuevo modo de pago.
                tabPagePayModeDetail.Text = "Agregar nuevo modo de pago"; // Cambia el título de la pestaña.
            };


            BtnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);

                tabControl1.TabPages.Remove(tabPagePayModeList);
                tabControl1.TabPages.Add(tabPagePayModeDetail);
                tabPagePayModeDetail.Text = "Editar modo de pago";
                //Camnia el tituloo de la pestaña
            };

            BtnDelete.Click += delegate
            {
                var result = MessageBox.Show(
                "Está seguro que desea eliminar el modo de pago seleccionado",
                "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("En instantes se eliminara ");
                }
            };

            BtnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);

                if (isSuccesful) //Si Grabar fue exitoso
                {
                    tabControl1.TabPages.Remove(tabPagePayModeList);
                    tabControl1.TabPages.Add(tabPagePayModeDetail);
                }
                MessageBox.Show("Se guardara proceso");
            };

            BtnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);

                tabControl1.TabPages.Remove(tabPagePayModeDetail);
                tabControl1.TabPages.Add(tabPagePayModeDetail);
            };

        }
        public string PayModeId
        {
            get { return TxtPayModeId.Text; }
            set { TxtPayModeId.Text = value; }
        }
        public string PayModeName
        {
            get { return TxtPayModeName.Text; }
            set { TxtPayModeName.Text = value; }
        }
        public string PayModeObservation
        {
            get { return TxtPayModeObservation.Text; }
            set { TxtPayModeObservation.Text = value; }
        }

        public string SearchValue
        {
            get { return TxtSearch.Text; }
            set { TxtSearch.Text = value; }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }  // Asignas el valor directamente a la variable privada
        }


        public bool IsSuccessful
        {
            get { return isSuccesful; }
            set { isSuccesful = value; }  // Aquí debes asignar a la variable `isSuccesful`
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        string IPayModeView.PayModeObservation
        {
            get { return TxtPayModeObservation.Text; }  // Asegúrate de que el control de texto exista en tu formulario
            set { TxtPayModeObservation.Text = value; }
        }

        public int DeleteSelectedEvent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

 

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetPayModeListBildingSource(BindingSource payModeList)
        {
            DgPayMode.DataSource = payModeList;
        }
        // Patron singleton para controlar solo una instancia del formulario        
        private static PayModeView _instance;

        public static PayModeView GetInstance(Form parentContainer)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new PayModeView();
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

        //private void PayModeView_Load(object sender, EventArgs e)
        //{
        //    tabControl1.TabPages.Add(tabPagePayModeDetail);
        //    tabPagePayModeDetail.Text = "Agregar nuevo modo de pago";
        //}
        private void PayModeView_Load(object sender, EventArgs e)
        {
            // Asegúrate de que la pestaña de detalles no esté visible al cargar el formulario
            if (tabControl1.TabPages.Contains(tabPagePayModeDetail))
            {
                tabControl1.TabPages.Remove(tabPagePayModeDetail);
            }
        }



        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "¿Está seguro que desea eliminar el modo de pago seleccionado?",
                "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Aquí llamas al evento de eliminación que será manejado por el presenter o lógica
                DeleteEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("El modo de pago será eliminado.");
            }
        }
        //private void BtnNew_Click(object sender, EventArgs e)
        //{
        //    AddNewEvent?.Invoke(this, EventArgs.Empty);

        //    tabControl1.TabPages.Remove(tabPagePayModeList);
        //    tabControl1.TabPages.Add(tabPagePayModeDetail);
        //    tabPagePayModeDetail.Text = "Agregar nuevo modo de pago";
        //}

        private void BtnNew_Click(object sender, EventArgs e)
        {
            // Llama al evento para iniciar la lógica de agregar nuevo modo de pago
            AddNewEvent?.Invoke(this, EventArgs.Empty);

            // Remueve la pestaña de lista si está visible
            if (tabControl1.TabPages.Contains(tabPagePayModeList))
            {
                tabControl1.TabPages.Remove(tabPagePayModeList);
            }

            // Asegúrate de que la pestaña de detalles se agrega solo una vez
            if (!tabControl1.TabPages.Contains(tabPagePayModeDetail))
            {
                tabControl1.TabPages.Add(tabPagePayModeDetail);
            }

            // Cambia el título de la pestaña de detalles
            tabPagePayModeDetail.Text = "Agregar nuevo modo de pago";
        }





    }
}
