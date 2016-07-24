using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Banana_Project
{
    class NodeLabel : Label
    {
        public NodeLabel(string content)
        {
            /// init
            this.Width = 100;
            this.Height = 30;
            this.Content = content;
            setMouseFunction();

        }

        public NodeLabel()
        {
            this.Width = 100;
            this.Height = 30;
            this.Content = "Content";
            setMouseFunction();
        }

        private void setMouseFunction()
        {
            this.MouseDown += NodeLabel_MouseDown;
            this.MouseUp += NodeLabel_MouseUp;
            //this.MouseMove += NodeLabel_MouseMove;
        }

        void NodeLabel_MouseDown(object sender,MouseButtonEventArgs e)
        {
            Console.WriteLine("Mouse Down");
        }
        
        void NodeLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Mouse Up");
        }
        void NodeLabel_MouseMove(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Mouse Move");
        }
    }
}
