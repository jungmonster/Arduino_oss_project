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

namespace Banana_Project
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NodeDockLayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("mouse : " + sender.ToString());
        }

        private void NodeDock_MouseMove(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(sender.ToString());
            //Console.WriteLine("mouse Move : x :" + e.GetPosition(NodeDock).X + ", Y: " + e.GetPosition(NodeDock).Y);
        }
    }


}
