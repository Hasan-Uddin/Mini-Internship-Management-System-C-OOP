

namespace MiniInternshipManagementSystem.Models
{
    public class Mentor : User
    {
        public Mentor(string name, string email) : base(name, email) { }

        public Mentor()
        {
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Mentor: {Name}, (Email: {Email})\n");
        }

        public TaskItem AssignTaskToStudent(Student student, string description)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            TaskItem task = new(description);
            // student submits  quickly too!
            student.SubmitTask(task);
            student.Notify($"A new task has been assigned by mentor {Name}: '{description}'");
            return task;
        }

        public void ReviewTask(Student student, TaskItem task, bool markComplete, string feedback)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (task == null) throw new ArgumentNullException(nameof(task));

            Notify($"Reviewing task '{task.Description}' for student {student.Name}.");
            student.TaskReviewed(task, markComplete, feedback);
        }
    }
}
