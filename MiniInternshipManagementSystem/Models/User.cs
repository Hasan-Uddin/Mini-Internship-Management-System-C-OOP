using MiniInternshipManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInternshipManagementSystem.Models
{
    public abstract class User : INotifiable
    {
        public Guid ID { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public abstract void ShowInfo();
        
        
        protected User(string name, string email) {
            if(name.Length > 0 && email.Length>0)
            {
                Name = name; Email = email;
            }
        }
        protected User()
        {
        }

        public void Notify(string message)
        {
            Console.WriteLine($"[Notification to {Name} ({GetType().Name})] {message}");
        }
    }
}
