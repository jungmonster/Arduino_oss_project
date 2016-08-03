using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections;


namespace Banana_Project
{
    // Mouse Event Helper Class
    static class MouseEventHelper
    {
        // CodeListView에서 
        public static int findCodeListItemIndex(ListBox parent, DependencyObject obj)
        {
            if (obj == null)
                return -1;

            if (obj.GetType() == typeof(Grid))
            {
                Grid item = obj as Grid;
                if (MouseEventHelper.CheckCodeNodeUID(item.Uid))
                {
                    return parent.Items.IndexOf(item);
                }
                else
                    return -1;
            }
            else
            {
                UIElement pt = VisualTreeHelper.GetParent(obj) as UIElement;
                if (pt.GetType() == typeof(Grid))
                {
                    Grid item = pt as Grid;
                    if (item == null)
                        return -1;
                    if (MouseEventHelper.CheckCodeNodeUID(item.Uid))
                    {
                        return parent.Items.IndexOf(item);
                    }
                    else
                        return -1;
                }
                else
                    return -1;
            }

        }

        public static object GetDataFromNodeList(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (element == source)
                    {
                        return null;
                    }
                }

                if (data != DependencyProperty.UnsetValue)
                {
                    return new DataObject("NodeList", data, true);
                }
            }

            return null;
        }

        // check UID
        public static bool CheckCodeNodeUID(string UID)
        {
            if (UID.Equals("codeItem"))
                return true;
            else
                return false;
        }

    }
}
