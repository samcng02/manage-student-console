using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace ManageStudent.Helper
{
    internal static class CsvHelper
    {
        public static List<string> Serialize<T>(this List<T> value)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            //lines.Add(header);
            var valueLines = value.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);

            return lines;
        }
    }
}
