using MiniInternshipManagementSystem.Models;
using MiniInternshipManagementSystem.Services;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("== Internship Management System Demo ==");

        // Create organization
        var org = new Organization("techsoft", "tech@Soft.com");


        // Create mentor
        var mentor = new Mentor("Mr. smith", "smith@.com");

        // Organization creates an internship
        var internship = org.CreateInternship("AI Research Internship", 12, mentor);

        // Create students
        var student_1 = new Student("kamal", "alice@example.com");
        var student_2 = new Student("jamal", "bob@example.com");
        var student_3 = new Student("rahim", "carol@example.com");

        // Students apply (notifications to mentor)
        internship.AddApplicant(student_1);
        internship.AddApplicant(student_2);
        internship.AddApplicant(student_3);

        // Show internship details
        internship.ShowDetails();

        // Mentor assigns tasks to students
        var taskService = new TaskService();

        // Assign 3 tasks to kamal, simulate submission done automatically in AssignTaskToStudent
        var t1 = mentor.AssignTaskToStudent(student_1, "task one#");
        var t2 = mentor.AssignTaskToStudent(student_1, "task two#");
        var t3 = mentor.AssignTaskToStudent(student_1, "task three#");


        // Mentor reviews tasks: mark them completed one by one
        taskService.MentorReview(mentor, student_1, t1, true, "task one# is good\n");
        taskService.MentorReview(mentor, student_1, t2, true, "task two# is good\n");
        // after 2 completed tasks, no certificate yet
        taskService.MentorReview(mentor, student_1, t3, true, "task three# is good\n"); // After this, certificate should auto-generate


        // Show users info
        User[] users = new User[] { student_1, student_2, student_3, mentor };
        Console.WriteLine("\n-- ShowInfo for all users --");
        foreach (var u in users)
        {
            u.ShowInfo();
        }

        // Organization shows internships
        Console.WriteLine("\n-- Organization Internships --");
        org.ShowAllInternships();

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}




























///*
// * ---User Management---
// * Create an abstract class User
// * Properties: Id, Name, Email
// * Abstract method: ShowInfo()
// */

//using System.Drawing;
//using System.Numerics;

//public abstract class User
//{
//    public Guid ID { get;} = Guid.NewGuid();
//    public string Name { get; set; } = string.Empty;
//    public string Email { get; set; } = string.Empty;

//    public abstract void ShowInfo();
//}


///* 
// * ---Child Classes--
// * Student
// * Mentor
// * Organization
// */


//public class Student : User
//{
//    public override void ShowInfo()
//    {
//        Console.WriteLine("Show the Student's info");
//    }

//    void SubmitTask() {

//    }
//}
//public class Mentor : User
//{
//    public override void ShowInfo()
//    {
//        Console.WriteLine("Show the Mentor's info");
//    }

//    internal void ReviewTask(Student student, TaskItem task, bool markComplete, string feedback)
//    {
//        throw new NotImplementedException();
//    }
//}
//public class Organization : User
//{
//    public List<Internship> internships { get; set; } = new();
//    public override void ShowInfo()
//    {
//        Console.WriteLine("Show the Organization's info");
//    }
//}

///* 
// * ---new Class Internship--
// * Title, Duration, Mentor, List<Student> Applicants
// * AddApplicant(Student student)
// * ShowDetails()
// */

//public class Internship
//{
//    public string Title { get; set; } = String.Empty;
//    public uint Duration { get; set; } = 0;

//    // composiions
//    public Mentor Mentor { get; set; } = new();
//    public List<Student> Applicants { get; set; } = new();


//    void AddApplicant(Student student)
//    {
//        Applicants.Add(student);
//    }
//    void ShowDetails()
//    {
//        Console.WriteLine(
//            $" Title: {Title} " +
//            $"\n Duration: {Duration} " +
//            $"\n Mentor: {(Mentor.Name.Length > 0? Mentor.Name:"No mentor assinged")}" +
//            $"\n Applicants:");

//        if (Applicants.Count == 0)
//        {
//            Console.WriteLine(" No applicants yet.");
//        }
//        else
//        {
//            foreach (var s in Applicants)
//            {
//                Console.Write($" '{s.Name}' ");
//            }
//        }

//    }
//}


///*
// * ---new class Task---
// * Id, Description, IsCompleted, Feedback
// * Student submits the task, Mentor reviews it.
// */

//public class Task
//{
//    private Guid _Id = Guid.NewGuid();
//    private string _Description = string.Empty;
//    private bool _IsCompleted;
//    private string _Feedback = string.Empty;

//    public Guid Id {
//        get { return _Id; }
//    }
//    public string Description {
//        get { return _Description; }
//        set { _Description = value; }
//    }
//    public bool IsCompleted
//    {
//        get { return _IsCompleted; }
//        set { _IsCompleted = value; }
//    }
//    public string Feedback
//    {
//        get { return _Feedback; }
//        set { _Feedback = value; }
//    }

//    public void StudentSubmit( Student student)
//    {
//        IsCompleted = true;
//    }
//}