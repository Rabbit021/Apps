using System;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using WpfMVVMSample.Foundation;
using WpfMVVMSample.Models;
using WpfMVVMSample.IService;

namespace WpfMVVMSample.ViewModels
{
    public class CustomerViewModel : ObservableObject, IDataErrorInfo
    {
        #region 私有字段

        readonly Customer _customer;
        bool _isNewCustomer;
        ICommand _saveCommand;
        ICommand _deleteCommand;

        [Import(typeof(ICustomerService))]
        public ICustomerService CustomerService { get; set; }

        #endregion

        #region 构造函数

        public CustomerViewModel(Customer customer, bool isNewCustomer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            this._isNewCustomer = isNewCustomer;
            this._customer = customer;
        }

        #endregion

        #region 自定义ViewModel属性

        public string Email
        {
            get { return _customer.Email; }
            set
            {
                if (value == _customer.Email)
                    return;

                _customer.Email = value;
                base.RaisePropertyChanged("Email");
            }
        }
        public string Name
        {
            get { return _customer.Name; }
            set
            {
                if (value == _customer.Name)
                    return;

                _customer.Name = value;
                base.RaisePropertyChanged("Name");
            }
        }
        public string Image
        {
            get { return _customer.Image; }
            set
            {
                if (value == _customer.Image)
                    return;

                _customer.Image = value;
                base.RaisePropertyChanged("TotalSales");
            }
        }

        #endregion

        #region IDataErrorInfo接口实现

        string IDataErrorInfo.Error
        {
            get { return (_customer as IDataErrorInfo).Error; }
        }
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return (_customer as IDataErrorInfo)[propertyName];
            }
        }

        #endregion

        #region 事件

        //ViewModel里面的事件，一般来说都是通知View做相应的UI的操作
        public event EventHandler Closed;

        #endregion

        #region 命令

        public ICommand SaveCommand
        {
            get
            {
                if (this._saveCommand == null)
                {
                    this._saveCommand = new RelayCommand(
                        () => this.Save(),
                        () => this.CanSave);
                }

                return this._saveCommand;
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                if (this._deleteCommand == null)
                {
                    this._deleteCommand = new RelayCommand(
                      () => this.Delete(),
                         () => this.CanDelete);
                }

                return this._deleteCommand;
            }
        }

        #endregion

        #region 对View可见的公共方法

        public void Close()
        {
            //关闭之前的逻辑操作

            this.RaiseClosed();
        }

        #endregion

        #region 私有方法

        void Save()
        {
            //新建或者更新操作，此处略去100行代码

            this.RaiseClosed();
        }
        bool CanSave
        {
            get { return this._customer.IsValid; }
        }

        void Delete()
        {
            //删除操作，此处略去100行代码

            this.RaiseClosed();
        }
        bool CanDelete { get { return true; } }

        void RaiseClosed()
        {
            var handler = this.Closed;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion
    }
}
