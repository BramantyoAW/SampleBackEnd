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
    public class KategoriDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;
        }

        public IEnumerable<Kategori> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strsql = @"select * from Kategori order by NamaKategori asc";
                return conn.Query<Kategori>(strsql);
            }
        }

        public Kategori GetById(int KategoriId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Kategori 
                              where KategoriId=@KategoriId";
                var par = new
                {
                    KategoriId = KategoriId
                };
                return conn.Query<Kategori>(strSql, par).SingleOrDefault();
            }

        }

        public void Create(Kategori kategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Kategori(NamaKategori) 
                                  values(@NamaKategori)";
                var par = new { NamaKategori = kategori.NamaKategori };
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

        public void Update(Kategori kategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {

                string strSql = @"update Kategori set NamaKategori=@NamaKategori 
                                  where KategoriId=@KategoriId";
                var par = new
                {
                    NamaKategori = kategori.NamaKategori,
                    KategoriId = kategori.KategoriId
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

        public void Delete(int KategoriId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Kategori 
                                  where KategoriId=@KategoriId";
                var par = new { KategoriId = KategoriId };
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

        public IEnumerable<Kategori> SearchByName(string namaKategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Kategori where NamaKategori like @NamaKategori
                              order by NamaKategori asc";
                var par = new { namaKategori = "%" + namaKategori + "%" };

                var result = conn.Query<Kategori>(strSql, par);
                return result;
            }
        }


    }
}
