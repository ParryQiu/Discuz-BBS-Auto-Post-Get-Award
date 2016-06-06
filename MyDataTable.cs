using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DiscuzBBSAutoLogin
{
    /// <summary>
    /// MyDataTable
    /// </summary>
    [Serializable]
    public class MyDataTable
    {
        public DataTable StoreDataTable { get; set; }

        public MyDataTable()
        {
            if (File.Exists(Application.StartupPath + "\\Data.xml"))
            {
                StoreDataTable = MyDataSource.Read();
            }
            else
            {
                StoreDataTable = new DataTable("DiscuzData");
                DataColumn dataColumn = new DataColumn("TopicID", typeof(int));
                StoreDataTable.Columns.Add(dataColumn);
                StoreDataTable.Columns.Add("HitFloorIDs", typeof(string));
                StoreDataTable.Columns.Add("CurrentFloor", typeof(string));
                StoreDataTable.Columns.Add("Content", typeof(string));
                StoreDataTable.Columns.Add("Status", typeof(string));
                StoreDataTable.PrimaryKey = new[] { dataColumn };
                Save();
            }
        }

        public void Add(int topicID, int hitFloorIDs, string status)
        {
            DataRow dataRow = StoreDataTable.NewRow();
            dataRow["TopicID"] = topicID;
            dataRow["HitFloorIDs"] = hitFloorIDs;
            dataRow["Status"] = status;
            StoreDataTable.Rows.Add(dataRow);
            Save();
        }

        public void Add(int topicID, int hitFloorIDs, string content, string status)
        {
            DataRow dataRow = StoreDataTable.NewRow();
            dataRow["TopicID"] = topicID;
            dataRow["HitFloorIDs"] = hitFloorIDs;
            dataRow["Content"] = content;
            dataRow["Status"] = status;
            StoreDataTable.Rows.Add(dataRow);
            Save();
        }

        public void Save()
        {
            MyDataSource.Save(StoreDataTable);
        }
    }
}
