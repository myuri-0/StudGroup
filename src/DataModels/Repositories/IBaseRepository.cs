namespace DataModels.Repositories;

public interface IBaseRepository<T> where T : class
{
    #region Read
    /// <summary>
    /// Перечисляем все сущности
    /// </summary>
    IList<T> Items { get; }

    /// <summary>
    /// ищет сущность по индексу
    /// </summary>
    /// <param name="id">индекс</param>
    /// <returns>сущность</returns>
    T? GetItemById(Guid id);
    #endregion

    #region Create Update
    /// <summary>
    /// обновляет или создает новую сущность
    /// </summary>
    /// <param name="item">сущность</param>
    void Update(T item);
    #endregion

    #region Delete
    /// <summary>
    /// Удаляет сущность
    /// </summary>
    /// <param name="id">ID, удаляемой сущности</param>
    void Delete(Guid id);
    #endregion
}
