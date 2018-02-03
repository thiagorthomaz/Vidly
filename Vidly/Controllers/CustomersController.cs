using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            var c = new CustomersController();
            List<Customer> customers = c.List();

            return View(customers);
        }

        public ActionResult Details(int id) {

            Customer customer = findById(id);
            
            return View(customer);
        }


        public List<Customer> List() {


            var customers = new List<Customer>
            {
                    new Customer { Id = 1, Name = "John Smith" },
                    new Customer { Id = 2, Name = "Mary Williams" }
            };
            
            return customers;

        }

        public Customer findById(int _Id) {

            List<Customer> customers = List();
            Customer customer = customers.Find(x => x.Id == _Id);
            return customer;

        }
    }
}