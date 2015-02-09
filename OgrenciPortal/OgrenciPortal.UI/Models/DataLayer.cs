using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace OgrenciPortal.Provider
{
    public class DataLayer
    {
        private SqlConnection conn;

        public DataLayer()
        {
            conn = new SqlConnection(OgrenciPortal.UI.Properties.Settings.Default.cnString);
        }

        public DataLayer(string connStr)
        {
            conn = new SqlConnection(connStr);
        }

        public DataTable Getir(string sqlStr)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter dap = new SqlDataAdapter();

            command.CommandTimeout = 0;//Çalıştırılacak olan sorgunun işlenme süresini belirtmek için kullanılır.Varsayılan olarak 30sn'dir.
            command.Connection = conn;
            command.CommandText = sqlStr;
            dap.SelectCommand = command;

            conn.Open();//SqlAdapter nesnesi kullanıldığı için conn aç kapaya gerek yoktur.
            dap.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable Getir(string sqlStr, Hashtable parameter)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter dap = new SqlDataAdapter();
            command.CommandTimeout = 0;//timeout a düşmesini önlemek amacıyla,command in timeout özelliği sıfıra çekilmiş.
            command.Connection = conn;
            command.CommandText = sqlStr;
            ParametreEkle(command, parameter);
            dap.SelectCommand = command;

            conn.Open();//SqlAdapter nesnesi kullanıldığı için conn aç kapaya gerek yoktur.
            dap.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable Getir(string sqlStr, Hashtable parameter, CommandType cmdType)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand();
            command.CommandType = cmdType;
            SqlDataAdapter dap = new SqlDataAdapter();

            command.CommandTimeout = 0;
            command.Connection = conn;
            command.CommandText = sqlStr;
            ParametreEkle(command, parameter);
            dap.SelectCommand = command;

            conn.Open();
            dap.Fill(dt);
            conn.Close();

            return dt;
        }

        public int SorguCalistir(string sqlStr)
        {
            int donus = 0;
            SqlCommand command = new SqlCommand();
            command.CommandTimeout = 0;
            command.Connection = conn;
            command.CommandText = sqlStr;

            conn.Open();
            donus = command.ExecuteNonQuery();
            conn.Close();

            return donus;
        }

        public int SorguCalistir(string sqlStr, Hashtable prm)
        {
            int donus = 0;
            SqlCommand command = new SqlCommand();
            command.CommandTimeout = 0;
            command.Connection = conn;
            command.CommandText = sqlStr;
            ParametreEkle(command, prm);

            conn.Open();
            donus = command.ExecuteNonQuery();
            conn.Close();

            return donus;
        }

        public int SorguCalistir(string sqlStr, Hashtable prm, CommandType cmdType)
        {
            int donus = 0;
            SqlCommand command = new SqlCommand();
            command.CommandTimeout = 0;
            command.CommandType = cmdType;
            command.Connection = conn;
            command.CommandText = sqlStr;
            ParametreEkle(command, prm);

            conn.Open();
            donus = command.ExecuteNonQuery();
            conn.Close();

            return donus;
        }

        private void ParametreEkle(SqlCommand cmd, Hashtable parameters)
        {
            foreach (DictionaryEntry item in parameters)
            {
                if (String.IsNullOrEmpty(item.Value.ToString()))
                    cmd.Parameters.AddWithValue(item.Key.ToString(), DBNull.Value);
                else
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
            }
        }

        public string Sifrele(string veri)
        {
            byte[] veriByteDizisi = System.Text.ASCIIEncoding.ASCII.GetBytes(veri);
            string sifrelenmisVeri = System.Convert.ToBase64String(veriByteDizisi);
            return sifrelenmisVeri;
        }

        public string SifreCoz(string veri)
        {
            byte[] veriByteDizisi = System.Convert.FromBase64String(veri);
            string orjinalVeri = System.Text.ASCIIEncoding.ASCII.GetString(veriByteDizisi);
            return orjinalVeri;
        }
    }
}