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
        ObservableCollection<string> nodeObjectList = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            NodeList.MouseDown += NodeListView_MouseDown;

            // Node List 높이를 지정하기 위해 설정... 이후 size가 변화될때마다 새로 설정이 필요함
            NodeList.Height = this.Height - 70;
            CodeNodeList.Height = this.Height - 70;
            this.SizeChanged += new SizeChangedEventHandler(MainWindow_SizeChange);

            NodeList.ItemsSource = ItemCreateHelper.GetNodeList();
            SampleNodeList.ItemsSource = SampleTab.GetSampleList();
        }

        void Menu_Check(object sender, RoutedEventArgs e)
        {
            object ob = CodeNodeList.Items.GetItemAt(2);
            CodeNodeList.Items.Remove(ob);
            CodeNodeList.Items.Insert(4, ob);
        }
          
        
        //  windows size 변화에 따라 ListView Height 변경
        void MainWindow_SizeChange(object sender, SizeChangedEventArgs e)
        {
            NodeList.Height = this.Height - 60;
            CodeNodeList.Height = this.Height - 60;
            SampleNodeList.Height = this.Height - 60;
            SampleCode.Height = this.Height - 60;
        }
        #region SampleTab function
        void SampleNodeList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            List<string> txtLine = null;
            object data = MouseEventHelper.GetDataFromNodeList(parent, e.GetPosition(parent));
            DataObject ob = data as DataObject;
            if (ob == null)
                return;

            Console.WriteLine("data : " + ob.GetData("NodeList").ToString());
            txtLine = SampleTab.SampleCodeExam(ob.GetData("NodeList").ToString());
            if (txtLine != null)
            {
                SampleCode.Clear();
                for (int i = 0; i < txtLine.Count; i++)
                {
                    SampleCode.AppendText(txtLine[i] + "\n");
                }
            }

        }
        #endregion

        #region Drag&Drop
        void NodeListView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = MouseEventHelper.GetDataFromNodeList(dragSource, e.GetPosition(parent));
            if (data != null)
                Console.WriteLine(data.ToString());
            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }

        
        #endregion


        void CodeNode_Drop(object sender, DragEventArgs e)
        {
            Console.WriteLine("Drop event");

            if (e.Data.GetDataPresent("NodeList"))
            {
                object data = e.Data.GetData("NodeList");
                UIElement droptarget = e.Source as UIElement;
                ListBox parent = (ListBox)sender;

                //Grid DynamicGrid = SetGridObject(data.ToString());
                Grid DynamicGrid = ItemCreateHelper.FindGetGridItem( data.ToString() );

                parent.Items.Add(DynamicGrid);
            }

            if (e.Data.GetDataPresent("UIElement"))
            {

            }

        }
        bool codeListBox_Click = false;
        int currentClickID = -1;
        void CodeNodeListView_MouseButtonDown(object sender, MouseEventArgs e)
        {
            if (codeListBox_Click == false)
                codeListBox_Click = true;
            ListBox ob = sender as ListBox;
            Point po = e.GetPosition(ob);
            DependencyObject ch = ob.InputHitTest(po) as DependencyObject;
            int id = MouseEventHelper.findCodeListItemIndex(ob, ch);
            currentClickID = id;
            //Console.WriteLine("select object id : " + id);

        }
        void CodeNodeListView_MouseButtonUp(object sender, MouseEventArgs e)
        {
            if (codeListBox_Click == true)
                codeListBox_Click = false;

        }
        void CodeNodeListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (codeListBox_Click == false)
                return;
            ListBox ob = sender as ListBox;
            Point po = e.GetPosition(ob);
            DependencyObject ch = ob.InputHitTest(po) as DependencyObject;
            int id = MouseEventHelper.findCodeListItemIndex(ob, ch);

            //Console.WriteLine("current id : " + currentClickID + ",  select id : " + id);

            if ( /*(currentClickID != id) &&*/ (currentClickID != -1) && ( id != -1 ) )
            {
                object oot = CodeNodeList.Items.GetItemAt(currentClickID);
                CodeNodeList.Items.Remove(oot);
                CodeNodeList.Items.Insert(id, oot);
                currentClickID = id;
            }

        }
        
    }

 
}
