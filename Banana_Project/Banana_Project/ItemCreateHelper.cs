using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Generic;


namespace Banana_Project
{
    static class ItemCreateHelper
    {
        // ListBox item test Function
        public static int counter = 1;
        static int itemWidth = 1500;
        static Thickness itemMargin = new Thickness(5, 5, 5, 5);

        // Node List에 추가 내용
        public static ObservableCollection<string> GetNodeList()
        {
            ObservableCollection<string> nodeObjectList = new ObservableCollection<string>();
            nodeObjectList.Add("문자열출력");
            nodeObjectList.Add("주석");
            nodeObjectList.Add("시간지연");
            nodeObjectList.Add("여러번반복");
            nodeObjectList.Add("포트사용");
            nodeObjectList.Add("Variable");
            return nodeObjectList;
        }
        
        public static Grid FindGetGridItem(string itemName)
        {
            if (itemName.Equals("문자열출력"))
                return CodeItemPrintln("Println");
            else if (itemName.Equals("주석"))
                return CodeItem_Note("Note");
            else if (itemName.Equals("시간지연"))
                return CodeItem_Delay("Delay");
            else if (itemName.Equals("Variable"))
                return CodeItem_Variable("Variable");
            else if (itemName.Equals("여러번반복"))
                return CodeItem_While("While");
            else if (itemName.Equals("포트사용"))
                return CodeItem_DigitalWrite("DigitalWrite");


            //else if (itemName.Equals("Wifi Shield")) ;
            //    return 
            else
                return SetGridObject(itemName);
        }

        public static Grid SetGridObject(string name)
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = itemWidth;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Center;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSeaGreen);
            DynamicGrid.Uid = "codeItem";
            DynamicGrid.Margin = new Thickness(10, 10, 10, 10);
            DynamicGrid.Name = "Grid0" + counter;
            counter++;
            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition gridCol2 = new ColumnDefinition();
            gridCol2.Width = new GridLength(2, GridUnitType.Star);
            ColumnDefinition gridCol3 = new ColumnDefinition();
            gridCol3.Width = new GridLength(1, GridUnitType.Star);
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);

            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(45);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(45);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(45);
            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = name;
            txtBlock1.FontSize = 14;
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            //TextBox txtbox1 = new TextBox();
            //txtbox1.Text = "aa";
            //txtbox1.FontSize = 14;
            //txtbox1.FontWeight = FontWeights.Bold;
            //txtbox1.Foreground = new SolidColorBrush(Colors.Red);
            //txtbox1.VerticalAlignment = VerticalAlignment.Top;
            //Grid.SetRow(txtbox1, 0);
            //Grid.SetColumn(txtbox1, 0);


            // Add second column header
            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.Text = "Age";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 1);

            // Add third column header
            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.Text = "Book";
            txtBlock3.FontSize = 14;
            txtBlock3.FontWeight = FontWeights.Bold;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock3, 0);
            Grid.SetColumn(txtBlock3, 2);

            //// Add column headers to the Grid
            DynamicGrid.Children.Add(txtBlock1);
            //dynamicgrid.children.add(txtbox1);
            DynamicGrid.Children.Add(txtBlock2);
            DynamicGrid.Children.Add(txtBlock3);

            // Create first Row
            TextBlock authorText = new TextBlock();
            authorText.Text = "Mahesh Chand";
            authorText.FontSize = 12;
            authorText.FontWeight = FontWeights.Bold;
            Grid.SetRow(authorText, 1);
            Grid.SetColumn(authorText, 0);

            TextBlock ageText = new TextBlock();
            ageText.Text = "33";
            ageText.FontSize = 12;
            ageText.FontWeight = FontWeights.Bold;
            Grid.SetRow(ageText, 1);
            Grid.SetColumn(ageText, 1);

            TextBlock bookText = new TextBlock();
            bookText.Text = "GDI+ Programming";
            bookText.FontSize = 12;
            bookText.FontWeight = FontWeights.Bold;
            Grid.SetRow(bookText, 1);
            Grid.SetColumn(bookText, 2);
            // Add first row to Grid
            DynamicGrid.Children.Add(authorText);
            DynamicGrid.Children.Add(ageText);
            DynamicGrid.Children.Add(bookText);

            // Create second row
            authorText = new TextBlock();
            authorText.Text = "Mike Gold";
            authorText.FontSize = 12;
            authorText.FontWeight = FontWeights.Bold;
            Grid.SetRow(authorText, 2);
            Grid.SetColumn(authorText, 0);

            ageText = new TextBlock();
            ageText.Text = "35";
            ageText.FontSize = 12;
            ageText.FontWeight = FontWeights.Bold;
            Grid.SetRow(ageText, 2);
            Grid.SetColumn(ageText, 1);

            bookText = new TextBlock();
            bookText.Text = "Programming C#";
            bookText.FontSize = 12;
            bookText.FontWeight = FontWeights.Bold;
            Grid.SetRow(bookText, 2);
            Grid.SetColumn(bookText, 2);

            // Add second row to Grid
            DynamicGrid.Children.Add(authorText);
            DynamicGrid.Children.Add(ageText);
            DynamicGrid.Children.Add(bookText);

            return DynamicGrid;
        }
        public static Grid CodeItemXXX(string UIDStirng)
        {
            Grid DynamicGrid = new Grid();
            //DynamicGrid.Width = new GridLength(1, GridUnitType.Star);
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.Uid = UIDStirng;
            DynamicGrid.Name = "XXX";

            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition gridCol2 = new ColumnDefinition();
            gridCol2.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition gridCol3 = new ColumnDefinition();
            gridCol3.Width = new GridLength(1, GridUnitType.Star);
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);

            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(45);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(45);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(45);
            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);


            return DynamicGrid;
        }

        // Create item 
        public static Grid CodeItemPrintln(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "콘솔에 출력할 문자를 적으세요.";
            txtBlock1.FontSize = 14;
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 2);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "Println";
            txtTitle.FontSize = 14;
            txtTitle.FontWeight = FontWeights.Bold;
            txtTitle.Foreground = new SolidColorBrush(Colors.Green);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);


            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 14;
            txtBox1.FontWeight = FontWeights.Bold;
            txtBox1.Foreground = new SolidColorBrush(Colors.Green);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 1);
            Grid.SetColumnSpan(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "▼";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock2, 2);
            Grid.SetColumnSpan(txtBlock2, 3);
            DynamicGrid.Children.Add(txtBlock2);


            return DynamicGrid;
        }
        public static Grid CodeItem_Note(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng, Colors.LightGreen);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "코드에 삽입할 주석을 입력하세요";
            txtBlock1.FontSize = 14;
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Blue);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 2);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 14;
            txtBox1.FontWeight = FontWeights.Bold;
            txtBox1.Foreground = new SolidColorBrush(Colors.Green);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            txtBox1.TextWrapping = TextWrapping.Wrap;
            txtBox1.AcceptsReturn = true;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 0);
            Grid.SetColumnSpan(txtBox1, 3);
            DynamicGrid.Children.Add(txtBox1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "▼";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 2);
            Grid.SetColumn(txtBlock2, 0);
            Grid.SetColumnSpan(txtBlock2, 3);
            DynamicGrid.Children.Add(txtBlock2);

            return DynamicGrid;
        }
        public static Grid CodeItem_Delay(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "지연 시간을 입력하세요 ( 1000 = 1s )";
            txtBlock1.FontSize = 14;
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 2);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "Delay";
            txtTitle.FontSize = 14;
            txtTitle.FontWeight = FontWeights.Bold;
            txtTitle.Foreground = new SolidColorBrush(Colors.Green);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);

            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 14;
            txtBox1.FontWeight = FontWeights.Bold;
            txtBox1.Foreground = new SolidColorBrush(Colors.Green);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 1);
            DynamicGrid.Children.Add(txtBox1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "▼";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 2);
            Grid.SetColumnSpan(txtBlock2,2);
            DynamicGrid.Children.Add(txtBlock2);

            return DynamicGrid;
        }
        public static Grid CodeItem_Variable(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "▼";
            txtBlock1.FontSize = 14;
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 2);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);


            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "Variable";
            txtTitle.FontSize = 14;
            txtTitle.FontWeight = FontWeights.Bold;
            txtTitle.Foreground = new SolidColorBrush(Colors.Green);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);

            CheckBox checkBox = new CheckBox();
            checkBox.HorizontalAlignment = HorizontalAlignment.Center;
            checkBox.Content = "사용여부";
            checkBox.FontSize = 14;
            checkBox.IsChecked = true;

            Grid.SetRow(checkBox, 1);
            Grid.SetColumn(checkBox, 1);
            DynamicGrid.Children.Add(checkBox);


            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 14;
            txtBox1.FontWeight = FontWeights.Bold;
            txtBox1.Foreground = new SolidColorBrush(Colors.Green);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);


            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "▼";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock2, 2);
            Grid.SetColumnSpan(txtBlock2, 3);
            DynamicGrid.Children.Add(txtBlock2);

            return DynamicGrid;
        }
        public static Grid CodeItem_While(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "해당 구간을 지정한 수 만큼 반복합니다. (숫자만 입력하세요)";
            txtBlock1.FontSize = 14;
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 2);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "While";
            txtTitle.FontSize = 14;
            txtTitle.FontWeight = FontWeights.Bold;
            txtTitle.Foreground = new SolidColorBrush(Colors.Green);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);

            TextBlock txt = new TextBlock();
            txt.HorizontalAlignment = HorizontalAlignment.Center;
            txt.Text = "Count : ";
            txt.FontSize = 14;
            txt.FontWeight = FontWeights.Bold;
            txt.Foreground = new SolidColorBrush(Colors.Green);
            txt.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txt, 1);
            Grid.SetColumn(txt, 1);
            DynamicGrid.Children.Add(txt);

            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 14;
            txtBox1.FontWeight = FontWeights.Bold;
            txtBox1.Foreground = new SolidColorBrush(Colors.Green);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);


            ListBox listbox = new ListBox();
            listbox.HorizontalAlignment = HorizontalAlignment.Stretch;
            listbox.VerticalAlignment = VerticalAlignment.Top;
            listbox.Foreground = new SolidColorBrush(Colors.Red);
            listbox.AllowDrop = true;
            listbox.Drop += Node_Drop;
            listbox.PreviewMouseLeftButtonDown += ChildListBox_MouseButtonDown;
            listbox.PreviewMouseLeftButtonUp += ChildListBox_MouseButtonUp;
            listbox.MouseMove += ChildListBox_MouseButtonMove;
            listbox.MinHeight = 20 ;
            Grid.SetRow(listbox, 2);
            Grid.SetColumnSpan(listbox, 3);

            DynamicGrid.Children.Add(listbox);

            return DynamicGrid;
        }
        public static Grid CodeItem_DigitalWrite(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "▼";
            txtBlock1.FontSize = 14;
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 2);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);


            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "Variable";
            txtTitle.FontSize = 14;
            txtTitle.FontWeight = FontWeights.Bold;
            txtTitle.Foreground = new SolidColorBrush(Colors.Green);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);

            //CheckBox checkBox = new CheckBox();
            //checkBox.HorizontalAlignment = HorizontalAlignment.Center;
            //checkBox.Content = "사용여부";
            //checkBox.FontSize = 14;
            //checkBox.IsChecked = true;

            //Grid.SetRow(checkBox, 1);
            //Grid.SetColumn(checkBox, 1);
            //DynamicGrid.Children.Add(checkBox);

            ComboBox comboBox = new ComboBox();
            comboBox.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBox.ItemsSource = MakePortItemMenu();
            Grid.SetRow(comboBox, 1);
            Grid.SetColumn(comboBox, 1);
            DynamicGrid.Children.Add(comboBox); 


            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 14;
            txtBox1.FontWeight = FontWeights.Bold;
            txtBox1.Foreground = new SolidColorBrush(Colors.Green);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);


            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "▼";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock2, 2);
            Grid.SetColumnSpan(txtBlock2, 3);
            DynamicGrid.Children.Add(txtBlock2);

            return DynamicGrid;
        }




        // Event helper function
        static void Node_Drop(object sender, DragEventArgs e)
        {
            //Console.WriteLine("Drop event!!!!!!!!!!!!!!!!!!");
            if (counter > 1)
                return;
            if (e.Data.GetDataPresent("NodeList"))
            {
                object data = e.Data.GetData("NodeList");
                UIElement droptarget = e.Source as UIElement;
                ListBox parent = (ListBox)sender;

                //Grid DynamicGrid = SetGridObject(data.ToString());
                Grid DynamicGrid = ItemCreateHelper.FindGetGridItem(data.ToString());

                parent.Items.Add(DynamicGrid);
                counter++;
            }
        }
        static void RemoveBtn_ClickEvent(object sender, RoutedEventArgs e)
        {
            DependencyObject element = null;
            Button btn = sender as Button;

            Grid btnParent = VisualTreeHelper.GetParent(btn) as Grid;
            if(btnParent == null)
            {
                Console.WriteLine("Err : Don' find parent of item. check item tree (" + btn.ToString() + ")");
            }

            element = VisualTreeHelper.GetParent(btnParent) as DependencyObject;
            while (true)
            {
                Console.WriteLine(element.GetType());   
                if (element == null)
                {
                    Console.WriteLine("Err : null point inception");
                    return ;
                }
                if( element.GetType() == typeof(ListBox))
                {
                    ListBox temp = element as ListBox;
                    Console.WriteLine(temp.Uid);
                    temp.Items.Remove(btnParent);
                    break;
                }
                element = VisualTreeHelper.GetParent(element) as DependencyObject;
            } 

        }

        // Mouse UpDown Event
        static bool codeListBox_Click = false;
        static int currentClickID = -1;

        static void ChildListBox_MouseButtonDown(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Mouse btn down");
            if (codeListBox_Click == false)
                codeListBox_Click = true;
            ListBox ob = sender as ListBox;
            Point po = e.GetPosition(ob);
            DependencyObject ch = ob.InputHitTest(po) as DependencyObject; 
            int id = MouseEventHelper.findCodeListItemIndex(ob, ch);
            currentClickID = id;
        }
        static void ChildListBox_MouseButtonUp(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Mouse btn up");
            if (codeListBox_Click == true)
                codeListBox_Click = false;
        }
        static void ChildListBox_MouseButtonMove(object sender, MouseEventArgs e)
        {
            if (codeListBox_Click == false)
                return;
            ListBox ob = sender as ListBox;
            Point po = e.GetPosition(ob);
            DependencyObject ch = ob.InputHitTest(po) as DependencyObject;
            int id = MouseEventHelper.findCodeListItemIndex(ob, ch);

            Console.WriteLine("current id : " + currentClickID + ",  select id : " + id);

            if ( /*(currentClickID != id) &&*/ (currentClickID != -1) && (id != -1))
            {
                object oot = ob.Items.GetItemAt(currentClickID);
                ob.Items.Remove(oot);
                ob.Items.Insert(id, oot);
                currentClickID = id;
            }
        }


        // Grid make helper function
        static Grid GetDynamicGrid3x3(string UIDStirng)
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = itemWidth;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.Margin = itemMargin;
            //DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.Uid = UIDStirng;


            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition gridCol2 = new ColumnDefinition();
            gridCol2.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition gridCol3 = new ColumnDefinition();
            gridCol2.Width = new GridLength(1, GridUnitType.Star);
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);

            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(3, GridUnitType.Star);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(1, GridUnitType.Star);
            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);

            return DynamicGrid;
        }
        static Grid GetDynamicGrid3x3(string UIDStirng, Color color )
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = itemWidth;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.Margin = itemMargin;
            //DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(color);
            DynamicGrid.Uid = UIDStirng;


            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition gridCol2 = new ColumnDefinition();
            gridCol2.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition gridCol3 = new ColumnDefinition();
            gridCol2.Width = new GridLength(1, GridUnitType.Star);
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);

            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(3, GridUnitType.Star);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(1, GridUnitType.Star);
            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);

            return DynamicGrid;
        }
        static Grid GetDynamicGrid2x3(string UIDStirng)
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = itemWidth;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.Margin = itemMargin;
            //DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.Uid = UIDStirng;


            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition gridCol2 = new ColumnDefinition();
            gridCol2.Width = new GridLength(4, GridUnitType.Star);
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);

            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(3, GridUnitType.Star);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(1, GridUnitType.Star);
            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);

            return DynamicGrid;
        }
        static Grid GetDynamicGrid1x3(string UIDStirng)
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = itemWidth;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.Margin = itemMargin;
            //DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.Uid = UIDStirng;


            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(1, GridUnitType.Star);
            DynamicGrid.ColumnDefinitions.Add(gridCol1);

            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(3, GridUnitType.Star);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(1, GridUnitType.Star);
            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);

            return DynamicGrid;
        }

        static List<ComboBoxItem> MakePortItemMenu()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { Name = "Digital_01" , Content = "Digital_01"},
                new ComboBoxItem() { Name = "Digital_02" , Content = "Digital_02"},
                new ComboBoxItem() { Name = "Digital_03" , Content = "Digital_03"},
                new ComboBoxItem() { Name = "Digital_04" , Content = "Digital_04"},
                new ComboBoxItem() { Name = "Digital_05" , Content = "Digital_05"},
                new ComboBoxItem() { Name = "Digital_06" , Content = "Digital_06"},
                new ComboBoxItem() { Name = "Digital_07" , Content = "Digital_07"},
                new ComboBoxItem() { Name = "Digital_08" , Content = "Digital_08"},
                new ComboBoxItem() { Name = "Digital_09" , Content = "Digital_09"},
                new ComboBoxItem() { Name = "Digital_10" , Content = "Digital_10"},
                new ComboBoxItem() { Name = "Digital_11" , Content = "Digital_11"},
                new ComboBoxItem() { Name = "Digital_12" , Content = "Digital_12"},
                new ComboBoxItem() { Name = "Digital_13" , Content = "Digital_13"},
            };

            return items;
        }

    }


    
}
