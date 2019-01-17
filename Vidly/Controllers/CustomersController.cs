using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController() {
            this._context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = this.List();
            return View(customers);
        }

        public ActionResult Details(int id) {

            var customer = this._context.Customers.Include(c => c.Membership).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        public List<Customer> List() {
            return this._context.Customers.Include(c => c.Membership).ToList();
        }

    }
}