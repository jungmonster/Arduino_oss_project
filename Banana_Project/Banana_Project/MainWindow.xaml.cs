using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;

namespace Banana_Project
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        ListBox dragSource = null;
        CodeGenerator codegnt = new CodeGenerator();
        ObservableCollection<string> nodeObjectList = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            this.Height = SystemParameters.MaximizedPrimaryScreenHeight;
            this.Width = SystemParameters.MaximizedPrimaryScreenWidth;
            NodeList.MouseDown += NodeListView_MouseDown;

            NodeList.ItemsSource = ItemCreateHelper.GetNodeList();
            SampleNodeList.ItemsSource = SampleTab.GetSampleList();
        }

        void Menu_Check(object sender, RoutedEventArgs e)
        {
            object ob = CodeNodeList.Items.GetItemAt(2);
            CodeNodeList.Items.Remove(ob);
            CodeNodeList.Items.Insert(4, ob);
        }

        void Select_CodeVIewTab(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Select Code Tab");
            codegnt.CodeGeneratorClear();                       // init
            codegnt.ChangeToCode(this.CodeNodeList);
            codegnt.endSetGenerator();
            List<string> orther = codegnt.GetOrtherString();
            List<string> setup = codegnt.GetSetupString();
            List<string> loop = codegnt.GetLoopString();

            CodeView.Clear();

            for (int i = 0; i < orther.Count; i++)
            {
                CodeView.AppendText(orther[i] + "\n");
            }
            for (int i = 0; i < setup.Count; i++)
            {
                CodeView.AppendText(setup[i] + "\n");
            }
            for (int i = 0; i < loop.Count; i++)
            {
                CodeView.AppendText(loop[i] + "\n");
            }
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

            //Console.WriteLine("data : " + ob.GetData("NodeList").ToString());
            txtLine = SampleTab.SampleCodeExam(ob.GetData("NodeList").ToString());
            BitmapImage bit = SampleTab.SampleImage(ob.GetData("NodeList").ToString());
            if (bit != null)
            {
                SampleImageViewImage.Source = bit;
            }
            if (txtLine != null)
            {
                sampleCode.Clear();
                for (int i = 0; i < txtLine.Count; i++)
                {
                    sampleCode.AppendText(txtLine[i] + "\n");
                }
            }

        }
        #endregion

        #region Drag&Drop
        void NodeListView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            ItemCreateHelper.counter = 1;
            dragSource = parent;
            object data = MouseEventHelper.GetDataFromNodeList(dragSource, e.GetPosition(parent));
            if (data == null)
            {
                Console.WriteLine("Err : Mouse Click object is null");
            }
            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Copy);
            }
        }


        #endregion


        void CodeNode_Drop(object sender, DragEventArgs e)
        {
            //Console.WriteLine("Drop event");

            if (ItemCreateHelper.counter > 1)
                return;
            if (e.Data.GetDataPresent("NodeList"))
            {
                object data = e.Data.GetData("NodeList");
                UIElement droptarget = e.Source as UIElement;
                ListBox parent = (ListBox)sender;

                //Grid DynamicGrid = SetGridObject(data.ToString());
                Grid DynamicGrid = ItemCreateHelper.FindGetGridItem(data.ToString());

                parent.Items.Add(DynamicGrid);
                ItemCreateHelper.counter++;
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

            if ( /*(currentClickID != id) &&*/ (currentClickID != -1) && (id != -1))
            {
                object oot = CodeNodeList.Items.GetItemAt(currentClickID);
                CodeNodeList.Items.Remove(oot);
                CodeNodeList.Items.Insert(id, oot);
                currentClickID = id;
            }

        }

        private void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ino|*.ino";
            saveFileDialog.Title = "Save a Code Block";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {

                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                    if (tabControl.SelectedIndex == 2)
                        sw.WriteLine(sampleCode.Text);
                    else
                        sw.WriteLine(CodeView.Text);
                    sw.Flush();
                    MessageBox.Show("Save Complete", "Save");
                }
            }
        }
    }
}
