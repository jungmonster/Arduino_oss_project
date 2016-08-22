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
        private string plugName;
        private string menuName;
        public Arg1Layout(string plugName , string menuName)
        {
            InitializeComponent();
            this.plugName = plugName;
            this.menuName = menuName;
        }

        public Arg1Layout(string plugName, string menuName , string arg1) : this(plugName , menuName)
        {
            Arg1_Name1.Text = arg1;
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
