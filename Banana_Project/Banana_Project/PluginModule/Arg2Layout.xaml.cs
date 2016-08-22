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
        private string plugName = null;
        private string menuName = null; 

        public Arg2Layout(string _plugName , string _menuName)
        {
            InitializeComponent();
            plugName = _plugName;
            menuName = _menuName;
        }

        public Arg2Layout(string _plugName, string _menuName , String arg1) : this(_plugName , _menuName)
        {
            Arg2_Name1.Text = arg1;
        }

        public Arg2Layout(string _plugName, string _menuName , String arg1, String arg2) : this(_plugName, _menuName)
        {
            Arg2_Name1.Text = arg1;
            Arg2_Name2.Text = arg2;
        }

        public string Filename
        {
            get
            {
                return plugName;
            }
        }

        public string Menuname
        {
            get
            {
                return menuName;
            }
        }

        public string Arg1
        {
            get
            {
                return Arg1_Content1.Text;
            }
        }

        public string Arg2
        {
            get
            {
                return Arg2_Content2.Text;
            }
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
