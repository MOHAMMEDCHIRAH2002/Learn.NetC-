using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManagerCli.Application;
using TaskManagerCli.Domain;

namespace TaskManagerCli.Infrastructure
{
    public class JsonFIleTaskRepository : ITaskRepository
    {
        private readonly string _path;
        private readonly List<TodoTask> _tasks;

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        public JsonFIleTaskRepository(string filepath)
        {
            _path = filepath;
            _tasks = LoadFromDisk(filepath);
        }

        public void Add(TodoTask task)
        {
            _tasks.Add(task);
            SaveToDisk();
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
            var task = GetById(id);
            if (task!=null)
            {
                _tasks.Remove(task);
                SaveToDisk();
            }
        }
        private  void SaveToDisk()
        {
            var dtos = _tasks.Select(t => new TodoTaskDto
            {
                Id = t.Id,
                Title = t.Title,
                IsDone = t.IsDone,
                CreatedAt = t.CreatedAt,
            }).ToList();

            var json = JsonSerializer.Serialize(dtos, JsonOptions);
        }

        private static List<TodoTask> LoadFromDisk(string filepath)
        {
            if (!File.Exists(filepath))
                return new List<TodoTask>();

            var json = File.ReadAllText(filepath);
            if(string.IsNullOrWhiteSpace(json))
                return new List<TodoTask>();
            var dtos = JsonSerializer.Deserialize<List<TodoTaskDto>>(json) ?? new List<TodoTaskDto>();

            return dtos.Select(d => new TodoTask(d.Id, d.Title, d.IsDone, d.CreatedAt)).ToList();
        }
    }
}
