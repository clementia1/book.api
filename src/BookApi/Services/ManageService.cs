using System.Collections.Generic;
using System.Threading.Tasks;
using BookApi.DataProviders.Abstractions;
using BookApi.Entities;
using BookApi.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace BookApi.Services
{
    public class ManageService : IManageService
    {
        private readonly ILogger<ManageService> _logger;
        private readonly IBookProvider _bookProvider;

        public ManageService(
            ILogger<ManageService> logger,
            IBookProvider bookProvider)
        {
            _logger = logger;
            _bookProvider = bookProvider;
        }

        public async Task<string> CreateAsync(string title, string author, string description)
        {
            return await _bookProvider.CreateAsync(title, author, description);
        }

        public async Task<bool> UpdateAsync(string id, string? title, string? author, string? description)
        {
            return await _bookProvider.UpdateAsync(id, title, author, description);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _bookProvider.DeleteAsync(id);
        }

        public async Task<BookEntity?> GetByIdAsync(string id)
        {
            return await _bookProvider.GetByIdAsync(id);
        }

        public async Task<IReadOnlyCollection<BookEntity>> GetAll()
        {
            return await _bookProvider.GetAll();
        }
    }
}