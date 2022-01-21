using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceBus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelpon, int JumlahPemesanan, string IDBus)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Pemesanan values ('" + IDPemesanan + "', '" + NamaCustomer + "', '" + NoTelpon + "', " + JumlahPemesanan + " , '" + IDBus + "')";
                connection = new SqlConnection(constring); //fungsi konek ke database
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                string sql2 = "update dbo.Lokasi set Kuota = Kuota - " + JumlahPemesanan + " where ID_bus = '" + IDBus + "' ";
                connection = new SqlConnection(constring); //fungsi konek ke database
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string editPemesanan(string IDPemesanan, string NamaCustomer, string No_Telpon)
        {
            throw new NotImplementedException();
        }

        public string deletePemesanan(string IDPemesanan)
        {
            throw new NotImplementedException();
        }

        public List<CekBus> ReviewBus()
        {
            throw new NotImplementedException();
        }

        public List<DetailBus> DetailBus()
        {
            List<DetailBus> LokasiFull = new List<DetailBus>(); //proses untuk mendeclare nama list yang telah dibuat dengan nama baru
            try
            {
                string sql = "select ID_bus, Nama_bus, Deskripsi_full, Kuota from dbo.Lokasi"; //declare wuery
                connection = new SqlConnection(constring); //fungsi konek ke database
                com = new SqlCommand(sql, connection); //proses execute wuery
                connection.Open(); //membuka koneksi
                SqlDataReader reader = com.ExecuteReader(); //menampilkan data query
                while (reader.Read())
                {
                    /* nama */
                    DetailBus data = new DetailBus(); //deklarasi data, mengambiil 1 persatu dari database
                    //bentuk array
                    data.IDBus = reader.GetString(0); //0 itu inndex. ada dikolom keberapa di string sql database
                    data.NamaBus = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(2);
                    data.Kuota = reader.GetInt32(3);
                    LokasiFull.Add(data); //mengumpulkan data yang awalanya dari array
                }
                connection.Close(); //untuk menutup akses ke database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LokasiFull;
        }

        public List<Pemesanan> Pemesanan()
        {
            throw new NotImplementedException();
        }

        public string Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string Register(string username, string password, string kategori)
        {
            throw new NotImplementedException();
        }

        public string UpdateRegister(string username, string password, string kategori)
        {
            throw new NotImplementedException();
        }

        public string DeleteRegister(string username)
        {
            throw new NotImplementedException();
        }

        public List<DataRegister> DataRegist()
        {
            throw new NotImplementedException();
        }

        string constring = "Data Source=LAPTOP-ECDRVQ51\\ZAHRAA;Initial Catalog=BusBerkah;Persist Security Info=true;User ID=sa;Password=Zahra19!";
        SqlConnection connection;
        SqlCommand com; //untuk mengkoneksikan database ke visual studio
    }
}
