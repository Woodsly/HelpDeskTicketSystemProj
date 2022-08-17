using System;
using System.Collections.Generic;

namespace HelpDeskTicketSystemProject.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public int? TicketId { get; set; }
        public string? UserName { get; set; }

        public virtual Ticket? Ticket { get; set; }
    }
}
