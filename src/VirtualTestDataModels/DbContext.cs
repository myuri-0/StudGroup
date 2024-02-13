using BaseDataModels.Entites;
using BaseDataModels.Repositories;

namespace VirtualTestDataModels;

    public class DbContext
    {
        private readonly IList<Student>? _students = new List<student>();

}


    















    private readonly IList<Course>? _courses = new List<Course>()
    { }
    public IList<Student> Students
    {
        get => _students ?? GetStudent();
    }
    private IList<Student> GetStudent();
    {
        _students_
    }


