using System;
using System.Collections.Generic;

namespace HelpDeskTicketSystemProject.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Favorites = new HashSet<Favorite>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? ResolvedBy { get; set; }
        public string? SubjectLine { get; set; }
        public string? QuestionDetails { get; set; }
        public string? Status { get; set; }
        public DateTime? DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public string? Resolution { get; set; }
        public bool? Favorited { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
