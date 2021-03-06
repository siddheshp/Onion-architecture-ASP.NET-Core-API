﻿using Moq;
using NUnit.Framework;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contract;
using OnionArchitecture.Service.ImplementationBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Test.Unit.Service
{
    public class CustomerServiceTest
    {
        private CustomerService customerService;
        private Mock<IGenericRepository<Customer>> genericRepositoryMock;
        Customer customer;

        [SetUp]
        public void Setup()
        {
            genericRepositoryMock = new Mock<IGenericRepository<Customer>>();
            customerService = new CustomerService(genericRepositoryMock.Object);

            genericRepositoryMock.Setup(x => x.SaveChanges()).Returns(true);

            customer = new Customer
            {
                CustomerName = "Shweta Naik",
                Address = "Bangalore"
            };
        }

        [Test]
        public void CheckCustomerServiceAddCustomer()
        {
            customerService.AddCustomer(customer);
            var result = customerService.SaveChangesAsync();
            Assert.IsTrue(result);

        }

        [Test]
        public void CheckCustomerServiceDeleteCustomer()
        {
            customerService.DeleteCustomer(customer.Id);
            var result = customerService.SaveChangesAsync();
            Assert.IsTrue(result);

        }
    }
}
