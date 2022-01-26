using ConnectedMimariManav.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedMimariManav.Repository
{
    public class KategoriRepo : BaseRepo, IRepository<Kategori>
    {
        

        public List<Kategori> GetAll()
        {
            List<Kategori> Kategoriler=new List<Kategori>();
            try
            {
                SqlCommand command = new SqlCommand("Sp_KategoriGetir", this.con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                ConOpen();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Kategori Kategori=new Kategori();
                    Kategori.KategoriID = Convert.ToInt32(reader["KategoriID"]);
                    Kategori.KategoriAd = reader["KategoriAd"].ToString();
                    Kategori.KategoriDes = reader["KategoriDes"].ToString();
                    Kategoriler.Add(Kategori);
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
            return Kategoriler;
        }

        public Kategori Get(int id)
        {
            Kategori kategori = new Kategori();
            try
            {
                SqlCommand command = new SqlCommand("Sp_KategoriGetir", this.con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@KategoriID", id);
                ConOpen();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kategori = Mapping(reader);
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
            return kategori;
        }

        public int Create(Kategori entity)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Kategori_InsertUpdate", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@KategoriAd", entity.KategoriAd);
                command.Parameters.AddWithValue("@KategoriDes", entity.KategoriDes);
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
            throw new NotImplementedException();
        }
        public int Update(Kategori entity)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Kategori_InsertUpdate", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@KategoriID",entity.KategoriID);
                command.Parameters.AddWithValue("@KategoriAd", entity.KategoriAd);
                command.Parameters.AddWithValue("@KategoriDes", entity.KategoriDes);
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

        public Kategori Mapping(SqlDataReader reader)
        {
            Kategori Kategori = new Kategori();
            Kategori.KategoriID = Convert.ToInt32(reader["KategoriID"]);
            Kategori.KategoriAd = reader["KategoriAd"].ToString();
            Kategori.KategoriDes = reader["KategoriDes"].ToString();
            return Kategori;
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
