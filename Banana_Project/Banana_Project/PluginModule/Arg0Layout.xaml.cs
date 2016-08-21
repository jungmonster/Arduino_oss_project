using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Banana_Project.PluginModule
{
    /// <summary>
    /// Arg0Layout.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Arg0Layout : UserControl, ArgLayout
    {
        public Arg0Layout()
        {
            InitializeComponent();
        }

        public Arg0Layout(String arg1)
        {
            InitializeComponent();

            Arg0_Name1.Text = arg1;
        }


        private void RemoveBtn_Cilck(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(this) as DependencyObject;


            while (true)
            {
                Console.WriteLine(parent.GetType());
                if (parent == null)
                {
                    Console.WriteLine("Err : null point inception");
                    return;
                }
                if (parent.GetType() == typeof(ListBox))
                {
                    ListBox temp = parent as ListBox;
                    Console.WriteLine(temp.Uid);
                    temp.Items.Remove(this);
                    break;
                }
                parent = VisualTreeHelper.GetParent(parent) as DependencyObject;
            }
            ListBox listbox = parent as ListBox;
            if (listbox == null)
                MessageBox.Show("listbox is null");
            else
                listbox.Items.Remove(this);

        }
    }
}
