using MasterProject.DAL;
using MasterProject.Models;
using MasterProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MasterProject.BLL
{
    public class ClientBLL
    {
        public bool Register(Clients client)
        {
            ClientsDB clientDB = new ClientsDB();
            DataTable dt = clientDB.GetAllClients();
            foreach (DataRow dr in dt.Rows)
            {
                Clients clients = new Clients();
                clients.IDnum = dr["IDnum"].ToString();
                client.PhoneNumber = dr["PhoneNumber"].ToString();
                if (client.IDnum == clients.IDnum || client.PhoneNumber == clients.PhoneNumber)
                {
                    return false;
                }
            }
            return clientDB.InsertNewClient(client) > 0;
        }
    }
}