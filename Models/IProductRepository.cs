using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Models
{
    internal interface IProductRepository
    {
        void Add(Product producModel);
        void Edit(Product producModel);
        void Delete(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByValue(string value);
    }
}

