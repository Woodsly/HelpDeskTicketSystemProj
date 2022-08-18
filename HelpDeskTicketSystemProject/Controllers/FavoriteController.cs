using HelpDeskTicketSystemProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskTicketSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        TicketDBContext context = new TicketDBContext();
        [HttpGet("ShowFavoriteTickets")]
        public List<Ticket> ShowFavoriteTickets(string userName)
        {
            return context.Favorites.Include(x => x.Ticket).Where(x => x.UserName == userName).Select(e => e.Ticket).ToList();            
        }

        [HttpPost("AddFavorite")]
        public Favorite AddFavorite(int id,string name)
        {
            Favorite favTicket = new Favorite() { 
                TicketId = id,
                UserName = name            
            };
            context.Favorites.Add(favTicket);
            context.SaveChanges();
            return favTicket;
        }
    }
    
}
