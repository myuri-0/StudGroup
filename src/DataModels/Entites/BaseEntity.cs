namespace DataModels.Entites;

    internal class BaseEntity
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = null!;
    }

