using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{

    public class CustomerRepository
    {
        Exer1DbContext db = new Exer1DbContext();

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Customer c)
        {
            db.Customers.Add(c);
            db.SaveChanges();
        }

        public void Update(Customer c)
        {
            var old = db.Customers.FirstOrDefault(x => x.Id == c.Id);
            if (old != null)
            {
                old.Name = c.Name;
                old.Email = c.Email;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var c = db.Customers.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                db.Customers.Remove(c);
                db.SaveChanges();
            }
        }
    }
}
