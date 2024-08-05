using Diaspora.Domain.Abstractions;
using PersonTypeEntity = Diaspora.Domain.Entities.PersonType.PersonType;
using Diaspora.Infrastructure.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaspora.Infrastructure.Models;
using Diaspora.Infrastructure.Exceptions;

namespace Diaspora.Infrastructure.Repositories
{
    public class PersonTypeRepository : IPersonTypeRepository
    {
        private readonly DBContext _context;

        public PersonTypeRepository(DBContext context)
        {
            _context = context;
        }

        public async Task CreatePersonType(PersonTypeEntity personTypeEntity)
        {
            Persontype persontype = new Persontype
            {
                Description = personTypeEntity.Description.Value,
                IsActive = personTypeEntity.IsActive,
                CreatedAt = personTypeEntity.AuditInfo.CreatedAt,
                CreatedBy = personTypeEntity.AuditInfo.CreatedBy,
                UpdatedAt = personTypeEntity.AuditInfo.UpdatedAt,
                UpdatedBy = personTypeEntity.AuditInfo.UpdatedBy,
            };

            await _context.Persontypes.AddAsync(persontype);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonType(PersonTypeEntity personTypeEntity)
        {
            Persontype persontype = await _context.Persontypes.FindAsync(personTypeEntity.Id.Value);

            if (persontype == null)
            {
                throw new EntityNotFoundException(nameof(Persontype), personTypeEntity.Id.Value);
            }

            persontype.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async Task<PersonTypeEntity?> GetPersonTypeById(int id)
        {
            Persontype? persontype = await _context.Persontypes.FindAsync(id);

            if (persontype == null)
            {
                return null;
            }

            return ConvertPersonTypeToEntity(persontype);
        }

        public Task<List<PersonTypeEntity>> GetPersonTypesList()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonType(PersonTypeEntity personType)
        {
            throw new NotImplementedException();
        }

        private PersonTypeEntity ConvertPersonTypeToEntity(Persontype persontype)
        {
            return PersonTypeEntity.FromPrimitives(
                    persontype.Id,
                    persontype.Description ?? string.Empty,
                    persontype.IsActive ?? false,
                    persontype.CreatedAt,
                    persontype.CreatedBy,
                    persontype.UpdatedAt,
                    persontype.UpdatedBy,
                    persontype.DeletedAt
                );
        }
    }
}
