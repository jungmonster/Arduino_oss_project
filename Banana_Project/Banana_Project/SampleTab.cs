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
    static class SampleTab
    {
        public static ObservableCollection<string> GetSampleList()
        {
            ObservableCollection<string> nodeObjectList = new ObservableCollection<string>();

            nodeObjectList.Add("Wifi_Shield");
            nodeObjectList.Add("Web_Server");
            nodeObjectList.Add("Bluetooth_4.0_Master");
            nodeObjectList.Add("Bluetooth_4.0_Slave");
            nodeObjectList.Add("GPS_module");
            nodeObjectList.Add("For_example");
            nodeObjectList.Add("If_example");
            nodeObjectList.Add("testing");
            return nodeObjectList;
        }

        public static List<string> SampleCodeExam(string sampleName)
        {
            string filePath = @"..\..\samplecode\" + sampleName + ".txt";
            int counter = 0;
            string line;
            List<string> txtline = new List<string>();

            //when file doesn't exist
            if (!System.IO.File.Exists(filePath))
                return null;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                txtline.Add(line);
                counter++;
            }
            file.Close();
            return txtline;
        }
    }
}
