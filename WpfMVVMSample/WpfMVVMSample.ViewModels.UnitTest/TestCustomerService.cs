using System;
using System.Linq;
using System.Collections.Generic;
using WpfMVVMSample.ViewModels;
using WpfMVVMSample.Models;
using WpfMVVMSample.IService;
using System.ComponentModel.Composition;

namespace WpfMVVMSample.ViewModels.UnitTest
{
    /// <summary>
    /// 数据访问服务类测试实现示例
    /// </summary>
    [Export(typeof(ICustomerService))]
    public class TestCustomerService : ICustomerService
    {
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
            List<Customer> list = new List<Customer>();
            list.Add(new Customer() { Name = "Elvis", Email = "elvis@live.com", Image = "Images/1.png" });
            list.Add(new Customer() { Name = "Frank", Email = "Frank@live.com", Image = "Images/2.png" });
            list.Add(new Customer() { Name = "Evan", Email = "Evan@live.com", Image = "Images/3.png" });
            list.Add(new Customer() { Name = "Bob", Email = "bob@live.com", Image = "Images/4.png" });
            list.Add(new Customer() { Name = "Squall", Email = "Squall@live.com", Image = "Images/5.png" });
            list.Add(new Customer() { Name = "Evan", Email = "Evan@live.com", Image = "Images/6.png" });
            list.Add(new Customer() { Name = "Bob", Email = "bob@live.com", Image = "Images/7.png" });
            list.Add(new Customer() { Name = "Squall", Email = "Squall@live.com", Image = "Images/8.png" });

            EventHandler<GetAllCustomersCompletedEventArgs> temp = this.GetAllCustomersCompleted;
            if (temp != null)
            {
                temp(this, new GetAllCustomersCompletedEventArgs(list));
            }
        }
    }
}
