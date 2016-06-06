using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DiscuzBBSAutoLogin
{
    using System.Data;

    /// <summary>
    /// 数据源
    /// </summary>
    public class MyDataSource
    {
        /// <summary>
        /// XML保存的路径
        /// </summary>
        private static readonly string xmlPath = Application.StartupPath + "\\Data.xml";

        /// <summary>
        /// 读取
        /// </summary>
        /// <returns></returns>
        public static DataTable Read()
        {
            DataTable dataTable = new DataTable();
            dataTable.ReadXml(xmlPath);
            return dataTable;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public static void Save(DataTable dataTable)
        {
            dataTable.WriteXml(xmlPath,XmlWriteMode.WriteSchema);
        }
    }
}
