using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            var membershipType = this._context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };

            return View("CustomerForm", viewModel);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) {

            if (!ModelState.IsValid) {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = this._context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                this._context.Customers.Add(customer);
            }
            else {
                var customerInDb = this._context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipId = customer.MembershipId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }

            this._context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {

            var customer = this._context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) {
                return HttpNotFound();
            }


            CustomerFormViewModel viewModel = new CustomerFormViewModel {
                Customer = customer,
                MembershipTypes = this._context.MembershipTypes.ToList()
            };
            

            return View("CustomerForm", viewModel);
        }



    }
}