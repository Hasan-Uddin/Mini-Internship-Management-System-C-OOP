

namespace MiniInternshipManagementSystem.Models
{
    public class Organization : User
    {
        public List<Internship> InternshipList { get; set; } = new();
        public Organization()
        {
        }

        public Organization(string name, string email) : base(name, email)
        {
        }


        public override void ShowInfo()
        {
            Console.WriteLine($"Org: {Name}, (Email: {Email})\n");
        }

        public Internship CreateInternship(String title, uint duration, Mentor mentor)
        {
            Internship NewInternship = new Internship();
            NewInternship.Title = title;
            NewInternship.Duration = duration;
            NewInternship.Mentor = mentor;

            InternshipList.Add( NewInternship );
            Console.WriteLine($"Organization '{Name}' created internship '{title}' \n(Duration: {duration} weeks) with mentor: {mentor.Name}.");
            return NewInternship;
        }

        public void ShowAllInternships()
        {
            Console.WriteLine($"Organization: {Name} - Internships count: {InternshipList.Count}");
            foreach (var i in InternshipList)
                i.ShowDetails();
        }

    }
}
