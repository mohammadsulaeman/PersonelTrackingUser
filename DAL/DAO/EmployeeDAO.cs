using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class EmployeeDAO : EmployeeContext
    {
        public static void AddEmployee(EMPLOYEE employee)
        {
            try {
                db.EMPLOYEEs.InsertOnSubmit(employee);
                db.SubmitChanges();
           }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<EMPLOYEE> GetUsers(int v)
        {
            return db.EMPLOYEEs.Where(x => x.UserNo == v).ToList();
        }

        public static List<EmployeeDetailDTO> GetEmployees()
        {
            List<EmployeeDetailDTO> employeeList = new List<EmployeeDetailDTO>();

            var list = (from e in db.EMPLOYEEs
                        join d in db.DEPARTMENTs on e.DepartmentID equals d.ID
                        join p in db.POSITIONs on e.PositionID equals p.ID
                        select new
                        {
                            EmployeeID = e.ID,
                            UserNO = e.UserNo,
                            Name = e.Name,
                            Surname = e.Surname,
                            DepartmentName = d.DepartmentName,
                            PositionName = p.PositionName,
                            DepartmentID = e.DepartmentID,
                            PositionID = e.PositionID,
                            Salary = e.Salary,
                            isAdmin = e.IsAdmin,
                            Password = e.Password,
                            ImagePath = e.ImagePath ,
                            Address = e.Address,
                            BhirtDay = e.BirthDay
                        }).OrderBy(x => x.UserNO).ToList(); 
            foreach (var item in list)
            {
                EmployeeDetailDTO dto = new EmployeeDetailDTO();
                dto.EmployeeID = item.EmployeeID;
                dto.UserNO = item.UserNO;
                dto.Name = item.Name;
                dto.Surname = item.Surname;
                dto.DepartmentName = item.DepartmentName;
                dto.PositionName = item.PositionName;
                dto.DepartmentID = item.DepartmentID;
                dto.PositionID = item.PositionID;
                dto.Salary = item.Salary;
                dto.isAdmin = item.isAdmin;
                dto.Password = item.Password;
                dto.ImagePath = item.ImagePath;
                dto.Address = item.Address;
                dto.BhirtDay = item.BhirtDay;
                employeeList.Add(dto);
            }
            return employeeList;
        }

        public static List<EMPLOYEE> GetEmployees(int v, string text)
        {
            try
            {
                List<EMPLOYEE> list = db.EMPLOYEEs.Where(x => x.UserNo == v && x.Password == text).ToList();
                return list;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
