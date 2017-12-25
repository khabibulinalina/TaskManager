using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Entities;
using TaskManager.DAL.Interfaces;

namespace TaskManager.DAL.Repositories
{
    class TaskRepository : IRepository<Task>
    {
        public void Create(Task item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Task item)
        {
            throw new NotImplementedException();
        }
    }
}
