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
            BtnClose.Click += delegate { this.Close(); };
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
            BtnNew.Click += delegate {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePayModeList);
                tabControl1.TabPages.Add(tabPagePayModeDetail);
                tabPagePayModeDetail.Text = "Add New Pay Mode ";
                //Camnia el tituloo de la pestaña
            };

            BtnEdit.Click += delegate {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePayModeList);
                tabControl1.TabPages.Add(tabPagePayModeDetail);
                tabPagePayModeDetail.Text = "Edit Pay Mode";
                //Camnia el tituloo de la pestaña
            };

            BtnDelete.Click += delegate
            {
                var result = MessageBox.Show(
                "Are you sure you want to delete the selected Pay Mode",
                "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };

                BtnSave.Click += delegate {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccesful) //Si Grabar fue exitoso
                { 
                tabControl1.TabPages.Remove(tabPagePayModeList);
                tabControl1.TabPages.Add(tabPagePayModeDetail);
                }
                MessageBox.Show(Message);
            };

            BtnCancel.Click += delegate {
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
            set { IsEdit = value; }
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

        public string PayModeObdervation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public bool IsSuccessful { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        private void PayModeView_Load(object sender, EventArgs e)
        {

        }
    }
}
