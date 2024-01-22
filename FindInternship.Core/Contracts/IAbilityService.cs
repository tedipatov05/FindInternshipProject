using FindInternship.Core.Models.Ability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IAbilityService
    {
        Task<List<AbilityViewModel>> AllAbilitiesAsync();

        Task AddAbilitiesToStudentAsync(List<string> abilities, string userId);

        Task AddTechnologiesToCompanyAsync(List<string> technologies, string userId);

        Task<List<string>> AllAbilityNamesAsync();

        Task<List<string>> GetCompanyAbilityNamesAsync(string companyId);

        Task AddNewAbilityAsync(string ability);

        
    }
}
