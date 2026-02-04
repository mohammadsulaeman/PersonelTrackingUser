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
    public class TaskBLL
    {
        public static TaskDTO GetAll()
        {
            TaskDTO taskDto = new TaskDTO();
            taskDto.Employees = EmployeeDAO.GetEmployees();
            taskDto.Departments = DepartmentDAO.GetDepartments();
            taskDto.Positions = PositionDAO.GetPositions();
            taskDto.TaskStates = TaskDAO.GetTaskStats();
            taskDto.Tasks = TaskDAO.GetTasks();
            return taskDto;
        }

        public static void AddTask(TASK task)
        {
            TaskDAO.AddTask(task);
        }

        public static void UpdateTask(TASK update)
        {
            TaskDAO.UpdateTask(update);
        }

        public static void UpdateTask(int taskID, int approved)
        {
            TaskDAO.UpdateTask(taskID, approved);
        }

        public static void DeleteTask(int taskID)
        {
            TaskDAO.DeleteTaks(taskID);
        }

        public static void ApproveTask(int taskID, bool isAdmin)
        {
            TaskDAO.ApproveTask(taskID, isAdmin);
        }
    }
}
