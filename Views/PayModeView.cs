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
        }

        // métodos de la clase
        private void AssociateAndRaiseViewEvents()
        {
            BtnSearch.Click += delegate
            {SearchEvent?.Invoke(this, EventArgs.Empty);};

        TxtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
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

        public static PayModeView GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new PayModeView();
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

    }
}
