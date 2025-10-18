using MiniInternshipManagementSystem.Interfaces;

namespace MiniInternshipManagementSystem.Models
{
    public class Student : User, ICertifiable
    {
        public List<TaskItem> Tasks { get; } = new();
        public bool HasCertificate { get; private set; } = false;
        public Student() : base() { }

        public Student(string name, string email) : base(name, email) { }


        public override void ShowInfo()
        {
            Console.WriteLine(
                $"Student: {Name}, (Email: {Email})\n" +
                $"Tasks: {Tasks.Count},\n" +
                $"Completed: {Tasks.Count(t => t.IsCompleted)}");
        }

        

        public void SubmitTask(TaskItem task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            Tasks.Add(task);
            Notify(
                $"<<<<Successful>>>>,\n" +
                $"You submitted task '{task.Description}'\n" +
                $" (TaskId: {task.Id}).\n");
        }

        public void TaskReviewed(TaskItem task, bool completed, string feedback)
        {
            // update task via encapsulated properties
            task.IsCompleted = completed;
            task.Feedback = feedback;
            Notify($"Your task '{task.Description}' was reviewed. \nCompleted: {task.IsCompleted}. \nFeedback: {task.Feedback}\n");

            // If completed, check certificate eligibility
            var completedCount = Tasks.Count(t => t.IsCompleted);
            if (!HasCertificate && completedCount >= Tasks.Count)
            {
                GenerateCertificate();
            }
        }

        public void GenerateCertificate()
        {
            HasCertificate = true;
            Console.WriteLine($"\n*** CONGRATULATIONS {Name}! You have completed {Tasks.Count(t => t.IsCompleted)} tasks. Generating certificate... ***");
            
            Console.WriteLine($"--- CERTIFICATE OF COMPLETION ---\nStudent: {Name}\nDate: {DateTime.UtcNow:yyyy-MM-dd}\nCongratulations on completing the internship tasks!\n-------------------------------");
        }
    }
}
