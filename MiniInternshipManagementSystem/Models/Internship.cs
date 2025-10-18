

namespace MiniInternshipManagementSystem.Models
{
    public class Internship
    {
        public string Title { get; set; } = String.Empty;
        public uint Duration { get; set; } = 0;

        // composiions
        public Mentor Mentor { get; set; } = new();
        public List<Student> Applicants { get; set; } = new();

        public void AssignMentor(Mentor mentor)
        {
            if(mentor != null)
            {
                Mentor = mentor;
            }
        }

        public void AddApplicant(Student student)
        {
            if(student != null)
            {
                Applicants.Add(student);
                Mentor?.Notify($"Student {student.Name} applied for '{Title}'.");
            }
        }
        public void ShowDetails()
        {
            Console.WriteLine(
                $" Title: {Title} " +
                $"\n Duration: {Duration} " +
                $"\n Mentor: {(Mentor.Name.Length > 0 ? Mentor.Name : "No mentor assinged")}" +
                $"\n Applicants:");

            if (Applicants.Count == 0)
            {
                Console.WriteLine(" No applicants yet.");
            }
            else
            {
                foreach (var s in Applicants)
                {
                    Console.Write($" >> {s.Name}");
                }
            }
            Console.WriteLine("\n-----------------------");
        }
    }
}
