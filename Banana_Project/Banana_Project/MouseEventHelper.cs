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
            if (parent.Items.IndexOf(obj) != -1)
                return parent.Items.IndexOf(obj);

            UIElement pt = VisualTreeHelper.GetParent(obj) as UIElement;
            while (!(pt is ListBoxItem) && !(pt is MainWindow) && parent.Items.IndexOf(pt) == -1)
            {
                obj = pt;
                pt = VisualTreeHelper.GetParent(obj) as UIElement;
            }

            return parent.Items.IndexOf(pt);
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
