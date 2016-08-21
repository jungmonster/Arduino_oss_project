using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Banana_Project.PluginModule
{
    /// <summary>
    /// Arg1Layout.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Arg1Layout : UserControl, ArgLayout
    {
        public Arg1Layout()
        {
            InitializeComponent();
        }

        public Arg1Layout(string arg1)
        {
            InitializeComponent();
            MessageBox.Show(arg1);
            Arg1_Name1.Text = arg1;
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
