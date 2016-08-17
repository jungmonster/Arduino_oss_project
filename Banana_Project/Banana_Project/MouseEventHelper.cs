using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Banana_Project
{
    // Mouse Event Helper Class
    static class MouseEventHelper
    {
        
        // Check block index in listbox
        public static int findCodeListItemIndex(ListBox parent, DependencyObject obj)
        {
            if (obj == null)
                return -1;

            if (obj.GetType() == typeof(Grid))
            {
                Grid item = obj as Grid;
                if(item != null)
                    return parent.Items.IndexOf(item);
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
                    if (item != null)
                        return parent.Items.IndexOf(item);
                    else
                        return -1;
                }
                else
                    return -1;
            }

        }

        // Check block collection in listbox
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
        public static object GetDataFromSetupList(ListBox source, Point point)
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
                    return new DataObject("SetupList", data, true);
                }
            }

            return null;
        }

    }
}
