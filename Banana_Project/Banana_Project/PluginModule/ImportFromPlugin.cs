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
        const string padding = "    ";
        private string rootPath;
        private List<MenuListNode> list;
        private List<ExampleNode> examples; 

        public ImportFromPlugin(string _rootPath)
        {
            rootPath = _rootPath;
            list = new List<MenuListNode>();
            examples = new List<ExampleNode>();
            //Refresh();
        }

        public List<MenuListNode> GetList
        {
            get
            {
                return list;
            }
        }

        public List<ExampleNode> Examples
        {
            get
            {
                return examples;
            }
        }

        public void Refresh()
        {
            list.Clear();
            examples.Clear();
            DirectoryInfo root = new DirectoryInfo(rootPath);
            DirectoryInfo[] dirs = root.GetDirectories();

            char[] splitter = { '.' };
            foreach(DirectoryInfo dir in dirs)
            {
                DirectoryInfo tempPath = new DirectoryInfo(dir.FullName + "\\examples");
                FileInfo[] files = tempPath.GetFiles();
                foreach (FileInfo f in files)
                {
                    examples.Add(new ExampleNode(dir.Name, f.Name.Split(splitter)[0])) ;
                }

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

        public static void ParseCode(ArgLayout arg , out string other , 
            out string setup , out string loop , string location)
        {
            string path = string.Format(@"..\\..\\plugin\\{0}\\codeBlock\\{1}.txt", arg.Filename, arg.Menuname);

            string[] lines = System.IO.File.ReadAllLines(path);

            other = GetOtherCode(lines);
            setup = GetSetupCode(lines);
            loop = GetLoopCode(lines);

            if (location.Equals("setup"))
                setup += "\n" + GetLocationCode(lines);

            else
                loop += "\n" + GetLocationCode(lines);
        }

        private static string GetOtherCode(string[] lines)
        {
            StringBuilder builder = new StringBuilder();

            Console.WriteLine("GetOtherCode!!");
            int idx; 
            for(idx=0; idx<lines.Length; idx++)
            {
                Console.WriteLine(lines[idx]);
                if (lines[idx].Equals("<startOther>")) break;

            }

            Console.WriteLine("break;");
            idx++;

            while (!lines[idx].Equals("<endOther>"))
            {
                Console.WriteLine(lines[idx]);
                builder.AppendLine(lines[idx]);
                idx++;
            }
                


            return builder.ToString();
        }

        private static string GetSetupCode(string[] lines)
        {
            StringBuilder builder = new StringBuilder();

            int idx;
            for (idx = 0; idx < lines.Length; idx++)
            {
                if (lines[idx].Equals("<startSetup>")) break;
            }

            idx++;

            while (!lines[idx].Equals("<endSetup>"))
            {
                builder.AppendLine(padding + lines[idx]);
                idx++; 
            }

            return builder.ToString();
        }

        private static string GetLoopCode(string[] lines)
        {
            StringBuilder builder = new StringBuilder();

            int idx;
            for (idx = 0; idx < lines.Length; idx++)
            {
                if (lines[idx].Equals("<startLoop>")) break;
            }

            idx++;

            while (!lines[idx].Equals("<endLoop>"))
            {
                builder.AppendLine(padding + lines[idx]);
                idx++;
            }

            return builder.ToString();
        }

        private static string GetLocationCode(string[] lines)
        {
            StringBuilder builder = new StringBuilder();

            int idx;
            for (idx = 0; idx < lines.Length; idx++)
            {
                if (lines[idx].Equals("<startLocation>")) break;
            }

            idx++;

            while (!lines[idx].Equals("<endLocation>"))
            {
                builder.AppendLine(padding + lines[idx]);
                idx++;
            }

            return builder.ToString();
        }
    }
}
