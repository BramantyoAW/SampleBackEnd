﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BO;
using DAL;

namespace SampleBackEnd.Controllers
{
    public class JenisMotorController : ApiController
    {
        // GET: api/JenisMotor
        public IEnumerable<JenisMotor> Get()
        {
            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            return jenisMotorDAL.GetAll();
        }

        // GET: api/JenisMotor/5
        public JenisMotor Get(int id)
        {
            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            return jenisMotorDAL.GetById(id);
        }

        // POST: api/JenisMotor
        public IHttpActionResult Post(JenisMotor jenisMotor)
        {
            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            try
            {
                jenisMotorDAL.Create(jenisMotor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/JenisMotor/5
        public IHttpActionResult Put(JenisMotor jenisMotor)
        {

            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            try
            {
                jenisMotorDAL.Update(jenisMotor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/JenisMotor/5
        public IHttpActionResult Delete(int id)
        {
            {
                JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
                try
                {
                    jenisMotorDAL.Delete(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        public IEnumerable<JenisMotor> Get(string namaJenisMotor)
        {
            JenisMotorDAL jenisMotorDAL = new JenisMotorDAL();
            return jenisMotorDAL.SearchByName(namaJenisMotor);
        }
    }
}
