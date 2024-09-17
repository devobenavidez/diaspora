using Diaspora.Domain.Abstractions;
using PersonEntity = Diaspora.Domain.Entities.Person.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaspora.Infrastructure.Models;
using Diaspora.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Diaspora.Infrastructure.Repositories
{

    //TODO: CREAR COMMAND Y HANDLER PARA CREAR EL SERVICIO, CREAR PERSONA, CREAR DIRECCION, CREAR USUARIO
    public class PersonRepository : IPersonRepository
    {
        private readonly DBContext _context;

        public PersonRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<PersonEntity> AddAsync(PersonEntity personEntity)
        {
            var person = MapEntityToModel(personEntity);
            await _context.People.AddAsync(person);
            return personEntity;
        }

        public async Task UpdateAsync(PersonEntity personEntity)
        {
            var existingPerson = await _context.People.FindAsync(personEntity.Id.Value);

            if (existingPerson != null)
            {
                existingPerson.DocumentIdentifier = personEntity.DocumentIdentifier.Value;
                existingPerson.FirstName = personEntity.FirstName.Value;
                existingPerson.LastName = personEntity.LastName?.Value;
                existingPerson.Email = personEntity.Email.Value;
                existingPerson.BirthDate = personEntity.BirthDate?.Value;
                existingPerson.DocumentTypeId = personEntity.DocumentTypeId.Value;
                existingPerson.PersonTypeId = personEntity.PersonTypeId.Value;
                existingPerson.AddressId = personEntity.AddressId?.Value;
                existingPerson.UserId = personEntity.UserId?.Value;
                existingPerson.IsActive = personEntity.IsActive;
                existingPerson.UpdatedAt = personEntity.AuditInfo.UpdatedAt;
                existingPerson.UpdatedBy = personEntity.AuditInfo.UpdatedBy;

                _context.Entry(existingPerson).State = EntityState.Modified;
            }
        }

        public void SyncDomainEntityWithDatabase(PersonEntity personEntity)
        {
            var personModel = _context.People.Local.FirstOrDefault(p =>
                                                    p.DocumentIdentifier == personEntity.DocumentIdentifier.Value &&
                                                    p.DocumentTypeId == personEntity.DocumentTypeId.Value);
            if (personModel != null)
            {
                personEntity.Id = PersonEntity.SetPersonId(personModel.Id);
            }
        }

        private PersonEntity MapModelToEntity(Person person)
        {
            PersonEntity personEntity = PersonEntity.FromPrimitives(
                                person.Id,
                                person.DocumentIdentifier,
                                person.FirstName,
                                person.LastName,
                                person.Email,
                                person.BirthDate,
                                person.DocumentTypeId,
                                person.PersonTypeId,
                                person.AddressId,
                                person.UserId,
                                person.IsActive,
                                person.CreatedAt,
                                person.CreatedBy,
                                person.UpdatedAt,
                                person.UpdatedBy
                                );

            return personEntity;
        }

        private Person MapEntityToModel(PersonEntity personEntity)
        {
            return new Person
            {
                DocumentIdentifier = personEntity.DocumentIdentifier.Value,
                FirstName = personEntity.FirstName.Value,
                LastName = personEntity.LastName?.Value,
                Email = personEntity.Email.Value,
                BirthDate = personEntity.BirthDate?.Value,
                DocumentTypeId = personEntity.DocumentTypeId.Value,
                PersonTypeId = personEntity.PersonTypeId.Value,
                AddressId = personEntity.AddressId?.Value,
                UserId = personEntity.UserId?.Value,
                IsActive = personEntity.IsActive,
                CreatedAt = personEntity.AuditInfo.CreatedAt,
                CreatedBy = personEntity.AuditInfo.CreatedBy,
                UpdatedAt = personEntity.AuditInfo.UpdatedAt,
                UpdatedBy = personEntity.AuditInfo.UpdatedBy,
            };
        }
    }
}
