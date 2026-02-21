using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCli.Domain
{
   public sealed class TodoTask
    {
        public Guid Id { get; }
        public string Title { get; private set; }
        public bool IsDone { get;private set; }
        public DateTime CreatedAt { get; }

        public TodoTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            Id = Guid.NewGuid();
            Title = NormalizeAndvalidateTitle(title);
            CreatedAt = DateTime.UtcNow;
            IsDone = false;
        }

        public void MarkDone()
        {
            IsDone = true;
        }

        public void Rename(string newTitle)
        {
            Title=NormalizeAndvalidateTitle(newTitle);
        }

        public override string ToString()
        {
            var status = IsDone ? "x" : " ";
            return $"[{status}] {Title} (Id: {Id}, CreatedAt: {CreatedAt:O})";
        }

        private static string NormalizeAndvalidateTitle(string title)
        {
            if(title is null) 
                throw new ArgumentNullException(nameof(title));
            var normalized = title.Trim();

            if (normalized.Length==0)
                throw new ArgumentException("Title cannot be empty .", nameof(title));

            if (normalized.Length < 3)
                throw new ArgumentException("Title must be at least 3 characters .",nameof(title));

            return normalized;
        }
    }
}
