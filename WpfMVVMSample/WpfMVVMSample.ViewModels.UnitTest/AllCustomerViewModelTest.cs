using WpfMVVMSample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WpfMVVMSample.ViewModels.UnitTest
{
    /// <summary>
    ///这是 AllCustomerViewModelTest 的测试类，旨在
    ///包含所有 AllCustomerViewModelTest 单元测试
    ///</summary>
    [TestClass()]
    public class AllCustomerViewModelTest
    {
        /// <summary>
        ///GetAllCustomers 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersTest()
        {
            AllCustomerViewModel target = new AllCustomerViewModel(); // TODO: 初始化为适当的值

            //可以根据构造的数据多少，确定方法是否正确执行，比如这里构造8条数据，则断言结果为8

            target.GetAllCustomersCompleted += (obj, arg) =>
            {
                Assert.IsNotNull(target.Customers);
                Assert.AreNotEqual(9, target.Customers.Count);
                Assert.AreEqual(8, target.Customers.Count);
            };
            target.GetAllCustomers();
        }
    }
}
