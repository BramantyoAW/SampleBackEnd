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
   public class BarangDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;
        }

        public IEnumerable<Barang> GetAll()
        { 
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
            string strSql = @"select * from Barang order by Nama";
                return conn.Query<Barang>(strSql);

            //using (SqlConnection conn = new SqlConnection(GetConnStr()))
            //{
            //    string strsql = @"select * from Barang order by Nama asc";
            //    return conn.Query<Barang>(strsql);

                //}
            }
        }

       public BookVM GetById(int KodeBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Barang 
                              where KodeBarang=@KodeBarang";
                var par = new
                {
                    KodeBarang = KodeBarang
                };
                return conn.Query<BookVM>(strSql, par).SingleOrDefault();
            }

        }

        public void Create(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Barang(KodeBarang,KategoriId,IdJenisMotor,Nama,Stok,HargaBeli,HargaJual, TanggalBeli) 
                                  values(@KodeBarang,@KategoriId,@IdJenisMotor,@Nama,@Stok,@HargaBeli,@HargaJual,@TanggalBeli)";
                var par = new
               {
                    KodeBarang = barang.KodeBarang,
                    KategoriId = barang.KategoriId,
                    IdJenisMotor = barang.IdJenisMotor,
                    Nama = barang.Nama,
                    Stok = barang.Stok,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    TanggalBeli = barang.TanggalBeli
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

        public void Update(Barang barang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {

                string strSql = @"update Barang set KodeBarang = @KodeBarang, KategoriId = @KategoriId ,IdJenisMotor = @idJenisMotor,
                                Nama = @Nama, Stok = @Stok, HargaBeli=@HargaBeli, HargaJual=@HargaJual,
                                TanggalBeli=@TanggalBeli 
                                where KodeBarang=@KodeBarang";
                var par = new
                {
                    KategoriId = barang.KategoriId,
                    IdjenisMotor = barang.IdJenisMotor,
                    Nama = barang.Nama,
                    Stok = barang.Stok,
                    HargaBeli = barang.HargaBeli,
                    HargaJual = barang.HargaJual,
                    TanggalBeli = barang.TanggalBeli,
                    KodeBarang = barang.KodeBarang
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

        public void Delete(string KodeBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Barang 
                                  where KodeBarang = @KodeBarang";
                var par = new { KodeBarang = KodeBarang };
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

        public IEnumerable<Barang> SearchByName(string namaBarang)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Barang where Nama like @Nama
                              order by Nama asc";
                var par = new { Nama = "%" + namaBarang + "%" };

                var result = conn.Query<Barang>(strSql, par);
                return result;
            }
        }

        public IEnumerable<BookVM> SearchByKategori(string namakat)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select KodeBarang,Nama, Stok, HargaBeli, HargaJual, TanggalBeli, NamaKategori from Barang, Kategori
                                    where Barang.KategoriId = Kategori.KategoriId and NamaKategori like @namaKategori";
                var par = new
                {
                    namaKategori = "%" + namakat + "%"
                };
                return conn.Query<BookVM>(strSql, par);
            }
        }
    }
}
