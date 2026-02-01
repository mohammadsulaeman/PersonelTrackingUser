using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class EmployeeDTO
    {
        public List<DEPARTMENT> DEPARTMENTs { get; set; }

        public List<PositionDTO> positionDTOs { get; set; }

        public List<EmployeeDetailDTO> employeeDetailDTOs { get; set; }
    }
}
