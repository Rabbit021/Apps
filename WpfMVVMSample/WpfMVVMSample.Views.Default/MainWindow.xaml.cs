using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfMVVMSample.ViewModels;

namespace WpfMVVMSample.Views.Default
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AllCustomerViewModel allCustomerViewModel = new AllCustomerViewModel();
            allCustomerViewModel.Selected += new EventHandler(allCustomerViewModel_Selected);
            allCustomerViewModel.GetAllCustomersCompleted += new EventHandler(allCustomerViewModel_GetAllCustomersCompleted);

            //可以触发加载进度条的动画........
            allCustomerViewModel.GetAllCustomers();
        }

        void allCustomerViewModel_GetAllCustomersCompleted(object sender, EventArgs e)
        {
            this.allcustomers.DataContext = sender;
            //加载结束，可以隐藏进度条
        }

        void allCustomerViewModel_Selected(object sender, EventArgs e)
        {
            CustomerViewModel customer = (sender as AllCustomerViewModel).SelectedCustomer;
            customer.Closed += new EventHandler(customer_Closed);
            this.customerView.DataContext = customer;
            VisualStateManager.GoToElementState(this.root, "Customer", true);
        }
        void customer_Closed(object sender, EventArgs e)
        {
            VisualStateManager.GoToElementState(this.root, "AllCustomers", true);
        }
    }
}
