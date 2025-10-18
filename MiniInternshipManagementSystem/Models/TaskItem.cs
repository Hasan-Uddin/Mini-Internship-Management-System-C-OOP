using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInternshipManagementSystem.Models
{
    public class TaskItem
    {
        private Guid _Id = Guid.NewGuid();
        private string _Description = string.Empty;
        private bool _IsCompleted;
        private string _Feedback = string.Empty;

        public Guid Id
        {
            get { return _Id; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public bool IsCompleted
        {
            get { return _IsCompleted; }
            set { _IsCompleted = value; }
        }
        public string Feedback
        {
            get { return _Feedback; }
            set { _Feedback = value; }
        }

        public TaskItem (string description)
        {
            this._Description= description;
        }

        public void StudentSubmit(Student student)
        {
            IsCompleted = true;
        }
    }
}
