using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
   public class JenisMotorDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;
        }

        public IEnumerable<JenisMotor> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strsql = @"select * from JenisMotor order by NamaJenisMotor asc";
                return conn.Query<JenisMotor>(strsql);
            }
        }

        public JenisMotor GetById(int IdJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from JenisMotor 
                              where IdJenisMotor=@IdJenisMotor";
                var par = new
                {
                    IdJenisMotor = IdJenisMotor
                };
                return conn.Query<JenisMotor>(strSql, par).SingleOrDefault();
            }

        }

        public void Create(JenisMotor jenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into JenisMotor(NamaJenisMotor,NamaMerk) 
                                  values(@NamaJenisMotor,@NamaMerk)";
                var par = new { NamaJenisMotor = jenisMotor.NamaJenisMotor , NamaMerk = jenisMotor.NamaMerk};
                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }

        public void Update(JenisMotor jenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {

                string strSql = @"update JenisMotor set NamaJenisMotor=@NamaJenisMotor, NamaMerk=@NamaMerk 
                                  where IdJenisMotor=@IdJenisMotor";
                var par = new
                {
                    NamaJenisMotor = jenisMotor.NamaJenisMotor,
                    IdJenisMotor = jenisMotor.IdJenisMotor,
                    NamaMerk = jenisMotor.NamaMerk
                };

                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }

        public void Delete(int IdJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from JenisMotor 
                                  where IdJenisMotor=@IdJenisMotor";
                var par = new { IdJenisMotor = IdJenisMotor };
                try
                {
                    conn.Execute(strSql, par);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number + " - " + sqlEx.Message);
                }
            }
        }

        public IEnumerable<JenisMotor> SearchByName(string namaJenisMotor)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from JenisMotor where NamaJenisMotor like @NamaJenisMotor
                              order by NamaJenisMotor asc";
                var par = new { namaJenisMotor = "%" + namaJenisMotor + "%" };

                var result = conn.Query<JenisMotor>(strSql, par);
                return result;
            }
        }

    }
}
