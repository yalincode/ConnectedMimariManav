using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedMimariManav.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Get(int id);

        int Create(T entity);
        int Update(T entity);
        void Delete(int id);

        T Mapping(SqlDataReader reader);

        void ConOpen();
        void ConClose();
    }
}
