using ConnectedMimariManav.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    Musteri Musteri = Mapping(reader);
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
            Musteri Musteri=null;
            try
            {
                SqlCommand command = new SqlCommand("Sp_MusteriGetir", this.con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MusteriID", id);
                ConOpen();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Musteri = Mapping(reader);
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
            return Musteri;
        }

        public int Update(Musteri entity)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Musteri_InsertveUpdate",con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MusteriID", entity.MusteriID);
                command.Parameters.AddWithValue("@MusteriAd", entity.MusteriAd);
                command.Parameters.AddWithValue("@MusteriSoyad", entity.MusteriSoyad);
                command.Parameters.AddWithValue("@MusteriTelefon", entity.MusteriTelefon);
                command.Parameters.AddWithValue("@MusteriAdres", entity.MusteriAdres);
                ConOpen();
                id = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                ConClose();
            }
            return id;
        }

        public int Create(Musteri entity)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Musteri_InsertveUpdate",con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MusteriID", entity.MusteriID);
                command.Parameters.AddWithValue("@MusteriAd", entity.MusteriAd);
                command.Parameters.AddWithValue("@MusteriSoyad", entity.MusteriSoyad);
                command.Parameters.AddWithValue("@MusteriTelefon", entity.MusteriTelefon);
                command.Parameters.AddWithValue("@MusteriAdres", entity.MusteriAdres);
                ConOpen();
                id=Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                ConClose();
            }
            return id;

        }

        public void Delete(int id)
        {
            if (MessageBox.Show("Silmek İstediğine Emin misin?", "Silme İşlemi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    SqlCommand command = new SqlCommand("Sp_Musteri_Delete", con);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MusteriID", id);
                    ConOpen();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {
                    ConClose();
                } 
            }
        }

        public Musteri Mapping(SqlDataReader reader)
        {
            Musteri Musteri = new Musteri();
            Musteri.MusteriID = Convert.ToInt32(reader["MusteriID"]);
            Musteri.MusteriAd = reader["MusteriAd"].ToString();
            Musteri.MusteriSoyad = reader["MusteriSoyad"].ToString();
            Musteri.MusteriTelefon = reader["MusteriTelefon"].ToString();
            Musteri.MusteriAdres = reader["MusteriAdres"].ToString();
            return Musteri;
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
