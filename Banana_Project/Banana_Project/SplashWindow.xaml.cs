using System.Threading;
using System.Windows;

namespace Banana_Project
{
    /// <summary>
    /// SplashWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();

            //prograssBar.IsIndeterminate = true;

        }

        public void Start()
        {
            Thread th = new Thread(StartLoading);
            th.Start();
        }

        public void StartLoading()
        {
            int i = 0;

            while (i < 100)
            {
                Thread.Sleep(50);

                this.Dispatcher.Invoke(delegate
                {
                    prograssBar.Value = i;
                });

                i++;
            }
        }

        public void SetPrograss(int percent)
        {
            prograssBar.Dispatcher.Invoke(() =>
            {
                prograssBar.Value = percent;
            }, System.Windows.Threading.DispatcherPriority.Background
            );
        }
    }
}
