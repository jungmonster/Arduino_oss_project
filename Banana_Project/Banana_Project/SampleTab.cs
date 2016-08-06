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

            nodeObjectList.Add("Wifi_shield");
            nodeObjectList.Add("for function");
            nodeObjectList.Add("run check~~~");
            nodeObjectList.Add("Test010101");
            nodeObjectList.Add("hahahahahah");
            nodeObjectList.Add("GGGGG");
            return nodeObjectList;
        }

        public static List<string> SampleCodeExam(string sampleName)
        {
            string filePath = @"C:\Users\jungm\Documents\Arduino_oss_project\Banana_Project\Banana_Project\sampleCode\" + sampleName + ".txt";
            int counter = 0;
            string line;
            List<string> txtline = new List<string>();
            
            System.IO.StreamReader file =   new System.IO.StreamReader(filePath);
            if( file == null)
            {
                Console.WriteLine("none file!!!!!!!!");
                return null;
            }
            while ((line = file.ReadLine()) != null)
            {
                
                System.Console.WriteLine(line);
                txtline.Add(line);
                counter++;
            }
            file.Close();
            return txtline;
        }
    }
}
