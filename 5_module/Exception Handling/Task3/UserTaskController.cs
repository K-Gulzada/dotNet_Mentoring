using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            string message = String.Empty;
            try
            {
                message = GetMessageForModel(userId, description);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
         
            if (message != null)
            {
                model.AddAttribute("action_result", message);
                return false;
            }

            return true;
        }

        private string GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);
            int result = _taskService.AddTaskForUser(userId, task);
            if (result == -1)
                throw new ArgumentOutOfRangeException("", "Invalid userId");

            if (result == -2)
                throw new ArgumentNullException("", "User not found");

            if (result == -3)
                throw new ArgumentException("The task already exists", "");

            return null;
        }
    }
}