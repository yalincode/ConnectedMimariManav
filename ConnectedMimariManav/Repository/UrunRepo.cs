using ConnectedMimariManav.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedMimariManav.Repository
{
    public class UrunRepo : BaseRepo, IRepository<Urun>
    {
       

        public List<Urun> GetAll()
        {
            throw new NotImplementedException();
        }

        public Urun Get(int id)
        {
            throw new NotImplementedException();
        }


        public int Update(Urun entity)
        {
            throw new NotImplementedException();
        }

        public int Create(Urun entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

      

        public Urun Mapping(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void ConOpen()
        {
            throw new NotImplementedException();
        }

        public void ConClose()
        {
            throw new NotImplementedException();
        }
    }
}
