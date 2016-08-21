using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Banana_Project.PluginModule
{
    public class MenuListNode
    {
        private int args;
        private string menuName;
        private string arg0;
        private string arg1;
        private string arg2;
        private string arg3;

        public MenuListNode(string _menuName, int _args)
        {
            menuName = _menuName;
            args = _args;
        }

        public MenuListNode(string _menuName , int _args , string _arg0)
            :this(_menuName , _args)
        {
            arg0 = _arg0;
        }

        public MenuListNode(string _menuName, int _args, string _arg0, string _arg1) 
            //: this(_menuName , _args , _arg0)
        {
            menuName = _menuName;
            args = _args;
            arg0 = _arg0;
            arg1 = _arg1 ;
        }

        public MenuListNode(string _menuName, int _args, string _arg0, string _arg1, string _arg2) 
            : this(_menuName , _args, _arg0 , _arg1)
        {
            arg2 = _arg2;
        }

        public MenuListNode(string _menuName, int _args, string _arg0, string _arg1, string _arg2, string _arg3) 
            : this(_menuName , _args, _arg0, _arg1 , _arg2)
        {
            arg3 = _arg3;
        }

        public string MenuName
        {
            get
            {
                return menuName;
            }
        }

        public int Args
        {
            get
            {
                return args;
            }   
        }
         
        public string Arg0
        {
            get
            {
                return arg0;
            }
        }

        public string Arg1
        {
            get
            {
                return arg1; 
            }
        }

        public string Arg2
        {
            get
            {
                return arg2;
            }
        }

        public string Arg3
        {
            get
            {
                return arg3;
            }
        }

    }
}
