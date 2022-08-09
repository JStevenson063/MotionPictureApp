using Microsoft.AspNetCore.Mvc;
using MotionPictureApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureApp.dao
{
    public interface IMotionPictureDAO
    {
       public JsonResult Get();
        public String Post(MotionPicture mp);
        public String Put(MotionPicture mp);
        public String Delete(int id);
    }
}
