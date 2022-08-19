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
                DateOpened = DateTime.Now,
                Favorited = false
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

        [HttpPatch("ResolveTicket")]
        public Ticket ResolveTicket(int id, string ResolvedBy, string Resolution)
        {
            Ticket ticket = context.Tickets.FirstOrDefault(t => t.Id == id);
            ticket.ResolvedBy = ResolvedBy;
            ticket.Resolution = Resolution;
            ticket.DateClosed = DateTime.Now;
            ticket.Status = "Closed";
            context.Tickets.Update(ticket);
            context.SaveChanges();
            return ticket;
        }

        //[HttpPatch("AddFavorite")]
        //public Ticket AddFavorite(int id)
        //{
        //    Ticket ticket = context.Tickets.FirstOrDefault(t => t.Id == id);            
        //    ticket.Favorited = true;
        //    context.Tickets.Update(ticket);
        //    context.SaveChanges();
        //    return ticket;
        //}




    }
}
