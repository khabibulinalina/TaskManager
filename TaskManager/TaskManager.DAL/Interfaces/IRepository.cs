using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using TaskManager.DAL.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TaskManager.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
    public class TaskRepository : IRepository<Task>
    {

        string connectionString = null;
        public TaskRepository(string conn)
        {
            connectionString = conn;
        }
        public IEnumerable<Task> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            
            {
                var sql = "SELECT * FROM Tasks t join Employeers e on t.EmployeeId = e.Id";

                var data = db.Query<Task, Employee, Task>(sql, (task, employee) => { task.Employee = employee; return task; });

                return data;
                //return db.Query("SELECT * FROM Tasks t join Employeers e on t.EmployeeId = e.Id", (t,e) => { var nt = (Task)t; t.Employee = e; return e; }).ToList();

            }
        }

        public Task Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Task>("SELECT * FROM Tasks WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Task task)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Tasks (Title, Descriprion, Priority, Employee) VALUES(@Title,@Descriprion,@Priority, @Employee)";
                db.Execute(sqlQuery, task);

            }
        }

        public void Update(Task task)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Tasks SET Title = @Title, Description = @Description, EmployeeId = @EmployeeId, Priority = @Priority WHERE Id = @Id";
                db.Execute(sqlQuery, task);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Tasks WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
