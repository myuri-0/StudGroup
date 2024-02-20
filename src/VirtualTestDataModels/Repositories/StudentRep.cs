using BaseDataModels.Entities;
using BaseDataModels.Repositories;
using System.Linq;

namespace VirtualTestDataModels.Repositories;

public class StudentRep : IStudentRep
{
    private DbContext _context = DbContext.GetDbContext;

    public IList<Student> Items { get; } = DbContext.Students;
    public Student? GetItemById(Guid id) =>
        Items.FirstOrDefault(s => s.Id == id);

    public void Update(Student item)
    {
        if (item.Id == default)
        {
            item.Id = Guid.NewGuid();
            DbContext.Students.Add(item);
            return;
        }

        var student = DbContext.Students.FirstOrDefault(
            s => s.Id == item.Id);

        if (student is not null) student.Name = item.Name;

        else throw new ArgumentOutOfRangeException($"{item}", "ID is not default");
    }

    public void Delete(Student? item)
    {
        var student = DbContext.Students.FirstOrDefault(item);
        if (student == null) return;
        foreach (var course in student.Courses)
        {
            course.Students.Remove(student);
        }
        DbContext.Students.Remove(student);
    }

    public void Delete(Guid id)
    {
        var student = GetItemById(id);
        if (student is not null) Delete(student);
    }
}