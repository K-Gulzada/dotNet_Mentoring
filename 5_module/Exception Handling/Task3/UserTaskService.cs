using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
                throw new ArgumentOutOfRangeException("userId");

            var user = _userDao.GetUser(userId);
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var tasks = user.Tasks;
            foreach (var t in tasks)
            {
                if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                      throw new ArgumentException();
                   // throw new InvalidOperationException();
            }

            tasks.Add(task);

            return 0;
        }
    }
}