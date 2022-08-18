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
        public Ticket AddPost(string UserName, string SubjectLine, string QuestionDetails, string Status)
        {
            Ticket newTicket = new Ticket()
            {
                UserName = UserName,
                SubjectLine = SubjectLine,
                QuestionDetails = QuestionDetails,
                Status = Status,
                DateOpened = DateTime.Now
            };
            context.Tickets.Add(newTicket);
            context.SaveChanges();
            return newTicket;
        }

        [HttpGet("GetTicketById/{id}")]
        public Ticket getTicketById(int id)
        {
            return context.Tickets.FirstOrDefault(t => t.Id == id);
        }

    }
}
