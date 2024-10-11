using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_mvp.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            BtnPayMode.Click += delegate { ShowPayModeView?.Invoke(this, EventArgs.Empty); };
           
        }
        public event EventHandler ShowPayModeView;
        public event EventHandler ShowproductView;
        public event EventHandler ShowProductView;
        public event EventHandler ShowCustomerView;
        public event EventHandler ShowOrderView;
        public event EventHandler ShowOrderDetailView;
        public event EventHandler ShowOrderDetailDetailDetailView;
        public event EventHandler ShowOrderDetailsView;
        public event EventHandler ShowOrderDetailsDetailDetailView;
        public event EventHandler ShowOrderDetailsDetailDetailDetailView;

       
    }
}
