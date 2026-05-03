using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
 
    public class CustomerService
    {
        CustomerRepository repo = new CustomerRepository();

        public List<Customer> GetAll()
        {
            return repo.GetAll();
        }

        public Customer Get(int id)
        {
            return repo.Get(id);
        }

        public void Add(Customer c)
        {
            repo.Add(c);
        }

        public void Update(Customer c)
        {
            repo.Update(c);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}
