using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DAL;

namespace BLL
{
    public class SalaryBLL
    {
        public static SalaryDTO GetAll()
        {
            SalaryDTO dto = new SalaryDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Employees = EmployeeDAO.GetEmployees();
            dto.Positions = PositionDAO.GetPositions();
            dto.Months = SalaryDAO.GetMonths();
            dto.Salaries = SalaryDAO.GetSalaries();
            return dto;
        }

        public static void AddSalary(SALARY salary, bool control)
        {
            SalaryDAO.AddSalary(salary);
            if (control)
                EmployeeBLL.UpdateEmployee(salary.EmployeeID, salary.Amount);
        }

        public static void UpdateSalary(SALARY update, bool control)
        {
            SalaryDAO.UpdateSalary(update);
            if (control)
                EmployeeBLL.UpdateEmployee(update.EmployeeID, update.Amount);
        }

        public static void DeleteSalary(int salaryID)
        {
            SalaryDAO.DeleteSalary(salaryID);
        }
    }
}
