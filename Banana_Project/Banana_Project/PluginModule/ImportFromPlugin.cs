using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Banana_Project.PluginModule
{
    public class ImportFromPlugin
    {
        private string rootPath;
        private List<MenuListNode> list;

        public ImportFromPlugin(string _rootPath)
        {
            rootPath = _rootPath;
            list = new List<MenuListNode>();
            //Refresh();
        }

        public List<MenuListNode> GetList
        {
            get
            {
                return list;
            }
        }
        public void Refresh()
        {
            list.Clear();
            DirectoryInfo root = new DirectoryInfo(rootPath);
            DirectoryInfo[] dirs = root.GetDirectories();

            foreach(DirectoryInfo dir in dirs)
            {
                string[] lines = System.IO.File.ReadAllLines(dir.FullName + "\\" + "MenuNodeList.txt");
                foreach(string line in lines) { 
                    string[] tokens = line.Split(new char[] { ' ' });
                    int args = int.Parse(tokens[1]);
                    //MessageBox.Show("args : " + args + "Tokens[2] : " + tokens[2]);
                    switch (args)
                    {
                        case 0:
                            list.Add(new MenuListNode(tokens[0], args));
                            break;
                        case 1:
                            list.Add(new MenuListNode(tokens[0], args, tokens[2]));
                            break;
                        case 2:
                            list.Add(new MenuListNode(tokens[0], args, tokens[2], tokens[3]));
                            break;
                        case 3:
                            list.Add(new MenuListNode(tokens[0], args, tokens[2], tokens[3], tokens[4]));
                            break;
                        case 4:
                            list.Add(new MenuListNode(tokens[0], args, tokens[2], tokens[3], tokens[4], tokens[5]));
                            break;
                    }
                }
            }
        }
    }
}
