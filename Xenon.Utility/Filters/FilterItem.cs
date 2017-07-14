using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.Utility.Filters
{
    /// <summary>
    /// Represents one item in a filter.
    /// </summary>
    public class FilterItem
    {
        /// <summary>
        /// Textual label for the filter item. Display to the user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The value to check when the item is enabled. 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Indicates this item should be applied in the filter. 
        /// </summary>
        public bool Enabled { get; set; }

        public FilterItem() { }

        public FilterItem(string label, string value)
        {
            this.Label = label;
            this.Value = value;
            this.Enabled = true;
        }

        public FilterItem(string label, string value, bool enabled)
        {
            this.Label = label;
            this.Value = value;
            this.Enabled = enabled;
        }
    }
}
