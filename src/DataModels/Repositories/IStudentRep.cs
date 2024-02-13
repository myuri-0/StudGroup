using BaseDataModels.Entites;

namespace VirtalTestDataModels.Repositories;

public class StudentRep : IStudentRep
{
    private DbContext _context = DbContext.GetDbContext();


    public IList<Student> Items { get; } = DbContext.Students;
    public Student? GetItemById(Guid id) =>
        Items.FirstOrDefault(s: Student => s.Id == id);

    public void Update(Student item)
    {
        if (item.Id == default)
        {
            item.Id = Guid.NewGuid();
            DbContext.Student.Add(item);
            return;
        }
        var student = DbContext.Students.FirstOrDefault(s: Student => s.Id == item.Id);
        else if (DbContext.Students.FirstOrDefault(s:Student=>s.Id==item.Id) is not null students)
    }
public interface IStudentRep : IBaseRepository<Student>;
