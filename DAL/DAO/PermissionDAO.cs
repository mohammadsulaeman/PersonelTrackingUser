using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PermissionDAO : EmployeeContext
    {
        public static void AddPermission(PERMISSION permission)
        {
            try
            {
                db.PERMISSIONs.InsertOnSubmit(permission);
                db.SubmitChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<PERMISSIONSTATE> GetStates()
        {
            return db.PERMISSIONSTATEs.ToList();
        }

        public static List<PermissionDetailDTO> GetPermission()
        {
            List<PermissionDetailDTO> permissions = new List<PermissionDetailDTO>();

            var list = (from p in db.PERMISSIONs
                        join s in db.PERMISSIONSTATEs on p.PermissionState equals s.ID
                        join e in db.EMPLOYEEs on p.EmployeeID equals e.ID
                        join d in db.DEPARTMENTs on e.DepartmentID equals d.ID
                        join ps in db.POSITIONs on e.PositionID equals ps.ID
                        select new
                        {
                            UserNo = e.UserNo,
                            name = e.Name,
                            Surname = e.Surname,
                            StateName = s.StateName,
                            stateID = p.PermissionState,
                            startDate = p.PermissionStartDate,
                            endDate = p.PermissionEndDate,
                            employeeID = p.EmployeeID,
                            PermissionID = p.ID,
                            explanation = p.PermissionExplanation,
                            DayAmount = p.PermissionDay,
                            departmentID = e.DepartmentID,
                            positionID = e.PositionID,
                            departmentName = d.DepartmentName,
                            positionName = ps.PositionName,
                        }).OrderBy(x => x.startDate).ToList();


            foreach(var item in list)
            {
                PermissionDetailDTO dto = new PermissionDetailDTO();
                dto.EmployeeID = item.employeeID;
                dto.UserNO = item.UserNo;
                dto.Name = item.name;
                dto.Surname = item.Surname;
                dto.DepartmentName = item.departmentName;
                dto.PositionName = item.positionName;
                dto.DepartmentID = item.departmentID;
                dto.PositionID = item.positionID;
                dto.StartDate = item.startDate;
                dto.EndDate = item.endDate;
                dto.PermissionDayAmount = item.DayAmount;
                dto.StateName = item.StateName;
                dto.State = item.stateID;
                dto.Explanation = item.explanation;
                dto.PermissionID = item.PermissionID;
                permissions.Add(dto);
            }
            return permissions;
        }

        public static void DeletePermission(int permissionID)
        {
            try
            {
                PERMISSION pr = db.PERMISSIONs.First(x => x.ID == permissionID);
                db.PERMISSIONs.DeleteOnSubmit(pr);
                db.SubmitChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePermission(int permissionID, int approved)
        {
            try
            {
                PERMISSION pr = db.PERMISSIONs.First(x => x.ID == permissionID);
                pr.PermissionState = approved;
                db.SubmitChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePermission(PERMISSION permission)
        {
           try
            {
                PERMISSION pr = db.PERMISSIONs.First(x => x.ID == permission.ID);
                pr.PermissionStartDate = permission.PermissionStartDate;
                pr.PermissionEndDate = permission.PermissionEndDate;
                pr.PermissionExplanation = permission.PermissionExplanation;
                pr.PermissionDay = permission.PermissionDay;
                db.SubmitChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
