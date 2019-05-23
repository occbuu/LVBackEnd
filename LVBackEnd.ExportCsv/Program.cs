using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace LVBackEnd.ExportCsv
{
    class Program
    {
        const string TABLE = "Luan.[Rule]";
        const string DEFAULT_COLUMNS = "Id,VT,VP";

        static List<int> lsColumn = new List<int>();
        static List<Record> lsRecord = new List<Record>();

        static public string textFile = "";

        class Config
        {
            public string DataSource;
            public string UserID;
            public string Password;
            public string InitialCatalog;
        }

        class Record
        {
            public int Id;
            public List<int> ListCode;
        }

        static void ReadRecord(int id, string code)
        {
            if (code == null || code == "") return;

            var ls = new List<int>();
            var t = code.Split(',');

            foreach (var i in t)
            {
                if (i == null || i.Trim() == "") continue;

                var t2 = int.Parse(i.Replace("{", "").Replace("}", ""));

                var index = lsColumn.IndexOf(t2);
                if (index == -1)
                {
                    lsColumn.Add(t2);
                }

                ls.Add(t2);
            }

            lsRecord.Add(new Record
            {
                Id = id,
                ListCode = ls
            });
        }

        static void AddCell(string text = null, bool first = false)
        {
            if (text == null)
            {
                textFile += Environment.NewLine;
                return;
            }
            var t = first ? "" : ",";
            textFile += t + text;
        }

        private static Config readConfig()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
            using (var reader = new StreamReader(@path))
            {
                var value = "";
                while (!reader.EndOfStream)
                {
                    value = reader.ReadLine();
                }

                var a = value.Split(',');

                Console.WriteLine(a[0].Substring(value.IndexOf("=") + 1));

                return new Config
                {
                    DataSource = a[0].Substring(a[0].IndexOf("=") + 1),
                    UserID = a[1].Substring(a[1].IndexOf("=") + 1),
                    Password = a[2].Substring(a[2].IndexOf("=") + 1),
                    InitialCatalog = a[3].Substring(a[3].IndexOf("=") + 1)
                };
            }
        }

        static void Main(string[] args)
        {
            try
            {
                //var config = readConfig();

                var config = new Config
                {
                    DataSource = ".\\SQLEXPRESS",
                    UserID = "sa",
                    Password = "Password123",
                    InitialCatalog = "LVBackEnd"
                };

                // Build connection string
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = config.DataSource.Replace("\\\\", "\\");
                builder.UserID = config.UserID;
                builder.Password = config.Password;
                builder.InitialCatalog = config.InitialCatalog;

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... \n");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    // Read
                    var sql = string.Format("SELECT {1} FROM {0};", TABLE, DEFAULT_COLUMNS);
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ReadRecord(reader.GetInt32(0), reader.GetString(1));
                            }
                            lsColumn.Sort();
                        }
                    }

                    var sb = new StringBuilder();
                    sb.Append(string.Format("USE {0}; ", config.InitialCatalog));

                    // Add header
                    AddCell(DEFAULT_COLUMNS + ",", true);
                    AddCell(string.Join(",", lsColumn), true);
                    AddCell();

                    foreach (var i in lsColumn)
                    {
                        Console.WriteLine("\nChecking column [{0}]", i);

                        sb.Clear();
                        sb.Append("if not exists(select * from sys.columns");
                        sb.Append(string.Format(" where Name = N'{0}' and Object_ID = Object_ID(N'{1}')) ", i, TABLE));
                        sb.Append(" begin");
                        sb.Append(string.Format(" ALTER TABLE {0}", TABLE));
                        sb.Append(string.Format(" ADD [{0}] bit; ", i));
                        sb.Append(" end");
                        sql = sb.ToString();
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        // Update record at comlum i
                        for (var j = 0; j < lsRecord.Count; j++)
                        {
                            Console.WriteLine("Id: {0}", lsRecord[j].Id);

                            var isHave = lsRecord[j].ListCode.IndexOf(i) != -1 ? "1" : "0";

                            sb.Clear();
                            sb.Append(string.Format("UPDATE {2} SET [{0}] = {1} WHERE Id = @id", i, isHave, TABLE));

                            sql = sb.ToString();
                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@id", lsRecord[j].Id);
                                int rowsAffected = command.ExecuteNonQuery();
                                Console.WriteLine(rowsAffected + " row(s) updated");
                            }
                        }
                    }

                    var list = new List<string>();

                    foreach (var i in lsColumn)
                    {
                        list.Add(string.Format("[{0}]", i));
                    }

                    // Write file
                    sql = string.Format("SELECT {2}, {0} FROM {1};", string.Join(",", list), TABLE, DEFAULT_COLUMNS);
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AddCell(reader.GetInt32(0).ToString(), true);
                                AddCell(reader.GetString(1).Replace(",", ""));
                                AddCell(reader.GetString(2));

                                var lenColumn = DEFAULT_COLUMNS.Split(',').Length;
                                for (var j = lenColumn; j < reader.FieldCount; j++)
                                {
                                    AddCell(reader.GetBoolean(j).ToString());
                                }

                                AddCell();
                            }
                        }
                    }

                    var time = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    WriteFile(textFile, "Rule_" + time + ".csv");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nAll done. Press any key to finish...");
            Console.ReadKey(true);
        }

        private static void WriteFile(string text, string filename)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            File.WriteAllText(path, text);
        }
    }
}
