using System;
using WpfMVVMSample.Foundation;
using WpfMVVMSample.Models;

namespace WpfMVVMSample.IService
{
    /// <summary>
    /// IService示例
    /// 注意：此示例采用异步方法，所以方法有相应的回调事件
    /// </summary>
    public interface ICustomerService
    {
        event EventHandler CreateCustomerCompleted;
        void CreateCustomer(Customer customer);

        event EventHandler UpdateCustomerCompleted;
        void UpdateCustomer(Customer customer);

        event EventHandler DeleteCustomerCompleted;
        void DeleteCustomer(Customer customer);

        event EventHandler<GetAllCustomersCompletedEventArgs> GetAllCustomersCompleted;
        void GetAllCustomers();
    }
}
