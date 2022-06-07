using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    internal class IssueDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }

        public Priority Priority { get; set; }

        public IssueType Type { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Completed { get; set; }
    }
    public enum Priority
    {
        Low, Medium, High
    }
    public enum IssueType
    {
        Feature, Bug, Documentation
    }
}
