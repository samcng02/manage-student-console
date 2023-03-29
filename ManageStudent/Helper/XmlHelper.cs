using System;
using System.IO;
using System.Xml.Serialization;

namespace ManageStudent.Helper
{
    internal static class XmlHelper
    {
        public static T Deserialize<T>(this string value)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(new StringReader(value));
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public static string Serialize<T>(this T value)
        {
            using (var writer = new StringWriter())
            {
                value.ToXml(writer);
                return writer.ToString();
            }
        }

        private static void ToXml<T>(this T objectToSerialize, StringWriter writer)
        {
            new XmlSerializer(typeof(T)).Serialize(writer, objectToSerialize);
        }
    }
}
