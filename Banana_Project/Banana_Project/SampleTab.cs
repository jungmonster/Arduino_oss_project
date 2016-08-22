using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace Banana_Project
{
    // Sample Code Tab Help Class
    static class SampleTab
    {
        public static ObservableCollection<string> GetSampleList()
        {
            ObservableCollection<string> nodeObjectList = new ObservableCollection<string>();

            nodeObjectList.Add("Wifi_Shield");
            nodeObjectList.Add("Bluetooth_4.0_Master");
            nodeObjectList.Add("Bluetooth_4.0_Slave");
            nodeObjectList.Add("GPS_module");
            nodeObjectList.Add("Web_Server_example");
            nodeObjectList.Add("For_example");
            nodeObjectList.Add("If_example");

            return nodeObjectList;
        }

        public static BitmapImage SampleImage(string sampleName)
        {
            string filePath = null;
            string currentPath = AppDomain.CurrentDomain.BaseDirectory ;
            if (sampleName.Equals("TASExample"))
            {
                filePath = @"C:\Users\icdi0\Desktop\호작질\Banana\Banana\KNU_OSS_2016_Banana-study_wpf\Banana_Project\Banana_Project\plugin\Mobius\images\TASExample.jpg";
            }
            else
            {
                filePath = currentPath + @"..\..\sampleImage\" + sampleName + ".jpg";
            }
            
            
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            if(!System.IO.File.Exists(filePath))
            {
                bi3.UriSource = new Uri(currentPath + @"..\..\sampleImage\err.png");
            }
            else
                bi3.UriSource = new Uri(filePath);
            bi3.EndInit();

            return bi3;
        }

        public static List<string> SampleCodeExam(string sampleName)
        {
            string filePath = null;

            if(sampleName.Equals("TASExample"))
                filePath = @"..\..\plugin\mobius\examples\TASExample.txt";
            else
                filePath = @"..\..\samplecode\" + sampleName + ".txt";

            int counter = 0;
            string line;
            List<string> txtline = new List<string>();

            //when file doesn't exist
            if (!System.IO.File.Exists(filePath))
            {
                return null;
            }

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
