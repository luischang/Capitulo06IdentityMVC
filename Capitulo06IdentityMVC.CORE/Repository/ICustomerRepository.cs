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
        IEnumerable<Customer> GetPaged(int pageNumber, int pageSize);
        IEnumerable<Customer> GetPagedByLastName(int pageNumber, int pageSize, string lastName);
        int GetCountByLastName(string lastName);

    }
}