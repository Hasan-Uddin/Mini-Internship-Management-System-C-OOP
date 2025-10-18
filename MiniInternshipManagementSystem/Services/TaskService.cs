using MiniInternshipManagementSystem.Models;


namespace MiniInternshipManagementSystem.Services
{
    public class TaskService
    {
        public void MentorReview(Mentor mentor, Student student, TaskItem task, bool markComplete, string feedback)
        {
            if (mentor == null) throw new ArgumentNullException(nameof(mentor));
            mentor.ReviewTask(student, task, markComplete, feedback);
        }
    }
}
