using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;

namespace Banana_Project
{

    class CodeGenerator
    {
        List<string> ortherArea = new List<string>();
        List<string> setupArea = new List<string>();
        List<string> loopArea = new List<string>();
        int check_maxCounter = 0;
        int check_counter = 0;
        
        public CodeGenerator()
        {
            initSetGenerator();

        }

        public void CodeGeneratorClear()
        {
            ortherArea.Clear();
            setupArea.Clear();
            loopArea.Clear();
            check_maxCounter = 0;
            check_counter = 0;
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
                    bool check = Parser_Println(child);
                    if(!check)
                        Console.WriteLine("Err : println object err");
                    
                }
                else if (child.Uid.Equals("Note"))
                {
                    bool check = Parser_Note(child);
                    if (!check)
                        Console.WriteLine("Err : Note object err");
                }
                else if (child.Uid.Equals("Delay"))
                {
                    bool check = Parser_Delay(child);
                    if (!check)
                        Console.WriteLine("Err : Delay object err");
                }
                else if(child.Uid.Equals("While"))
                {
                    bool check = Parser_While(child);
                    if (!check)
                        Console.WriteLine("Err : While object err");
                }
                else
                {
                    Console.WriteLine("Err : Undefined object " + child.Uid);
                }
            }
        }

        bool Parser_Println(Grid child)
        {
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                TextBox element = VisualTreeHelper.GetChild(child, i) as TextBox;
                if(element != null)
                {
                    string str = "println(\"" + element.Text + "\");" ;
                    loopArea.Add(str);
                    return true;
                }

            }
            return false;    
        }

        bool Parser_Delay(Grid child)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                TextBox element = VisualTreeHelper.GetChild(child, i) as TextBox;
                if (element != null)
                {
                    string str = "delay(" + element.Text + ");";
                    loopArea.Add(str);
                    return true;
                }

            }
            return false;
        }

        bool Parser_Note(Grid child)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                TextBox element = VisualTreeHelper.GetChild(child, i) as TextBox;
                if (element != null)
                {
                    string str = "// " + element.Text;
                    loopArea.Add(str);
                    return true;
                }

            }
            return false;
        }

        bool Parser_While(Grid child)
        {
            check_counter += 1;
            if(check_maxCounter < check_counter)
            {
                check_maxCounter += 1;
                ortherArea.Add("int counter" + check_maxCounter + " = 0;");
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                UIElement element = VisualTreeHelper.GetChild(child, i) as UIElement;

                if (element.GetType() == typeof(TextBox))
                {
                    Console.WriteLine("Find text box for get count");
                }
                else if(element.GetType() == typeof(ListBox))
                {
                    Console.WriteLine("Find Listbox");
                    ListBox listbox = element as ListBox;
                    ChangeToCode(listbox);
                }

            }
            check_counter -= 1;
            return false;
        }

    }
}
