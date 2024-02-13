namespace DataModels.Entites;
    internal class Student : BaseEntity
    {
        public IList<Course> Courses { get; set; } = new List<Course>();
    }