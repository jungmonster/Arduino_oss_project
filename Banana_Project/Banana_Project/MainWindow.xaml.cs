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
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections;

namespace Banana_Project
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        ListBox dragSource = null;
        ObservableCollection<string> zoneList = new ObservableCollection<string>();
        ObservableCollection<string> nodeObjectList = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            NodeList.MouseDown += NodeListView_MouseDown;

            // Node List 높이를 지정하기 위해 설정... 이후 size가 변화될때마다 새로 설정이 필요함
            NodeList.Height = this.Height - 70;
            this.SizeChanged += new SizeChangedEventHandler(MainWindow_SizeChange);


            //NodeList.ItemsSource = zoneList;

            SetNodeList();
        }

        // Node 추가 할 리스트 설정
        void SetNodeList()
        {
            nodeObjectList.Add("Wifi Shield");
            nodeObjectList.Add("Switch");
            nodeObjectList.Add("Button");
            NodeList.ItemsSource = nodeObjectList;
        }  
        
        //  windows size 변화에 따라 ListView Height 변경
        void MainWindow_SizeChange(object sender, SizeChangedEventArgs e)
        {
            NodeList.Height = this.Height - 70;
        }

        #region Drag&Drop
        void NodeListView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Node Click");
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListView (dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }
        

        void CodeNode_Drop(object sender, DragEventArgs e)
        {
            Console.WriteLine("Drop event");
            ListView parent = (ListView)sender;
            object data = e.Data.GetData(typeof(string));
            Console.WriteLine(e.Source.ToString());
            parent.Items.Add(data);
        }

        // 마우스 아래 오브젝트 검색
        private static object GetDataFromListView(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (element == source)
                    {
                        return null;
                    }
                }

                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }

            return null;
        }
        #endregion
    }


}
