using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflection
{
	public static class CsvSerealizer 
    {
        private static readonly string _delimerKeyValue = ",";
        private static readonly string _delimerFields = Environment.NewLine;
        public static readonly BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        /// <summary> Serialize from object to CSV </summary>
        /// <param name="obj">any object</param>
        /// <returns>CSV</returns>
        public static string SerializeFromObjectToCSV(object obj)
        {
            StringBuilder sb = new StringBuilder();
            Type targetType = obj.GetType();
            IList<FieldInfo> fields = targetType.GetFields(bindingAttr: bindFlags).ToList();
            foreach (FieldInfo field in fields)
            {
                var fieldValue = field.GetValue(obj);
                sb.Append(field.Name + _delimerKeyValue + fieldValue);
                sb.Append(_delimerFields);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="csv"></param>
        /// <returns></returns>
        public static T DeserializeFromCSVToInstance<T>(string csv) where T : class, new()
        {
            var fields = typeof(T).GetFields(bindingAttr: bindFlags).ToList();
            T obj = new T();
            Dictionary<string, string> fieldValue = new Dictionary<string, string>();
			foreach (var row in csv.Split(_delimerFields))
			{
                var fieldStr = row.Split(_delimerKeyValue);
                if (fieldStr.Length != 2) continue;
                FieldInfo fieldInfo = fields.Where(f => f.Name == fieldStr[0]).FirstOrDefault();
                if (fieldInfo == null) continue;
                fieldInfo.SetValue(obj, Convert.ChangeType(fieldStr[1], fieldInfo.FieldType));
            }
            return obj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetCsvBodyFromFolder(string path)
		{
            using (FileStream fsSource = new FileStream(path,
            FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fsSource);
                long numBytes = new FileInfo(path).Length;
                return br.ReadString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public static void SaveCsvToFolder(string path, string data)
        {
            string pathFolder = path.Substring(0, path.LastIndexOf('\\'));
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
            }
            using (FileStream fsSource = new FileStream(path,
            FileMode.Create, FileAccess.ReadWrite))
            {
                BinaryWriter bw = new BinaryWriter(fsSource);
                bw.Write(data);
            }
        }
    }
}
