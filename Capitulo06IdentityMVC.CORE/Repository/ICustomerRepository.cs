using Capitulo06IdentityMVC.CORE.Model;
using System.Collections.Generic;

namespace Capitulo06IdentityMVC.CORE.Repository
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Delete(int id);
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Update(Customer customer);
    }
}