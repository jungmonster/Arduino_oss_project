using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Banana_Project.PluginModule;

namespace Banana_Project
{
    static class ItemCreateHelper
    {
        // ListBox item test Function
        public static int counter = 1;
        static int itemWidth = 1500;
        static Thickness itemMargin = new Thickness(5, 10, 5, 10);

        public static ObservableCollection<string> GetSetupList()
        {
            ObservableCollection<string> nodeObjectList = new ObservableCollection<string>();
            nodeObjectList.Add("디지털포트설정");
            nodeObjectList.Add("문자열출력");
            nodeObjectList.Add("주석");
            nodeObjectList.Add("지연시간");
            nodeObjectList.Add("변수선언");
            return nodeObjectList;
        }

        // Node List에 추가 내용
        public static ObservableCollection<string> GetNodeList()
        {
            ObservableCollection<string> nodeObjectList = new ObservableCollection<string>();
            nodeObjectList.Add("문자열출력");
            nodeObjectList.Add("주석");
            nodeObjectList.Add("지연시간");
            nodeObjectList.Add("변수사용");
            nodeObjectList.Add("조건문");
            nodeObjectList.Add("반복");
            nodeObjectList.Add("디지털포트출력");
            nodeObjectList.Add("디지털포트입력");
            return nodeObjectList;
        }

        public static object FindGetSetupGridItem(string itemName, List<MenuListNode> list)
        {
            if (itemName.Equals("디지털포트설정"))
                return CodeItem_PinMode("PinMode");
            else if (itemName.Equals("문자열출력"))
                return CodeItemPrintln("Println");
            else if (itemName.Equals("주석"))
                return CodeItem_Note("Note");
            else if (itemName.Equals("지연시간"))
                return CodeItem_Delay("Delay");
            else if (itemName.Equals("변수선언"))
                return CodeItem_Variable("Variable");
            else
            {
                return SetGridObject(itemName, list);
            }
        }

        public static object FindGetSetupGridItem(string itemName)
        {
            if (itemName.Equals("디지털포트설정"))
                return CodeItem_PinMode("PinMode");
            else if (itemName.Equals("주석"))
                return CodeItem_Note("Note");
            else if (itemName.Equals("지연시간"))
                return CodeItem_Delay("Delay");
            else if (itemName.Equals("문자열출력"))
                return CodeItemPrintln("Println");
            else if (itemName.Equals("변수선언"))
                return CodeItem_Variable("Variable");
            else
            {
                return null;
            }

        }

        private static object SetGridObject(string itemName, List<MenuListNode> list)
        {

            foreach (MenuListNode e in list)
            {
                if (e.MenuName.Equals(itemName))
                {
                    int args = e.Args;

                    switch (args)
                    {
                        case 0:
                            return new Arg0Layout(e.Filename, e.MenuName);
                        case 1:
                            return new Arg1Layout(e.Filename, e.MenuName, e.Arg0);
                        case 2:
                            return new Arg2Layout(e.Filename, e.MenuName, e.Arg0, e.Arg1);
                    }
                }
            }

            return null;
        }

        public static object FindGetCodeGridItem(string itemName, List<MenuListNode> list)
        {
            if (itemName.Equals("문자열출력"))
                return CodeItemPrintln("Println");
            else if (itemName.Equals("주석"))
                return CodeItem_Note("Note");
            else if (itemName.Equals("지연시간"))
                return CodeItem_Delay("Delay");
            else if (itemName.Equals("조건문"))
                return CodeItem_If("If");
            else if (itemName.Equals("반복"))
                return CodeItem_While("While");
            else if (itemName.Equals("디지털포트출력"))
                return CodeItem_DigitalWrite("DigitalWrite");
            else if (itemName.Equals("디지털포트입력"))
                return CodeItem_DigitalRead("DigitalRead");
            else if (itemName.Equals("변수사용"))
                return CodeItem_Variable_Use("Variable_Use");
            else
                return SetGridObject(itemName, list);
        }

        public static object FindGetCodeGridItem(string itemName)
        {
            if (itemName.Equals("문자열출력"))
                return CodeItemPrintln("Println");
            else if (itemName.Equals("주석"))
                return CodeItem_Note("Note");
            else if (itemName.Equals("시간지연"))
                return CodeItem_Delay("Delay");
            else if (itemName.Equals("조건문"))
                return CodeItem_If("If");
            else if (itemName.Equals("반복"))
                return CodeItem_While("While");
            else if (itemName.Equals("디지털포트출력"))
                return CodeItem_DigitalWrite("DigitalWrite");
            else if (itemName.Equals("디지털포트입력"))
                return CodeItem_DigitalRead("DigitalRead");
            else if (itemName.Equals("변수사용"))
                return CodeItem_Variable_Use("Variable_Use");
            else
                return null;
        }

        // Create block item function
        #region Setup Block Create Function
        public static Grid CodeItem_PinMode(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "포트를 선택하세요";
            txtBlock1.FontSize = 13;
            txtBlock1.Margin = new Thickness(5, 5, 5, 5);
            txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock1.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 1);
            DynamicGrid.Children.Add(txtBlock1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "값을 선택하세요";
            txtBlock2.FontSize = 13;
            txtBlock2.Margin = new Thickness(5, 5, 5, 5);
            txtBlock2.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock2.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 2);
            DynamicGrid.Children.Add(txtBlock2);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 2);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock3.Text = "디지털포트설정";
            txtBlock3.FontSize = 14;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock3, 1);
            Grid.SetColumn(txtBlock3, 0);
            DynamicGrid.Children.Add(txtBlock3);

            ComboBox comboBox1 = new ComboBox();
            comboBox1.Uid = "PORT";
            comboBox1.Width = 250;
            comboBox1.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBox1.ItemsSource = MakePortItemMenu();
            Grid.SetRow(comboBox1, 1);
            Grid.SetColumn(comboBox1, 1);
            DynamicGrid.Children.Add(comboBox1);

            ComboBox comboBox2 = new ComboBox();
            comboBox2.Uid = "PINMODE";
            comboBox2.Width = 250;
            comboBox2.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBox2.ItemsSource = MakePinmodeItemMenu();
            Grid.SetRow(comboBox2, 1);
            Grid.SetColumn(comboBox2, 2);
            DynamicGrid.Children.Add(comboBox2);

            TextBlock txtBlock4 = new TextBlock();
            txtBlock4.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock4.Text = "↓";
            txtBlock4.FontSize = 14;
            txtBlock4.FontWeight = FontWeights.Bold;
            txtBlock4.Foreground = new SolidColorBrush(Colors.Red);
            txtBlock4.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock4, 2);
            Grid.SetColumnSpan(txtBlock4, 3);
            DynamicGrid.Children.Add(txtBlock4);

            return DynamicGrid;
        }

        public static Grid CodeItemPrintln(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "콘솔에 출력할 문자를 적으세요.";
            txtBlock1.FontSize = 13;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            txtBlock1.Margin = new Thickness(5, 5, 5, 5);
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 1);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 2);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "문자열출력";
            txtTitle.FontSize = 14;
            txtTitle.Foreground = new SolidColorBrush(Colors.Black);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);


            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 12;
            txtBox1.Foreground = new SolidColorBrush(Colors.Black);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 1);
            Grid.SetColumnSpan(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "↓";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Red);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock2, 2);
            Grid.SetColumnSpan(txtBlock2, 3);
            DynamicGrid.Children.Add(txtBlock2);


            return DynamicGrid;
        }

        public static Grid CodeItem_Note(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng, Colors.LightGoldenrodYellow);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "코드에 삽입할 주석을 입력하세요";
            txtBlock1.FontSize = 13;
            txtBlock1.Margin = new Thickness(5, 5, 5, 5);
            txtBlock1.Foreground = new SolidColorBrush(Colors.Blue);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 1);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 2);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "주석입력";
            txtTitle.FontSize = 14;
            txtTitle.Foreground = new SolidColorBrush(Colors.Blue);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);

            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 14;
            txtBox1.Foreground = new SolidColorBrush(Colors.Black);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            txtBox1.TextWrapping = TextWrapping.Wrap;
            txtBox1.AcceptsReturn = true;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 1);
            Grid.SetColumnSpan(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "↓";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Blue);
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
            txtBlock1.Text = "지연시간을 입력하세요( 1 second = 1000 )";
            txtBlock1.FontSize = 13;
            txtBlock1.Margin = new Thickness(5, 5, 5, 5);
            txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 1);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 2);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "지연시간(Delay)";
            txtTitle.FontSize = 14;
            txtTitle.Foreground = new SolidColorBrush(Colors.Black);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);

            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 12;
            txtBox1.Foreground = new SolidColorBrush(Colors.Black);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 1);
            Grid.SetColumnSpan(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "↓";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Red);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 2);
            Grid.SetColumn(txtBlock2, 0);
            Grid.SetColumnSpan(txtBlock2, 3);
            DynamicGrid.Children.Add(txtBlock2);

            return DynamicGrid;
        }

        public static Grid CodeItem_Variable(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "변수의 자료형을 선택하세요";
            txtBlock1.FontSize = 13;
            txtBlock1.Margin = new Thickness(5, 5, 5, 5);
            txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 1);
            DynamicGrid.Children.Add(txtBlock1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "변수명을 입력하세요";
            txtBlock2.FontSize = 13;
            txtBlock2.Margin = new Thickness(5, 5, 5, 5);
            txtBlock2.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 2);
            DynamicGrid.Children.Add(txtBlock2);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 2);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "자료형 & 이름";
            txtTitle.FontSize = 14;
            txtTitle.Foreground = new SolidColorBrush(Colors.Black);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);

            ComboBox comboBox = new ComboBox();
            comboBox.Uid = "DATA";
            comboBox.Width = 250;
            comboBox.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBox.ItemsSource = MakeItemDataMenu();
            Grid.SetRow(comboBox, 1);
            Grid.SetColumn(comboBox, 1);
            DynamicGrid.Children.Add(comboBox);

            TextBox txtBox1 = new TextBox();
            txtBox1.Uid = "NAME";
            txtBox1.FontSize = 14;
            txtBox1.Width = 250;
            txtBox1.Foreground = new SolidColorBrush(Colors.Black);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            txtBox1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBox1.TextAlignment = TextAlignment.Center;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);

            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock3.Text = "↓";
            txtBlock3.FontSize = 14;
            txtBlock3.FontWeight = FontWeights.Bold;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Red);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock3, 2);
            Grid.SetColumnSpan(txtBlock3, 3);
            DynamicGrid.Children.Add(txtBlock3);

            return DynamicGrid;
        }
        #endregion

        #region Loop Block Create Function
        public static Grid CodeItem_Variable_Use(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "변수명을 입력하세요";
            txtBlock1.FontSize = 13;
            txtBlock1.Margin = new Thickness(5, 5, 5, 5);
            txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 1);
            DynamicGrid.Children.Add(txtBlock1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "대입할 값을 입력하세요";
            txtBlock2.FontSize = 13;
            txtBlock2.Margin = new Thickness(5, 5, 5, 5);
            txtBlock2.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 2);
            DynamicGrid.Children.Add(txtBlock2);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 2);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtTitle = new TextBlock();
            txtTitle.HorizontalAlignment = HorizontalAlignment.Center;
            txtTitle.Text = "변수 이름 & 데이터";
            txtTitle.FontSize = 14;
            txtTitle.Foreground = new SolidColorBrush(Colors.Black);
            txtTitle.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtTitle, 1);
            Grid.SetColumn(txtTitle, 0);
            DynamicGrid.Children.Add(txtTitle);

            TextBox txtBox1 = new TextBox();
            txtBox1.Uid = "NAME";
            txtBox1.FontSize = 12;
            txtBox1.Width = 400;
            txtBox1.Foreground = new SolidColorBrush(Colors.Black);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            txtBox1.TextAlignment = TextAlignment.Center;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 1);
            DynamicGrid.Children.Add(txtBox1);

            TextBox txtBox2 = new TextBox();
            txtBox2.Uid = "DATA";
            txtBox2.FontSize = 12;
            txtBox2.Width = 400;
            txtBox2.Foreground = new SolidColorBrush(Colors.Black);
            txtBox2.VerticalAlignment = VerticalAlignment.Top;
            txtBox2.TextAlignment = TextAlignment.Center;
            Grid.SetRow(txtBox2, 1);
            Grid.SetColumn(txtBox2, 2);
            DynamicGrid.Children.Add(txtBox2);

            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock3.Text = "↓";
            txtBlock3.FontSize = 14;
            txtBlock3.FontWeight = FontWeights.Bold;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Red);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock3, 2);
            Grid.SetColumnSpan(txtBlock3, 3);
            DynamicGrid.Children.Add(txtBlock3);

            return DynamicGrid;
        }

        public static Grid CodeItem_If(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "조건문";
            txtBlock1.FontSize = 14;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 1);
            Grid.SetColumn(txtBlock1, 0);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Click += RemoveBtn_ClickEvent;
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.VerticalAlignment = VerticalAlignment.Center;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock2.Text = "조건식을 입력하세요";
            txtBlock2.FontSize = 13;
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 1);
            DynamicGrid.Children.Add(txtBlock2);

            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 12;
            txtBox1.Foreground = new SolidColorBrush(Colors.Black);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 1);
            Grid.SetColumnSpan(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);


            ListBox listbox = new ListBox();
            listbox.HorizontalAlignment = HorizontalAlignment.Stretch;
            listbox.VerticalAlignment = VerticalAlignment.Bottom;
            listbox.Margin = new Thickness(10, 10, 10, 0);
            listbox.Background = new SolidColorBrush(Colors.LightBlue);
            listbox.Foreground = new SolidColorBrush(Colors.Red);
            listbox.AllowDrop = true;
            listbox.Drop += Node_Drop;
            listbox.PreviewMouseLeftButtonDown += ChildListBox_MouseButtonDown;
            listbox.PreviewMouseLeftButtonUp += ChildListBox_MouseButtonUp;
            listbox.MouseMove += ChildListBox_MouseButtonMove;
            listbox.MinHeight = 20;
            Grid.SetRow(listbox, 2);
            Grid.SetColumnSpan(listbox, 3);
            DynamicGrid.Children.Add(listbox);

            return DynamicGrid;
        }

        public static Grid CodeItem_While(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "반복문";
            txtBlock1.FontSize = 14;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 1);
            Grid.SetColumn(txtBlock1, 0);
            DynamicGrid.Children.Add(txtBlock1);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Click += RemoveBtn_ClickEvent;
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "반복할 횟수를 입력하세요(숫자만)";
            txtBlock2.FontSize = 13;
            txtBlock2.Margin = new Thickness(5, 5, 5, 5);
            txtBlock2.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 1);
            DynamicGrid.Children.Add(txtBlock2);

            TextBox txtBox1 = new TextBox();
            txtBox1.FontSize = 12;
            txtBox1.Foreground = new SolidColorBrush(Colors.Black);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 1);
            Grid.SetColumnSpan(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);

            ListBox listbox = new ListBox();
            listbox.HorizontalAlignment = HorizontalAlignment.Stretch;
            listbox.VerticalAlignment = VerticalAlignment.Bottom;
            listbox.Margin = new Thickness(10, 10, 10, 0);
            listbox.Background = new SolidColorBrush(Colors.LightBlue);
            listbox.Foreground = new SolidColorBrush(Colors.Red);
            listbox.AllowDrop = true;
            listbox.Drop += Node_Drop;
            listbox.PreviewMouseLeftButtonDown += ChildListBox_MouseButtonDown;
            listbox.PreviewMouseLeftButtonUp += ChildListBox_MouseButtonUp;
            listbox.MouseMove += ChildListBox_MouseButtonMove;
            listbox.MinHeight = 20;
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
            txtBlock1.Text = "포트를 선택하세요";
            txtBlock1.FontSize = 13;
            txtBlock1.Margin = new Thickness(5, 5, 5, 5);
            txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 1);
            DynamicGrid.Children.Add(txtBlock1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "값을 선택하세요";
            txtBlock2.FontSize = 13;
            txtBlock2.Margin = new Thickness(5, 5, 5, 5);
            txtBlock2.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 2);
            DynamicGrid.Children.Add(txtBlock2);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 2);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);


            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock3.Text = "DigitaWrite";
            txtBlock3.FontSize = 14;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock3, 1);
            Grid.SetColumn(txtBlock3, 0);
            DynamicGrid.Children.Add(txtBlock3);

            ComboBox comboBox1 = new ComboBox();
            comboBox1.Uid = "PORT";
            comboBox1.Width = 250;
            comboBox1.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBox1.ItemsSource = MakePortItemMenu();
            Grid.SetRow(comboBox1, 1);
            Grid.SetColumn(comboBox1, 1);
            DynamicGrid.Children.Add(comboBox1);


            ComboBox comboBox2 = new ComboBox();
            comboBox2.Uid = "OUTPUT";
            comboBox2.Width = 250;
            comboBox2.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBox2.ItemsSource = MakeItemOutputMenu();
            Grid.SetRow(comboBox2, 1);
            Grid.SetColumn(comboBox2, 2);
            DynamicGrid.Children.Add(comboBox2);


            TextBlock txtBlock4 = new TextBlock();
            txtBlock4.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock4.Text = "↓";
            txtBlock4.FontSize = 14;
            txtBlock4.FontWeight = FontWeights.Bold;
            txtBlock4.Foreground = new SolidColorBrush(Colors.Red);
            txtBlock4.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock4, 2);
            Grid.SetColumnSpan(txtBlock4, 3);
            DynamicGrid.Children.Add(txtBlock4);

            return DynamicGrid;
        }

        public static Grid CodeItem_DigitalRead(string UIDStirng)
        {
            Grid DynamicGrid = GetDynamicGrid3x3(UIDStirng);

            //Add first column header
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.Text = "포트를 선택하세요";
            txtBlock1.FontSize = 13;
            txtBlock1.Margin = new Thickness(5, 5, 5, 5);
            txtBlock1.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 1);
            DynamicGrid.Children.Add(txtBlock1);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.Text = "저장할 변수명을 입력하세요";
            txtBlock2.FontSize = 13;
            txtBlock2.Margin = new Thickness(5, 5, 5, 5);
            txtBlock2.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 2);
            DynamicGrid.Children.Add(txtBlock2);

            Button btn = new Button();
            btn.Content = "Remove";
            btn.Width = 80;
            btn.Margin = new Thickness(5, 5, 5, 5);
            btn.HorizontalAlignment = HorizontalAlignment.Right;
            btn.Click += RemoveBtn_ClickEvent;
            Grid.SetRow(btn, 2);
            Grid.SetColumn(btn, 2);
            DynamicGrid.Children.Add(btn);


            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock3.Text = "DigitalRead";
            txtBlock3.FontSize = 14;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Black);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock3, 1);
            Grid.SetColumn(txtBlock3, 0);
            DynamicGrid.Children.Add(txtBlock3);

            ComboBox comboBox1 = new ComboBox();
            comboBox1.Uid = "PORT";
            comboBox1.HorizontalAlignment = HorizontalAlignment.Stretch;
            comboBox1.Width = 250;
            comboBox1.ItemsSource = MakePortItemMenu();
            Grid.SetRow(comboBox1, 1);
            Grid.SetColumn(comboBox1, 1);
            DynamicGrid.Children.Add(comboBox1);

            TextBox txtBox1 = new TextBox();
            txtBox1.Uid = "NAME";
            txtBox1.FontSize = 12;
            txtBox1.Width = 400;
            txtBox1.Foreground = new SolidColorBrush(Colors.Black);
            txtBox1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBox1, 1);
            Grid.SetColumn(txtBox1, 2);
            DynamicGrid.Children.Add(txtBox1);

            TextBlock txtBlock4 = new TextBlock();
            txtBlock4.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock4.Text = "↓";
            txtBlock4.FontSize = 14;
            txtBlock4.FontWeight = FontWeights.Bold;
            txtBlock4.Foreground = new SolidColorBrush(Colors.Red);
            txtBlock4.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(txtBlock4, 2);
            Grid.SetColumnSpan(txtBlock4, 3);
            DynamicGrid.Children.Add(txtBlock4);

            return DynamicGrid;
        }
        #endregion

        #region Block helper event function

        // Mouse Drag&Drop and UpDown Event ( for while & if and so on...) 
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
                object DynamicGrid = ItemCreateHelper.FindGetCodeGridItem(data.ToString());

                parent.Items.Add(DynamicGrid);
                counter++;
            }
        }
        static void RemoveBtn_ClickEvent(object sender, RoutedEventArgs e)
        {
            DependencyObject element = null;
            Button btn = sender as Button;

            Grid btnParent = VisualTreeHelper.GetParent(btn) as Grid;
            if (btnParent == null)
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
                    return;
                }
                if (element.GetType() == typeof(ListBox))
                {
                    ListBox temp = element as ListBox;
                    Console.WriteLine(temp.Uid);
                    temp.Items.Remove(btnParent);
                    break;
                }
                element = VisualTreeHelper.GetParent(element) as DependencyObject;
            }
        }
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
            DynamicGrid.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
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
        static Grid GetDynamicGrid3x3(string UIDStirng, Color color)
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
            DynamicGrid.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
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
            DynamicGrid.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
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

        // Make ComboBox item list 
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
        static List<ComboBoxItem> MakePinmodeItemMenu()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { Name = "OUTPUT" , Content = "OUTPUT"},
                new ComboBoxItem() { Name = "INPUT" , Content = "INPUT"},
            };

            return items;
        }
        static List<ComboBoxItem> MakeItemOutputMenu()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { Name = "HIGH" , Content = "HIGH"},
                new ComboBoxItem() { Name = "LOW" , Content = "LOW"},
            };

            return items;
        }
        static List<ComboBoxItem> MakeItemDataMenu()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>()
            {
                new ComboBoxItem() { Name = "boolean" , Content = "boolean"},
                new ComboBoxItem() { Name = "char" , Content = "char"},
                new ComboBoxItem() { Name = "byte" , Content = "byte"},
                new ComboBoxItem() { Name = "int" , Content = "int"},
                new ComboBoxItem() { Name = "String" , Content = "String"},

            };

            return items;
        }

        #endregion
    }



}
