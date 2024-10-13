using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket_mvp.Views; 
using Supermarket_mvp.Models;
using Supermarket_mvp._Repositories;
using NuGet.Protocol.Plugins;


namespace Supermarket_mvp.Presenters
{
    internal class MainPresenter
    {
        private readonly IMainView mainView;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;

            this.mainView.ShowPayModeView += ShowPayModeview;
            this.mainView.ShowCategoriaView += ShowCategoriaView;
        }

       

        private void ShowPayModeview(object? sender, EventArgs e)
        {
            IPayModeView view = PayModeView.GetInstance((MainView)mainView);
            IPayModeRepository repository = new PayModeRepository(sqlConnectionString);
            new PayModePresenter(view, repository);
        }

        private void ShowCategoriaView(object? sender, EventArgs e)
        {
            ICategoriaView view= CategoryView.GetInstance((MainView)mainView);
            ICategoriesRepository repository = new CategoriesRepository(sqlConnectionString);
            new CategoryPresenter(view, repository);
        }


    }
}
 