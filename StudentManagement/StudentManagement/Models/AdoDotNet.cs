using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class StudentDetails
    {
        public string Id { get; set; }
        public string StudentName { get; set; }

    }
    public class ADOdotnet
    {
        private readonly string _connectionString;
        public ADOdotnet(string connectionString)
        {
            _connectionString = connectionString;

        }
        public List<StudentDetails> studentList()
        {
            var list = new List<StudentDetails>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(" select*  UserName from AspNetUsers, AspNetUserRoles, AspNetRoles, where AspNetUsers.Id = AspNetUserRoles.UserId and AspNetUserRoles.RoleId = AspNetRoles.Id", conn);
                var record = sqlCommand.ExecuteReader();

                while (record.Read())
                {
                    var model = new StudentDetails();
                    model.Id = (string)record["Id"];
                    model.StudentName = (string)record["UserName"];                    
                    list.Add(model);
                }
                return (list);
            }
        }
    }
}