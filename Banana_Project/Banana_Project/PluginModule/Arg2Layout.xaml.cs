using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Banana_Project.PluginModule
{
    /// <summary>
    /// Arg2Layout.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Arg2Layout : UserControl, ArgLayout
    {
        public Arg2Layout()
        {
            InitializeComponent();
        }

        public Arg2Layout(String arg1)
        {
            InitializeComponent();

            Arg2_Name1.Text = arg1;
        }

        public Arg2Layout(String arg1, String arg2)
        {
            InitializeComponent();
            Arg2_Name1.Text = arg1;
            Arg2_Name2.Text = arg2;
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
