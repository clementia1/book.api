using System.Collections.Generic;
using System.Threading.Tasks;
using BookApi.Entities;

namespace BookApi.DataProviders.Abstractions
{
    public interface IBookProvider
    {
        Task<string> CreateAsync(string title, string author, string description);
        Task<bool> UpdateAsync(string id, string? title, string? author, string? description);
        Task<bool> DeleteAsync(string id);
        Task<BookEntity?> GetByIdAsync(string id);
        Task<IReadOnlyCollection<BookEntity>> GetAll();
    }
}