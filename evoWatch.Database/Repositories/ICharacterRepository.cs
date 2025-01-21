using evoWatch.Database.Models;

namespace evoWatch.Database.Repositories
{
    internal interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetCharactersAsync();
        Task<Character> AddCharacterAsync(Character character);
        Task<Character> UpdateCharacterAsync(Character character);
        Task<Character?> GetCharacterByIdAsync(Guid id);
        Task<bool> DeleteCharacterAsync(Character character);
    }
}
