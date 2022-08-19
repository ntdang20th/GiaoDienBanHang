using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GiaoDienBanHang_01.Repositories
{
   public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            //_connectionString = "Server = (local); Database = THIETKE_GD_QLBANHANG; Integrated Security=True";
            _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=THIETKE_GD_QLBANHANG;Integrated Security=True";
        }
        
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
