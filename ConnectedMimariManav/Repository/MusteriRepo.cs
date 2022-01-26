using ConnectedMimariManav.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedMimariManav.Repository
{
    public class MusteriRepo : BaseRepo, IRepository<Musteri>
    {
        

        public List<Musteri> GetAll()
        {
            List<Musteri> Musteriler = new List<Musteri>();
            try
            {
                SqlCommand command = new SqlCommand("Sp_MusteriGetir", this.con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                ConOpen();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Musteri Musteri = new Musteri();
                    Musteri.MusteriID = Convert.ToInt32(reader["MusteriID"]);
                    Musteri.MusteriAd = reader["MusteriAd"].ToString();
                    Musteri.MusteriSoyad = reader["MusteriSoyad"].ToString();
                    Musteri.MusteriTelefon = reader["MusteriTelefon"].ToString();
                    Musteri.MusteriAdres = reader["MusteriAdres"].ToString();
                    Musteriler.Add(Musteri);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                ConClose();
            }
            return Musteriler;
        }

        public Musteri Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Musteri entity)
        {
            throw new NotImplementedException();
        }

        public int Create(Musteri entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Musteri Mapping(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void ConOpen()
        {
            if (con.State == System.Data.ConnectionState.Closed) con.Open();
        }

        public void ConClose()
        {
            if (con.State == System.Data.ConnectionState.Open) con.Close();
        }
    }
}
