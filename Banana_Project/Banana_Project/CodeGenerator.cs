using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace Banana_Project
{

    class CodeGenerator
    {
        List<string> ortherArea = new List<string>();
        List<string> setupArea = new List<string>();
        List<string> loopArea = new List<string>();
        
        public CodeGenerator()
        {
            initSetGenerator();

        }

        public void CodeGeneratorClear()
        {
            ortherArea.Clear();
            setupArea.Clear();
            loopArea.Clear();
            initSetGenerator();
        }

        private void initSetGenerator()
        {
            // ortherArea setting
            ortherArea.Add("// 전역 구역");

            // setupArea setting
            setupArea.Add("// setup 함수 구역");
            setupArea.Add("void setup(){");

            // loopArea setting
            loopArea.Add("// loop 함수 구역 ");
            loopArea.Add("void loop() {");
        }

        public void endSetGenerator()
        {
            // add empty space in ortherArea
            ortherArea.Add("");
            ortherArea.Add("");
            ortherArea.Add("");

            // close setup function and add empty space
            setupArea.Add("}");
            setupArea.Add("");
            setupArea.Add("");
            setupArea.Add("");

            // close loop funtion and add empty space
            loopArea.Add("}");
            loopArea.Add("");
            loopArea.Add("");
            loopArea.Add("");

        }
        

        public List<string> GetLoopString()
        {
            return loopArea;
        }
        public List<string> GetSetupString()
        {
            return setupArea;
        }
        public List<string> GetOrtherString()
        {
            return ortherArea;
        }

        public void ChangeToCode(ListBox listbox)
        {
            //Console.WriteLine("Change to Code Event");
            for(int i = 0; i < listbox.Items.Count; i++)
            {
                //Console.WriteLine("Change to Code Event");
                Grid child = listbox.Items[i] as Grid;
                if(child == null)
                {
                    Console.WriteLine("err : List child is not Grid at index num : " + i );
                    continue;
                }
                if (child.Uid.Equals("Println"))
                {
                    string str = Parser_Println(child);
                    if(str != null)
                        loopArea.Add(str);
                    
                }
                else if (child.Uid.Equals("Note"))
                {
                    string str = Parser_Note(child);
                    if (str != null)
                        loopArea.Add(str);
                }
                else if (child.Uid.Equals("Delay"))
                {
                    string str = Parser_Delay(child);
                    if (str != null)
                        loopArea.Add(str);
                }
                else if(child.Uid.Equals("While"))
                {

                }
                else
                {
                    Console.WriteLine("Err : Undefined object " + child.Uid);
                }
            }
        }

        string Parser_Println(Grid child)
        {
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                TextBox element = VisualTreeHelper.GetChild(child, i) as TextBox;
                if(element != null)
                {
                    string str = "println(\"" + element.Text + "\");" ;

                    //Console.WriteLine(str);
                    return str;
                }

            }
            return null;    
        }

        string Parser_Delay(Grid child)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                TextBox element = VisualTreeHelper.GetChild(child, i) as TextBox;
                if (element != null)
                {
                    string str = "delay(" + element.Text + ");";
                    //Console.WriteLine(str);
                    return str;
                }

            }
            return null;
        }

        string Parser_Note(Grid child)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                TextBox element = VisualTreeHelper.GetChild(child, i) as TextBox;
                if (element != null)
                {
                    string str = "// " + element.Text;
                    //Console.WriteLine(str);
                    return str;
                }

            }
            return null;
        }

    }
}
