using CRUDApp.Data.Entities;

namespace CRUDApp.Data.Interfaces
{
    public interface IGameRepository
    {
        Task Create(Guid id, string name, string description, decimal price);
        Task<List<GameEntity>> GetAll();
        Task Update(Guid id, string name, string description, decimal price);
        Task Delete(Guid id);
    }
}
