using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MotionPictureApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureApp.dao
{
    public class MotionPictureDAO : IMotionPictureDAO
    {
        private readonly IConfiguration _configuration;
        public MotionPictureDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public JsonResult Get()
        {
            string query = @"SELECT * from dbo.motion_pictures";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MotionPictureAppConn");
            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand command = new SqlCommand(query, myConnection))
                {
                    myReader = command.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConnection.Close();
                }
                return new JsonResult(table);
            }
        }
        public string Post(MotionPicture mp)
        {
            string query = @"
                            INSERT INTO dbo.motion_pictures
                            VALUES (@name, @description, @releaseYear)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MotionPictureAppConn");
            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand command = new SqlCommand(query, myConnection))
                {
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = mp.name;
                    command.Parameters.Add("@description", SqlDbType.NVarChar).Value = mp.description;
                    command.Parameters.Add("@releaseYear", SqlDbType.Int).Value = mp.releaseYear;
                    myReader = command.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConnection.Close();
                }
                return $"Successfully added {mp.name}";
            }
        }

        public string Put(MotionPicture mp)
        {
            string query = @"
                            UPDATE dbo.motion_pictures
                            SET name = @name, description = @description, releaseYear = @releaseYear
                            WHERE id = @id
                              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MotionPictureAppConn");
            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand command = new SqlCommand(query, myConnection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = mp.id;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = mp.name;
                    command.Parameters.Add("@description", SqlDbType.NVarChar).Value = mp.description;
                    command.Parameters.Add("@releaseYear", SqlDbType.Int).Value = mp.releaseYear;
                    myReader = command.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConnection.Close();
                }
                return $"Successfully updated to {mp.name}";
            }
        }

        public string Delete(int id)
        {
            string query = @"
                            DELETE FROM dbo.motion_pictures
                            WHERE id = @id
                              ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MotionPictureAppConn");
            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand command = new SqlCommand(query, myConnection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    myReader = command.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConnection.Close();
                }
                return $"Successfully deleted motion picture with id {id}";
            }
        }
    }
}
