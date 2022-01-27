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
    public class UrunRepo : BaseRepo, IRepository<Urun>
    {
       

        public List<Urun> GetAll()
        {
            List<Urun> Urunler = new List<Urun>();
            try
            {
                SqlCommand command = new SqlCommand("Sp_UrunGetir", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                ConOpen();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Urun urun = Mapping(reader);
                    Urunler.Add(urun);
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
            return Urunler;
        }

        public Urun Get(int id)
        {
            Urun urun = null;
            try
            {
                SqlCommand command = new SqlCommand("Sp_UrunGetir", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UrunID", id);
                ConOpen();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                     urun = Mapping(reader);
                    
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
            return urun;

        }


        public int Update(Urun entity)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Urun_InsertveUpdate", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UrunID", entity.UrunID);
                command.Parameters.AddWithValue("@UrunAd", entity.UrunAd);
                command.Parameters.AddWithValue("@KategoriID", entity.KategoriID);
                command.Parameters.AddWithValue("@MusteriID", entity.MusteriID);
                command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
                command.Parameters.AddWithValue("@Stok", entity.Stok);
                command.Parameters.AddWithValue("@Siparis", entity.Siparis);
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

        public int Create(Urun entity)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Urun_InsertveUpdate", con);
                command.CommandType=System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UrunID",entity.UrunID);
                command.Parameters.AddWithValue("@UrunAd",entity.UrunAd);
                command.Parameters.AddWithValue("@KategoriID",entity.KategoriID);
                command.Parameters.AddWithValue("@MusteriID",entity.MusteriID);
                command.Parameters.AddWithValue("@UnitPrice",entity.UnitPrice);
                command.Parameters.AddWithValue("@Stok",entity.Stok);
                command.Parameters.AddWithValue("@Siparis",entity.Siparis);
                ConOpen();
                id= Convert.ToInt32(command.ExecuteScalar());
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

            if (MessageBox.Show("Silmek İstediğine Emin misin?","Silme İşlemi",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                try
                {
                    SqlCommand command = new SqlCommand("Sp_Urun_Delete", con);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UrunID", id);
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

      

        public Urun Mapping(SqlDataReader reader)
        {
            Urun urun = new Urun();
            urun.UrunID = Convert.ToInt32(reader["UrunID"]);
            urun.UrunAd= reader["UrunAd"].ToString();
            urun.KategoriID= Convert.ToInt32(reader["KategoriID"]);
            urun.MusteriID= Convert.ToInt32(reader["MusteriID"]);
            urun.UnitPrice= Convert.ToDecimal(reader["UnitPrice"]);
            urun.Stok= Convert.ToInt16(reader["Stok"]);
            urun.Siparis= Convert.ToInt16(reader["Siparis"]);
            return urun;
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
