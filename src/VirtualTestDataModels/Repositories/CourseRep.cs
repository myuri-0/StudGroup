using BaseDataModels.Entities;
using BaseDataModels.Repositories;
using System.Linq;

namespace VirtualTestDataModels.Repositories;

public class CourseRep : ICourseRep
{
    private DbContext _context = DbContext.GetDbContext;

    public IList<Course> Items { get; } = DbContext.Courses;
    public Course? GetItemById(Guid id) =>
        Items.FirstOrDefault(s => s.Id == id);

    public void Update(Course item)
    {
        if (item.Id == default)
        {
            item.Id = Guid.NewGuid();
            DbContext.Courses.Add(item);
            return;
        }

        var course = DbContext.Courses.FirstOrDefault(
            s => s.Id == item.Id);

        if (course is not null) course.Name = item.Name;

        else throw new ArgumentOutOfRangeException($"{item}", "ID is not default");
    }

    public void Delete(Course? item)
    {
        var course = DbContext.Courses.FirstOrDefault(item);
        if (course == null) return;
        foreach (var student in course.Students)
        {
            student.Courses.Remove(course);
        }
        DbContext.Courses.Remove(course);
    }

    public void Delete(Guid id)
    {
        var course = GetItemById(id);
        if (course is not null) Delete(course);
    }
}