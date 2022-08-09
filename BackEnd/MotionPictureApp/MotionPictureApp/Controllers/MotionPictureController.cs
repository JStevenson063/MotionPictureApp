using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MotionPictureApp.Models;
using MotionPictureApp.dao;

namespace MotionPictureApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MotionPictureController : ControllerBase
    {

        private IMotionPictureDAO _dao;

        public MotionPictureController(IMotionPictureDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public JsonResult GetMotionPictureData()
        {
            return _dao.Get();


        }

        [HttpPost]
        public string CreateNewMotionPicture(MotionPicture mp)
        {
            return _dao.Post(mp);
        }

        [HttpPut]
        public string UpdateExistingMotionPicture(MotionPicture mp)
        {
            return _dao.Put(mp);
        }

        [HttpDelete("{id}")]
        public string DeleteExistingMotionPicture(int id)
        {
            return _dao.Delete(id);
        }



    }
}
