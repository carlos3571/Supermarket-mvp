using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Models
{
    internal interface IProvidersRepository
    {
        void Add(Providers providersModel);
        void Edit(Providers providersModel);
        void Delete(int id);
        IEnumerable<Providers> GetAll();
        IEnumerable<Providers> GetByValue(string value);
    }
}
