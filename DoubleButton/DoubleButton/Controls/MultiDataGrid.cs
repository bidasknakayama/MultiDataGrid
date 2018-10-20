using DoubleButton.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DoubleButton.Controls
{
    // Reference
    // https://docs.microsoft.com/ja-jp/dotnet/framework/wpf/controls/creating-a-control-that-has-a-customizable-appearance
    // https://github.com/jenspettersson/WPF-Controls/tree/master/src/WPFControls.Layout
    //[TemplatePart(Name = PartName_Dg_StackPanel, Type = typeof(StackPanel))]
    [TemplatePart(Name = PartName_Dg_ItemsControl, Type = typeof(ItemsControl))]

    public class MultiDataGrid : Control
    {
        #region Parts name
        // Template Parts.
        private const string PartName_Dg_ItemsControl = "Dg_ItemsControl";
        private ItemsControl Dg_ItemsControl;




        #endregion
        #region DependencyProperty Content
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSource",
                typeof(IEnumerable),
                typeof(MultiDataGrid),
                new PropertyMetadata(null, new PropertyChangedCallback(OnDisplayChanged)));
        
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }

        }
        #endregion
        #region privates
        private List<DataGridBox> DataGridBoxes = new List<DataGridBox>();

        #endregion
        #region Basic
        public MultiDataGrid()
        {
            DefaultStyleKey = typeof(MultiDataGrid);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            Dg_ItemsControl = GetTemplateChild(PartName_Dg_ItemsControl) as ItemsControl;

            
        }
        #endregion 
        #region PropertyChangedCallback

        private void OnDisplayChanged(DependencyObject d)
        {

            MultiDataGrid _m = (MultiDataGrid)d;

            int max = 5;

            if (Dg_ItemsControl != null)
            {
                Debug.WriteLine($"Dg_ItemsControl");

                List<object> list = new List<object>(ItemsSource.Cast<object>());

                for (int i = 0; i < 4; i++)
                {
                    DataGridBox box = new DataGridBox(i);
                    int startIndex = i * max;
                    int endIndex = startIndex + (max - 1);

                    if (endIndex >= list.Count)
                    {
                        int endItem = list.Count - startIndex;
                        Debug.WriteLine($"start/{startIndex}/Count/{endItem}");
                        box.ItemsSource = list.GetRange(startIndex, endItem);
                        DataGridBoxes.Add(box);
                        break;
                    }
                    else
                    {
                        Debug.WriteLine($"start/{startIndex}/Count/{max}");
                        box.ItemsSource = list.GetRange(startIndex, max);
                        DataGridBoxes.Add(box);
                    }
                }



                Dg_ItemsControl.ItemsSource = DataGridBoxes;
            }


        }
        private static void OnDisplayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MultiDataGrid)d).OnDisplayChanged(d);
        }

        
        #endregion
        #region PrivateClass
        public void Sorting()
        {
            Debug.WriteLine($"Ok, Sort start !");
        }

        #endregion

    }
    
}
