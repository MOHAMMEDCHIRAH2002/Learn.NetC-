using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCli.Domain;

namespace TaskManagerCli.Application
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public TodoTask CreateTask (String title)
        {
            var task = new TodoTask(title);
             _repository.Add(task);
            return task;
        }

        public IReadOnlyList<TodoTask> GetAllTasks()
        {
            return _repository.GetAll();
        }

        public void MarkDone(Guid id) 
        {

            var task = _repository.GetById(id)
                ?? throw new InvalidOperationException("Task not found");
            task.MarkDone();
        }

        public void Delete(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
