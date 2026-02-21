using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCli.Domain;

namespace TaskManagerCli.Application
{
    public interface ITaskRepository
    {
        void Add(TodoTask task);
        TodoTask? GetById(Guid id);
        IReadOnlyList<TodoTask> GetAll();
        void Remove(Guid id);
    }
}
