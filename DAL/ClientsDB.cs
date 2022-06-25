using System;
using MasterProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MasterProject.DAL
{
    public class ClientsDB : BaseDB
    {
        SelectSQL selectsql;
        public ClientsDB()
        {
            this.selectsql = new SelectSQL();
            selectsql.TableName = "Clients";
        }
        public DataTable GetAllClients()
        {
            selectsql.Sql = "select * from Clients";
            return this.Select(this.selectsql);
        }

        public int InsertNewClient(Clients client)
        {
            string sql = string.Format(@"insert into Clients(FirstName, LastName, PhoneNumber ,[Email], [IDnum], [Password])
                                       values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                                       client.FirstName, client.LastName, client.PhoneNumber, client.Email, client.IDnum, client.Password);
            return this.ChangeData(sql);
        }
    }
}