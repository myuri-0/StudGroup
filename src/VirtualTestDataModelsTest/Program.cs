using VirtualTestDataModels;

var manager = DbContext.Manager;

foreach (var student in manager.StudentRep.Items)
{
    Console.WriteLine(student.Name);
}

Console.ReadKey();