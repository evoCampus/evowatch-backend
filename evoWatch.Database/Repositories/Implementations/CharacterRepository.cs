using evoWatch.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoWatch.Database.Repositories.Implementations
{
    internal class CharacterRepository : ICharacterRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CharacterRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Character> AddCharacterAsync(Character character)
        {
            var result = await _databaseContext.Characters.AddAsync(character);
            await _databaseContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            return await Task.FromResult(_databaseContext.Characters.AsEnumerable());
        }

        public async Task<bool> DeleteCharacterAsync(Character character)
        {
            try
            {
                var result = _databaseContext.Characters.Remove(character);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException)
            {

                return false;
            }
        }

        public async Task<Character?> GetCharacterByIdAsync(Guid id)
        {
            return await _databaseContext.Characters.FindAsync(id);
        }

        public async Task<Character> UpdateCharacterAsync(Character character)
        {
            var result = _databaseContext.Characters.Update(character);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;

        }
    }
}
