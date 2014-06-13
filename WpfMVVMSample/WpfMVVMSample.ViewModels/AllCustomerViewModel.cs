using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using WpfMVVMSample.Foundation;
using WpfMVVMSample.IService;
using WpfMVVMSample.Models;

namespace WpfMVVMSample.ViewModels
{
    public class AllCustomerViewModel : ObservableObject
    {
        #region Service

        [Import(typeof(ICustomerService))]
        public ICustomerService Service { get; set; }

        #endregion

        #region 私有字段

        CustomerViewModel _selectedCustomer;

        #endregion

        #region 公共属性

        public ObservableCollection<CustomerViewModel> Customers
        {
            get;
            private set;
        }
        public CustomerViewModel SelectedCustomer
        {
            get { return this._selectedCustomer; }
            set
            {
                if (this._selectedCustomer != value)
                {
                    this._selectedCustomer = value;

                    this.Select();
                    base.RaisePropertyChanged("SelectedCustomer");
                }
            }
        }

        #endregion

        #region 事件

        public event EventHandler Selected;
        public event EventHandler GetAllCustomersCompleted;

        #endregion

        #region 方法

        public void GetAllCustomers()
        {
            if (this.Service != null)
            {
                this.Service.GetAllCustomersCompleted += (obj, arg) =>
                    {
                        this.Customers = new ObservableCollection<CustomerViewModel>();

                        foreach (Customer item in arg.Customers)
                        {
                            this.Customers.Add(new CustomerViewModel(item, false));
                        }

                        EventHandler handler = this.GetAllCustomersCompleted;
                        if (handler != null)
                        {
                            handler(this, EventArgs.Empty);
                        }
                    };
                this.Service.GetAllCustomers();
            }
        }

        #endregion

        #region 私有方法

        void Select()
        {
            //选择Item之后需要处理的业务操作，比如用户操作日志纪录

            EventHandler temp = this.Selected;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
