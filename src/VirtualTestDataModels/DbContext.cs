using BaseDataModels;
using BaseDataModels.Entities;
using BaseDataModels.Repositories;
using VirtualTestDataModels.Repositories;

namespace VirtualTestDataModels;

public class DbContext
{
    public static IList<Course> Courses { get; } = new List<Course>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Статистика"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Философия"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Python"
        }
    };

    public static IList<Student> Students { get; } = new List<Student>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Петр Петров"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Саша Сидорова"
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Bob Joe"
        }
    };

    static DbContext()
    {
        Students[0].Courses.Add(Courses[1]);
        Students[0].Courses.Add(Courses[2]);
        Students[1].Courses.Add(Courses[2]);

        Courses[1].Students.Add(Students[0]);
        Courses[2].Students.Add(Students[0]);
        Courses[2].Students.Add(Students[1]);
    }

    private static DbContext? _dbContext;

    public static DbContext GetDbContext
    {
        get
        {
            _dbContext = _dbContext ?? new();
            return _dbContext;
        }
    }

    public static readonly DataManager Manager = new DataManager(new StudentRep(), new CourseRep());
}