using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.Utility.Filters
{
    /// <summary>
    /// Filter represents a group of items that can be checked or unchecked to 
    /// apply a filter to a list.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// The textual label for the group of filter items.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The key for the items. This is usually the name of the column to 
        /// which the filter will be applied. 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The collection of values which this filter may have. 
        /// </summary>
        public ICollection<FilterItem> Items{ get; set; }

        /// <summary>
        /// Flag indicating that all items should be shown. No filter is necesssary.
        /// </summary>
        public bool ShowAll
        {
            get { return Items.Any(i => !i.Enabled); }
        }

        public Filter() { }

        public Filter(string label)
        {
            Label = label;
            Key = label;
            Items = new List<FilterItem>();
        }

        public Filter(string label, string key)
        {
            Label = label;
            Key = key;
            Items = new List<FilterItem>();
        }

        public Filter(string label, string key, ICollection<string> items)
        {
            Label = label;
            Key = key;
            Items = items.Select(s => new Filters.FilterItem(s, s)).ToList();
        }

        public Filter(string label, string key, ICollection<FilterItem> items)
        {
            Label = label;
            Key = key;
            Items = items;
        }

        /// <summary>
        /// Build a filter from a list of objects.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="label">The textual label for this filter.</param>
        /// <param name="key">The key for this filter (usually a column name to filter on).</param>
        /// <param name="items">A list of items from which to build the filter</param>
        /// <param name="labelProperty">Name of the label property on the item list.</param>
        /// <param name="valueProperty">Name of the value property on the list.</param>
        /// <returns></returns>
        public static Filter Create<T>(string label, string key, ICollection<T> items, string labelProperty, string valueProperty)
        {
            Type type = typeof(T);
            PropertyInfo labelProp = type.GetProperty(labelProperty);
            PropertyInfo valueProp = type.GetProperty(valueProperty);
            return new Filters.Filter(label, key, items.Select(i => new FilterItem(labelProp.GetValue(i).ToString(), valueProp.GetValue(i).ToString(), true)).ToList());

        }
    }
}
