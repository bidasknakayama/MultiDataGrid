using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleButton.Models
{
    public class DataGridBox
    {
        public IEnumerable ItemsSource { get; set; }
        public int BoxId { get; set; }

        public DataGridBox(int BoxId)
        {
            this.BoxId = BoxId;
        }
        public DataGridBox(int BoxId, IEnumerable ItemsSource) : this(BoxId)
        {
            this.ItemsSource = ItemsSource;
        }
    }
}
