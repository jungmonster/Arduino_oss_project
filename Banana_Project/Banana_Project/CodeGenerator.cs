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
        int check_padding = 0;
  
        string padding = "    ";
        string padding_temp = "    ";

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
            ortherArea.Add("");
            ortherArea.Add("int speed = 9600;");

            // setupArea setting
            setupArea.Add("// setup 함수 구역");
            setupArea.Add("void setup(){");
            setupArea.Add(padding + "// USB 통신 준비");
            setupArea.Add(padding + "Serial.begin(speed);");

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

        public void ChangeToCode_Loop(ListBox listbox)
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
                    if (!check)
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
                else if (child.Uid.Equals("While"))
                {
                    bool check = Parser_While(child);
                    if (!check)
                        Console.WriteLine("Err : While object err");
                }
                else if (child.Uid.Equals("DigitalWrite"))
                {
                    bool check = Parser_DigitalWrite(child);
                    if (!check)
                        Console.WriteLine("Err : While object err");
                }
                else if (child.Uid.Equals("DigitalRead"))
                {
                    bool check = Parser_DigitalRead(child);
                    if (!check)
                        Console.WriteLine("Err : While object err");
                }
                else if (child.Uid.Equals("Variable_Use"))
                {
                    bool check = Parser_Veriable_Use(child);
                    if (!check)
                        Console.WriteLine("Err : While object err");
                }
                else if (child.Uid.Equals("If"))
                {
                    bool check = Parser_If(child);
                    if (!check)
                        Console.WriteLine("Err : While object err");
                }
                else
                {
                    Console.WriteLine("Err : Undefined object " + child.Uid);
                }
            }
        }

        public void ChangeToCode_Setup(ListBox listbox)
        {
            //Console.WriteLine("Change to Code Event");
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                //Console.WriteLine("Change to Code Event");
                Grid child = listbox.Items[i] as Grid;
                if (child == null)
                {
                    Console.WriteLine("err : List child is not Grid at index num : " + i);
                    continue;
                }
                if (child.Uid.Equals("Println"))
                {
                    bool check = Parser_Println(child, "setup");
                    if (!check)
                        Console.WriteLine("Err : println object err");

                }
                else if (child.Uid.Equals("Note"))
                {
                    bool check = Parser_Note(child, "setup");
                    if (!check)
                        Console.WriteLine("Err : Note object err");
                }
                else if (child.Uid.Equals("Delay"))
                {
                    bool check = Parser_Delay(child, "setup");
                    if (!check)
                        Console.WriteLine("Err : Delay object err");
                }
                else if (child.Uid.Equals("PinMode"))
                {
                    bool check = Parser_PinMode(child);
                    if (!check)
                        Console.WriteLine("Err : While object err");
                }
                else if (child.Uid.Equals("Variable"))
                {
                    bool check = Parser_Veriable(child);
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
                    string str = padding + "Serial.println(\"" + element.Text + "\");" ;
                    loopArea.Add(str);
                    return true;
                }

            }
            return false;    
        }
        bool Parser_Println(Grid child, string locate)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                TextBox element = VisualTreeHelper.GetChild(child, i) as TextBox;
                if (element != null)
                {
                    string str = padding + "Serial.println(\"" + element.Text + "\");";
                    if (locate.Equals("loop"))
                        loopArea.Add(str);
                    else if (locate.Equals("setup"))
                        setupArea.Add(str);
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
                    string str = padding + "delay(" + element.Text + ");";
                    
                    loopArea.Add(str);
                    return true;
                }

            }
            return false;
        }
        bool Parser_Delay(Grid child, string locate)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                TextBox element = VisualTreeHelper.GetChild(child, i) as TextBox;
                if (element != null)
                {
                    string str = padding + "delay(" + element.Text + ");";
                    if (locate.Equals("loop"))
                        loopArea.Add(str);
                    else if (locate.Equals("setup"))
                        setupArea.Add(str);
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
                    string str = padding + "// " + element.Text;
                    loopArea.Add(str);
                    return true;
                }

            }
            return false;
        }
        bool Parser_Note(Grid child, string locate)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                TextBox element = VisualTreeHelper.GetChild(child, i) as TextBox;
                if (element != null)
                {
                    string str = padding + "// " + element.Text;
                    if (locate.Equals("loop"))
                        loopArea.Add(str);
                    else if (locate.Equals("setup"))
                        setupArea.Add(str);
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

                if (element.GetType() == typeof(TextBox))  // get count
                {
                    Console.WriteLine("Find text box for get count");
                    TextBox textbox = element as TextBox;
                    string str = padding + "for ( counter" + check_counter + " = 0 ; counter" + check_counter + " < " + textbox.Text + " ; counter" + check_counter + "++ ) {";
                    
                    loopArea.Add(str);
                }
                else if(element.GetType() == typeof(ListBox))
                {
                    Console.WriteLine("Find Listbox");
                    ListBox listbox = element as ListBox;
                    CodePadding_Plus();
                    ChangeToCode_Loop(listbox);
                    CodePadding_Minus();
                }

            }
            
            check_counter -= 1;
            CodePadding_Minus();
            loopArea.Add(padding + "}");
            return false;
        }
        bool Parser_If(Grid child)
        {
            check_padding += 1;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                UIElement element = VisualTreeHelper.GetChild(child, i) as UIElement;

                if (element.GetType() == typeof(TextBox))  // get count
                {
                    Console.WriteLine("Find text box for get count");
                    TextBox textbox = element as TextBox;
                    string str = padding + "if ( "  + textbox.Text + " ) {";
                    loopArea.Add(str);
                }
                else if (element.GetType() == typeof(ListBox))
                {
                    Console.WriteLine("Find Listbox");
                    ListBox listbox = element as ListBox;
                    CodePadding_Plus();
                    ChangeToCode_Loop(listbox);
                    CodePadding_Minus();
                }

            }

            check_padding -= 1;
            CodePadding_Minus();
            loopArea.Add(padding + "}");
            return false;
        }
        bool Parser_PinMode(Grid child)
        {
            string port = null;
            string mode = null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                ComboBox element = VisualTreeHelper.GetChild(child, i) as ComboBox;
                if (element != null)
                {
                    if (element.Uid.Equals("PORT"))
                    {
                        ComboBoxItem item = element.SelectedItem as ComboBoxItem;
                        if (item != null)
                            port = item.Content.ToString();
                    }
                    else if (element.Uid.Equals("PINMODE"))
                    {
                        ComboBoxItem item = element.SelectedItem as ComboBoxItem;
                        if (item != null)
                            mode = item.Content.ToString();
                    }
                }

            }
            if ((port != null) && (mode != null))
            {
                ortherArea.Add("int " + port + " = " + CheckPortNumber(port) + ";");
                setupArea.Add(padding + "pinMode(" + port + ", " + mode + ");");
            }
            return true;
        }
        bool Parser_DigitalWrite(Grid child)
        {
            string port = null;
            string output = null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                ComboBox element = VisualTreeHelper.GetChild(child, i) as ComboBox;
                if (element != null)
                {
                    if (element.Uid.Equals("PORT"))
                    {
                        ComboBoxItem item = element.SelectedItem as ComboBoxItem;
                        if (item != null)
                            port = item.Content.ToString();
                    }
                    else if (element.Uid.Equals("OUTPUT"))
                    {
                        ComboBoxItem item = element.SelectedItem as ComboBoxItem;
                        if (item != null)
                            output = item.Content.ToString();
                    }
                }

            }
            Console.WriteLine("port : " + port + " output : " + output);
            if ((port != null) && (output != null))
            {
                loopArea.Add(padding + "digitalWrite(" + port + ", " + output + ");");
                return true;
            }
            else
                return false;
            
        }
        bool Parser_DigitalRead(Grid child)
        {
            string port = null;
            string name = null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                UIElement element = VisualTreeHelper.GetChild(child, i) as UIElement;

                if (element.GetType() == typeof(ComboBox))  // get count
                {
                    ComboBox combo = element as ComboBox;
                    ComboBoxItem item = combo.SelectedItem as ComboBoxItem;
                    if (item != null)
                        port = item.Content.ToString();
                }
                else if (element.GetType() == typeof(TextBox))
                {
                    TextBox txtbox = element as TextBox;
                    name = txtbox.Text;
                }

            }
            Console.WriteLine("port : " + port + " name : " + name);
            if ((port != null) && (name != null))
            {
                loopArea.Add(padding + name + " = digitalRead(" + port + ");");
                return true;
            }
            else
                return false;
        }
        bool Parser_Veriable(Grid child)
        {
            string data = null;
            string data2 = null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                UIElement element = VisualTreeHelper.GetChild(child, i) as UIElement;

                if (element.GetType() == typeof(ComboBox))  // get count
                {
                    ComboBox combo = element as ComboBox;
                    ComboBoxItem item = combo.SelectedItem as ComboBoxItem;
                    if (item != null)
                        data = item.Content.ToString();
                }
                else if (element.GetType() == typeof(TextBox))
                {
                    TextBox txtbox = element as TextBox;
                    data2 = txtbox.Text;
                }

            }
            Console.WriteLine("port : " + data + " data : " + data2);
            if ((data != null) && (data2 != null))
            {
                ortherArea.Add(data + " " + data2 + ";");
                return true;
            }
            else
                return false;
        }
        bool Parser_Veriable_Use(Grid child)
        {
            string name = null;
            string data = null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(child); i++)
            {
                UIElement element = VisualTreeHelper.GetChild(child, i) as UIElement;

                
                if (element.GetType() == typeof(TextBox))
                {
                    TextBox txtbox = element as TextBox;
                    if(txtbox.Uid.Equals("NAME"))
                    {
                        name = txtbox.Text;
                    }
                    else if(txtbox.Uid.Equals("DATA"))
                    {
                        data = txtbox.Text;
                    }
                }
            }
            Console.WriteLine("name : " + name + " data : " + data);
            if ((name != null) && (data != null))
            {
                loopArea.Add(padding + name + " = " + data + ";");
                return true;
            }
            else
                return false;
        }
        // for padding 
        void CodePadding_Plus()
        {
            //for (int i = 0; i < check_counter; i++)
            //{
                padding += padding_temp;
            //}
        }
        void CodePadding_Minus()
        {
            padding = padding.Substring(0 , 4 * (check_padding +  check_counter + 1) );
        }

        int CheckPortNumber(string port)
        {
            if (port.Equals("Digital_01"))
                return 1;
            else if (port.Equals("Digital_02"))
                return 2;
            else if (port.Equals("Digital_03"))
                return 3;
            else if (port.Equals("Digital_04"))
                return 4;
            else if (port.Equals("Digital_05"))
                return 5;
            else if (port.Equals("Digital_06"))
                return 6;
            else if (port.Equals("Digital_07"))
                return 7;
            else if (port.Equals("Digital_08"))
                return 8;
            else if (port.Equals("Digital_09"))
                return 9;
            else if (port.Equals("Digital_10"))
                return 10;
            else if (port.Equals("Digital_11"))
                return 11;
            else if (port.Equals("Digital_12"))
                return 12;
            else if (port.Equals("Digital_13"))
                return 13;
            else
                return 0;

        }

    }
}
