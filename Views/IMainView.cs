using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Views
{
    internal interface IMainView
    {
        event EventHandler ShowPayModeView;
        event EventHandler ShowProductView;
        event EventHandler ShowCustomerView;
        /*event EventHandler ShowOrderView;
        event EventHandler ShowOrderDetailView;
        event EventHandler ShowOrderDetailDetailDetailView;
        event EventHandler ShowOrderDetailsView;
        event EventHandler ShowOrderDetailsDetailDetailView;
        event EventHandler ShowOrderDetailsDetailDetailDetailView;*/

        
    }
}
