using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCli.Application;
using TaskManagerCli.Domain;

namespace TaskManagerCli.Infrastructure
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TodoTask> _tasks = new();

        public void Add(TodoTask task)
        {
            _tasks.Add(task);
        }

        public TodoTask? GetById(Guid id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public IReadOnlyList<TodoTask> GetAll()
        {
            return _tasks.AsReadOnly();
        }

        public void Remove(Guid id)
        {
            var task=GetById(id);
            if(task !=null)
            {
                _tasks.Remove(GetById(id));
            }
            
        }



    }
}
