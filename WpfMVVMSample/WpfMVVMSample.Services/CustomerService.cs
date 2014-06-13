using System;
using System.Linq;
using System.Collections.Generic;
using WpfMVVMSample.Models;
using WpfMVVMSample.IService;
using System.ComponentModel.Composition;

namespace WpfMVVMSample.Services
{
    /// <summary>
    /// 数据访问服务类实现示例
    /// </summary>
    [Export(typeof(ICustomerService))]
    public class CustomerService : ICustomerService
    {
        public CustomerService() { }

        //添加WCF客户端的引用
        //CustomerServiceReference.CustomerServiceClient client = new CustomerServiceReference.CustomerServiceClient();

        public event EventHandler CreateCustomerCompleted;
        public void CreateCustomer(Customer customer)
        {

        }

        public event EventHandler UpdateCustomerCompleted;
        public void UpdateCustomer(Customer customer)
        {

        }

        public event EventHandler DeleteCustomerCompleted;
        public void DeleteCustomer(Customer customer)
        {

        }

        public event EventHandler<GetAllCustomersCompletedEventArgs> GetAllCustomersCompleted;
        public void GetAllCustomers()
        {
            //DataServiceQuery<CustomerServiceReference.Customer> query =
            //    (DataServiceQuery<CustomerServiceReference.Customer>)(from f in client.GetAllCustomers()
            //                                                          select f);


            //try
            //{
            //    query.BeginExecute(OnGetAllCustomersComplete, query);
            //}
            //catch (DataServiceQueryException ex)
            //{
            //    throw new ApplicationException("An error occurred during query execution.", ex);
            //}

            OnGetAllCustomersComplete(null);
        }
        void OnGetAllCustomersComplete(IAsyncResult result)
        {
            List<Customer> list = new List<Customer>();
            list.Add(new Customer() { Name = "Elvis", Email = "elvis@live.com", Image = "Images/1.png" });
            list.Add(new Customer() { Name = "Frank", Email = "Frank@live.com", Image = "Images/2.png" });
            list.Add(new Customer() { Name = "Evan", Email = "Evan@live.com", Image = "Images/3.png" });
            list.Add(new Customer() { Name = "Bob", Email = "bob@live.com", Image = "Images/4.png" });
            list.Add(new Customer() { Name = "Squall", Email = "Squall@live.com", Image = "Images/5.png" });
            list.Add(new Customer() { Name = "Evan", Email = "Evan@live.com", Image = "Images/6.png" });
            list.Add(new Customer() { Name = "Bob", Email = "bob@live.com", Image = "Images/7.png" });
            list.Add(new Customer() { Name = "Squall", Email = "Squall@live.com", Image = "Images/8.png" });

            //DataServiceQuery<CustomerServiceReference.Customer> query = result as DataServiceQuery<CustomerServiceReference.Customer>;
            //foreach (CustomerServiceReference.Customer customer in query.EndExecute(result))
            //{

            //    this.customers.Add(
            //        new Customer()
            //        {
            //            Email = customer.Email,
            //            Name = customer.Name,
            //            Image = customer.Image
            //        });
            //}

            EventHandler<GetAllCustomersCompletedEventArgs> temp = this.GetAllCustomersCompleted;
            if (temp != null)
            {
                temp(this, new GetAllCustomersCompletedEventArgs(list));
            }
        }
    }
}
