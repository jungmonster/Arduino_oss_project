﻿using System;
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
    static class ItemCreateHelper
    {
        // ListBox item test Function
        static int counter = 1;

        // Node List에 추가 내용
        public static ObservableCollection<string> GetNodeList()
        {
            ObservableCollection<string> nodeObjectList = new ObservableCollection<string>();
            nodeObjectList.Add("Wifi Shield");
            nodeObjectList.Add("Switch");
            nodeObjectList.Add("Button");
            nodeObjectList.Add("Test010101");
            nodeObjectList.Add("hahahahahah");
            nodeObjectList.Add("GGGGG");
            return nodeObjectList;
        }

        public static Grid SetGridObject(string name)
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = 400;
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

        public static Grid CodeItemPrintln(string UIDStirng)
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.Uid = UIDStirng;


            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition gridCol2 = new ColumnDefinition();
            gridCol2.Width = new GridLength(5, GridUnitType.Star);

            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);


            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(45);

            DynamicGrid.RowDefinitions.Add(gridRow1);



            return DynamicGrid;
        }
    }

    
}
