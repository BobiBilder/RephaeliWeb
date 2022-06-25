using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using MasterProject.DAL;
using MasterProject.Models;

namespace MasterProject.DAL
{
    public class BaseDB
    {
        OleDbConnection connection;//קשר למסד נתונים

        //connected
        protected OleDbCommand command;//פקודות למסד נתונים
        OleDbDataReader reader;//אובייקט לשמירת נתונים שהגיעו ממסד נתונים


        //disconnected
        OleDbDataAdapter adapter;
        DataSet ds;//אוסף טבלאות
        DataTable dt;//טבלה אחת
        protected List<string> ChangeSql { get; set; }

        public BaseDB()
        {
            this.connection = new OleDbConnection();
            this.command = new OleDbCommand();
            this.connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'C:\Users\bilde\OneDrive\Desktop\Visual Studio\Projects\MasterProject\App_Data\Rephaeli.accdb'";
            this.command.Connection = this.connection;
            this.ds = new DataSet();
            this.dt = new DataTable();
            this.ChangeSql = new List<string>();

        }
        public DataTable Select(SelectSQL selectsql)
        {
            // 1 בקשת נתונים מטבלה אחת
            // 2 בקשת נתונים מיותר מטבלה אחת
            this.command.CommandText = selectsql.Sql;//SQL
            this.dt.TableName = selectsql.TableName;
            try
            {
                this.connection.Open();
                this.reader = this.command.ExecuteReader();
                this.dt.Load(this.reader);

            }

            catch (Exception ex)
            {
                string error = ex.Message;
                return null;

            }

            finally
            {
                this.connection.Close();
            }

            return this.dt;
        }

        public DataSet Select(List<SelectSQL> selectsqls)
        {
            try
            {
                this.connection.Open();
                foreach (SelectSQL selectsql in selectsqls)
                {
                    this.command.CommandText = selectsql.Sql;
                    this.dt = new DataTable(selectsql.TableName);
                    this.reader = this.command.ExecuteReader();
                    this.dt.Load(this.reader);
                    this.ds.Tables.Add(this.dt);

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
            finally
            {
                this.connection.Close();
            }
            return this.ds;
        }

        public int ChangeData(string sql)
        {
            int rows = 0;
            this.command.CommandText = sql;
            try
            {
                this.connection.Open();
                rows = this.command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                string message = ex.Message;
                rows = 0;
            }
            finally
            {
                this.connection.Close();
            }
            return rows;
        }
        public int ChangeData(List<string> sqls)
        {
            int rows = 0;
            OleDbTransaction transaction = null;
            try
            {
                this.connection.Open();
                transaction = this.connection.BeginTransaction();
                this.command.Transaction = transaction;
                foreach (string sql in sqls)
                {
                    this.command.CommandText = sql;
                    rows = rows + this.command.ExecuteNonQuery();
                }
                transaction.Commit();
            }catch(Exception ex)
            {
                string message = ex.Message;
                rows = 0;
                transaction.Rollback();
            }
            finally
            {
                this.connection.Close();
                this.ChangeSql.Clear();
            }
            return rows;
        }

        public int AddObject(BaseModel baseModel)
        {
            int rows = 0;
            OleDbTransaction transaction = null;
            try
            {
                this.connection.Open();
                transaction = this.connection.BeginTransaction();
                this.command.Transaction = transaction;
                ChangeBaseModel(baseModel, 1);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                rows = 0;
                transaction.Rollback();
            }
            finally
            {
                this.connection.Close();
                this.ChangeSql.Clear();
            }
            return rows;
        }

        public int ChangeBaseModel(BaseModel baseModel, int action)//chainging the DataBase in 3 different ways, adding/deleting/updating
        {
            OleDbTransaction transaction = null;
            try
            {
                this.connection.Open();
                transaction = this.connection.BeginTransaction();
                this.command.Transaction = transaction;

                int x = 0;
                switch (action)
                {
                    case 1:
                        x = AddModel(baseModel);
                        transaction.Commit();
                        break;
                    case 2:
                        x = DeleteModel(baseModel);
                        transaction.Commit();
                        break;
                    case 3:
                        x = UpdateModel(baseModel);
                        transaction.Commit();
                        break;
                }
                return x;
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                return 0;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public virtual int AddModel(BaseModel baseModel)//nothing much to explain here, its getting overridden (override) in the DAL
        {
            return 0;
        }
        public virtual int DeleteModel(BaseModel baseModel)//nothing much to explain here, its getting overridden (override) in the DAL
        {
            return 0;
        }
        public virtual int UpdateModel(BaseModel baseModel)//nothing much to explain here, its getting overridden (override) in the DAL
        {
            return 0;
        }
    }
}