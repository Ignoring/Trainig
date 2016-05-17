using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;

namespace TraningDAL.InterfaceBasics
{
    public interface IMySqlConnector
    {
        string Server { get; set; }
        int Port { get; set; }
        string DB { get; set; }
        string User { get; set; }
        string Password { get; set; }

        MySqlConnection Connector { get; set; }

        bool Connect();
        bool IsConnect();
        DataTable GetData(string selectComand);
        bool Disconnect();
    }


    public abstract class MySqlConnectorBase : IMySqlConnector
    {
        private string server = "127.0.0.1";
        public virtual string Server { get { return this.server; } set { this.server = value; } }
        public int port = 3309;
        public virtual int Port { get { return this.port; } set { this.port = value; } }
        private string db = "training";
        public virtual string DB { get { return this.db; } set { this.db = value; } }
        private string user = "root";
        public virtual string User { get { return this.user; } set { this.user = value; } }
        private string password = "";
        public virtual string Password { get { return this.password; } set { this.password = value; } }

        private MySqlConnection connector;
        public MySqlConnection Connector { get { return this.connector; } set { this.connector = value; } }

        
        public virtual bool Connect()
        {

            var connectString = string.Concat("Database=", this.db, ";Server=", this.server, ";port=", this.port.ToString(), ";Uid=", this.user);
            //var ConnectString = string.Concat("server=", this.server, ":3309", ";uid=", this.user);
            if (!string.IsNullOrWhiteSpace(password))
                connectString = string.Concat("pwd=", this.password);
            this.connector = new MySqlConnection();
            this.connector.ConnectionString = connectString;

            try
            {
                this.connector.Open();
                return true;
            }
            catch (MySqlException ex) {ex.ToString();}
            return false;
        }

        public bool IsConnect()
        {
            return this.connector != null && this.connector.State == ConnectionState.Open;
        }
        
        public virtual bool Disconnect()
        {
            if (this.IsConnect())
                try
                {
                    this.connector.Dispose();
                    this.connector = null;
                    return true;
                }
                catch (MySqlException ex) { ex.ToString(); }
                catch (Exception ex) { ex.ToString(); }
            return false;
        }

        public DataTable GetData(string selectCommand)
        {
            if (!this.IsConnect() || string.IsNullOrWhiteSpace(selectCommand))
                return null;
            var table = new DataTable();
            try
            {
                var ad = new MySqlDataAdapter();
                ad.SelectCommand = new MySqlCommand(selectCommand, this.connector);
                ad.Fill(table);
            }
            catch (MySqlException ex) { ex.ToString(); }
            catch (Exception ex) { ex.ToString(); }

            return table;
        }

        public bool Command(string command)
        {
            if (!this.IsConnect() || string.IsNullOrWhiteSpace(command))
                return false;
            try
            {
                var ad = new MySqlDataAdapter();
                var comm = new MySqlCommand(command, this.connector);
                comm.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex) { ex.ToString(); }
            catch (Exception ex) { ex.ToString(); }

            return false;
        }

        public MySqlConnectorBase(string server = "127.0.0.1", int port = 3309, string user = "root", string password = "")
        {
            this.server = server;
            this.port = port;
            this.user = user;
            this.password = password;
        }

        public static DataTable GetData(string server = "127.0.0.1", int port = 3309, string user = "root", string password = "", string selectCommand = "")
        {
            var con = new MySqlConnectorEmpty(server, port, user, password);
            if (con.Connect())
                return con.GetData(selectCommand);
            return null;
        }

        public static bool Command(string server = "127.0.0.1", int port = 3309, string user = "root", string password = "", string command = "")
        {
            var con = new MySqlConnectorEmpty(server, port, user, password);
            if (con.Connect())
                return con.Command(command);
            return false;
        }

        public class MySqlConnectorEmpty : MySqlConnectorBase
        {
            public MySqlConnectorEmpty(string server = "root", int port = 3309, string user = "root", string password = "")
                : base(server, port, user, password)
            {
            }
        }
    }

}
