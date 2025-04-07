using MongoDB.Driver;
using testingMongoLocal.Models;
using testingMongoLocal.Services;

namespace testingMongoLocal.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(MongoDbService mongoDbService)
        {
            _collection = mongoDbService.Database.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();
        
        public async Task<User?> GetByIdAsync(string Id) =>
            await _collection.Find(u => u.Id == Id).FirstOrDefaultAsync();
        
        public async Task AddAsync(User user) =>
            await _collection.InsertOneAsync(user);
        
    }

}