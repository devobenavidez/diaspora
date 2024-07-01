using Diaspora.Domain.Entities.PersonType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Abstractions
{
    public interface IPersonType
    {
        Task CreatePersonType(PersonType personType);
        Task<List<PersonType>> GetPersonTypesList();
        Task UpdatePersonType(PersonType personType);
        Task<PersonType> GetPersonTypeById(int id);
        Task DeletePersonType(PersonType personType);
    }
}
