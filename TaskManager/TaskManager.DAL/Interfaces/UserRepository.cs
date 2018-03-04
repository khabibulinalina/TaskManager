using System.Text;
using Dapper;
using TaskManager.DAL.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TaskManager.DAL.Interfaces
{
    public class UserRepository: IRepository<User>
    {
        string connectionString = null;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(string conn)
        {
            connectionString = conn;
        }
        public IEnumerable<User> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))

            {
                return db.Query<User>("SELECT * FROM AspNetUsers").ToList();
            }
        }

        public void Create(User item)
        {
            throw new System.NotImplementedException();
        }

        public void CreateRegister(Register model)
        {


            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO AspNetUsers (Title, Descriprion, Priority, User) VALUES(@Title,@Descriprion,@Priority, @User)";
                db.Execute(sqlQuery, model);

            }
        }

        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE AspNetUsers SET Title = @Title, Description = @Description, EmployeeId = @EmployeeId, Priority = @Priority WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public User Get(string id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM AspNetUsers WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        
    }
}