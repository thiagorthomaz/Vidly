﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;
using System.Web.Http;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController() {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomers(string query = null) {
            var CustomersQuery = _context.Customers
                .Include(c => c.Membership);

            if (!String.IsNullOrWhiteSpace(query)) {
                CustomersQuery = CustomersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = CustomersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        public IHttpActionResult GetCustomer( int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else {
                return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            }

        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public CustomerDto UpdateCustomer(int id, CustomerDto customerDto) {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //var mapper = Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return customerDto;
        }

        [HttpDelete]
        public void DeleteCustomer(int id) {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();


        }

    }
}
