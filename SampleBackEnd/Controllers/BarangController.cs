using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BO;
using DAL;

namespace SampleBackEnd.Controllers
{
    public class BarangController : ApiController
    {
        // GET: api/Barang
        public IEnumerable<Barang> Get()
        {
            BarangDAL BarangDAL = new BarangDAL();
            return BarangDAL.GetAll();
        }

        // GET: api/Barang/5
              public BookVM Get(int id)
        {
            BarangDAL jenisMotorDAL = new BarangDAL();
            return jenisMotorDAL.GetById(id);
        }

        // POST: api/Barang
        public IHttpActionResult Post(Barang barang)
        {
            BarangDAL BarangDAL = new BarangDAL();
            try
            {
                BarangDAL.Create(barang);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Barang/5
        public IHttpActionResult Put(Barang barang)
        {
            BarangDAL BarangDAL = new BarangDAL();
            try
            {
                BarangDAL.Update(barang);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Barang/5
        public IHttpActionResult Delete(string id)
        {
            BarangDAL barangDAL = new BarangDAL();
            try
            {
                barangDAL.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IEnumerable<Barang> Get(string namabarang)
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.SearchByName(namabarang);
        }

        public IEnumerable<BookVM> Get2(string namakategori)
        {
            BarangDAL barangDAL = new BarangDAL();
            return barangDAL.SearchByKategori(namakategori);
        }

    }
}
