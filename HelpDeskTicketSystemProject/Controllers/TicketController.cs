using HelpDeskTicketSystemProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskTicketSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        TicketDBContext context = new TicketDBContext();

        [HttpGet("ShowAllTickets")]
        public List<Ticket> ShowAllTickets()
        {
            return context.Tickets.ToList();
        }

        [HttpPost("AddAPost")]
        public Ticket AddPost(string UserName, string ResolvedBy, string SubjectLine, string QuestionDetails, string Status, DateTime DateOpened, DateTime DateClosed, string Resuloution, bool Favorited)
        {
            Ticket newTicket = new Ticket()
            {
                UserName = UserName,
                ResolvedBy = ResolvedBy,
                SubjectLine = SubjectLine,
                QuestionDetails = QuestionDetails,
                Status = Status,
                DateOpened = DateOpened,
                DateClosed = DateClosed,
                Resolution = Resuloution,
                Favorited = Favorited
            };
            context.Tickets.Add(newTicket);
            context.SaveChanges();
            return newTicket;
        }

    }
}
