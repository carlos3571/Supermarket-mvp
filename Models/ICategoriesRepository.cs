using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Models
{
    internal interface ICategoriesRepository
    {
        void Add(Categories categoriesModel);
        void Edit(Categories categoriesModel);
        void Delete(int id);
        IEnumerable<Categories> GetAll();
        IEnumerable<Categories> GetByValue(string value);
    }
}
