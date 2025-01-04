using CRUDApp.Data.Entities;
using CRUDApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUDApp.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Guid id, string name, string description, decimal price)
        {
            var game = new GameEntity() 
            { 
                Id = id, 
                Name = name, 
                Description = description, 
                Price = price 
            };

            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _context.Games
                .Where(game => game.Id == id)
                .ExecuteDeleteAsync();
        }

        public Task<List<GameEntity>> GetAll()
        {
            return _context.Games.ToListAsync();
        }

        public async Task Update(Guid id, string name, string description, decimal price)
        {
            await _context.Games.Where(game => game.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price));
        }
    }
}
