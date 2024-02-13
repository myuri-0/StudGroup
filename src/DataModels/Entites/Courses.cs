namespace DataModels.Entites;
    internal class Course : BaseEntity
    {
        public IList<Student> Students { get; set; } = new List<Student>();
    }