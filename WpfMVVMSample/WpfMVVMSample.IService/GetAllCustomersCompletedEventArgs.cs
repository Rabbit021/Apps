using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfMVVMSample.Models;

namespace WpfMVVMSample.IService
{
    public class GetAllCustomersCompletedEventArgs : EventArgs
    {
        public List<Customer> Customers;
        public GetAllCustomersCompletedEventArgs(List<Customer> customers)
        {
            this.Customers = customers;
        }
    }
}
