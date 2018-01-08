using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TaskManager.DAL.Entities;
using TaskManager.DAL.Interfaces;

namespace TaskManager.DAL.Repositories
{
   public class EmployeeRepository: IRepository<Employee>
    {
        string connectionString = null;

        public EmployeeRepository(string conn)
        {
            connectionString = conn;
        }
        public IEnumerable<Employee> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))

            {
               return db.Query<Employee>("SELECT * FROM Employeers").ToList();
                
            }
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Employee item)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
