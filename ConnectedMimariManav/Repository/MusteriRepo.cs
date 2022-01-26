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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void ConClose()
        {
            throw new NotImplementedException();
        }
    }
}
