using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    /*public record CompanyForCreationDto(string Name, string Address, string Country,
        IEnumerable<EmployeeForCreationDto> Employees);*/

    public record CompanyForCreationDto : CompanyForManipulationDto
    {
        public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
    }
}
