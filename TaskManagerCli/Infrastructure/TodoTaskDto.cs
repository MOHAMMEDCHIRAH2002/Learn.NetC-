using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCli.Infrastructure
{
    internal sealed class TodoTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
