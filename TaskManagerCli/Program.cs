using TaskManagerCli.Application;
using TaskManagerCli.Domain;
using TaskManagerCli.Infrastructure;

var repository = new InMemoryTaskRepository();
var service=new TaskService(repository);

var t1 = service.CreateTask("Learn C# properly");
var t2 = service.CreateTask("Understand Solud");

Console.WriteLine("All tasks : ");

var allTasks = service.GetAllTasks();
foreach( var task in allTasks)
{
    Console.WriteLine(task);
}

service.MarkDone(t1.Id);

Console.WriteLine("\nAfter marking first task done : ");

foreach(var t in service.GetAllTasks())
{
    Console.WriteLine(t);
}