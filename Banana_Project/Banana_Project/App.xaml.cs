//using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;



namespace Banana_Project
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class App : Application
    {

        //[DllImport("kernel32.dll")]
        //public static extern bool FreeConsole();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //FreeConsole();
            SplashWindow splash = new SplashWindow();
            splash.Show();

            Thread.Sleep(300);

            splash.SetPrograss(100);

            for (int i = 100; i < 700; i+=5)
            {
                splash.SetPrograss(i + 1);
                Thread.Sleep(1);
            }
            Thread.Sleep(300);

            splash.SetPrograss(700);
            splash.SetPrograss(700);

            Thread.Sleep(200);
            MainWindow main = new MainWindow();
            splash.Close();
            main.Show();
        }
    }


}
