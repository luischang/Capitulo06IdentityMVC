using Capitulo06IdentityMVC.CORE.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo06IdentityMVC.CORE.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Customer> GetAll()
        {
            string query = "SELECT * FROM Customer";
            return _dbConnection.Query<Customer>(query);
        }

        public Customer GetById(int id)
        {
            var query = "SELECT * FROM Customer WHERE Id = @Id";
            return _dbConnection.QueryFirstOrDefault<Customer>(query, new { Id = id });
        }

        public void Add(Customer customer)
        {
            var query = "INSERT INTO Customer (FirstName, LastName, City, Country, Phone) VALUES (@FirstName,@LastName,@City,@Country,@Phone)";
            _dbConnection.Execute(query, new
            {
                customer.FirstName,
                customer.LastName,
                customer.City,
                customer.Country,
                customer.Phone
            });
        }

        public void Update(Customer customer)
        {
            var query = "UPDATE Customer SET FirstName= @FirstName, LastName= @LastName, Country= @Country, City=@City, Phone= @Phone WHERE Id = @Id";

            _dbConnection.Execute(query, new
            {
                customer.FirstName,
                customer.LastName,
                customer.City,
                customer.Country,
                customer.Phone,
                customer.Id
            });
        }

        public void Delete(int id)
        {
            var query = "DELETE FROM Customer WHERE Id = @Id";
            _dbConnection.Execute(query, new { Id = id });
        }

        public IEnumerable<Customer> GetPaged(int pageNumber, int pageSize)
        {
            int offset = (pageNumber - 1) * pageSize;
            string query = $"SELECT  * FROM  Customer ORDER BY Id OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return _dbConnection.Query<Customer>(query);
        }

        public IEnumerable<Customer> GetPagedByLastName(int pageNumber, int pageSize, string lastName)
        {
            int offset = (pageNumber - 1) * pageSize;
            string query = $"SELECT  * FROM  Customer WHERE LastName LIKE @lastName ORDER BY Id OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return _dbConnection.Query<Customer>(query, new { LastName = $"%{lastName}%"});
        }

        public int GetCountByLastName(string lastName)
        {
            string query = $"SELECT COUNT(*) FROM Customer WHERE LastName LIKE @lastName";
            return _dbConnection.ExecuteScalar<int>(query, new { LastName = $"%{lastName}%" });
        }

    }
}
