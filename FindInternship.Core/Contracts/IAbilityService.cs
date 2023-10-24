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
    }
}
