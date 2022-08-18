using HelpDeskTicketSystemProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskTicketSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        TicketDBContext context = new TicketDBContext();
        [HttpGet("ShowFavoriteTickets")]
        public List<Ticket> ShowFavoriteTickets()
        {
            return context.Tickets.Where(x => x.Favorited == true).ToList();            
        }

        [HttpPost("AddFavorite")]
        public Favorite AddFavorite(int id)
        {
            Favorite favTicket = new Favorite() { 
                TicketId = id,
                UserName = ""
            };
            context.Favorites.Add(favTicket);
            context.SaveChanges();
            return favTicket;
        }
    }
    
}
