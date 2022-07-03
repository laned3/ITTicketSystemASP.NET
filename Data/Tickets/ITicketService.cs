using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITTicketSystem.Data.Tickets
{
    public interface ITicketService
    {
        Task<bool> TicketInsert(Ticket tickets);
        Task<IEnumerable<Ticket>> TicketList();
        Task<IEnumerable<Ticket>> TicketListHistory();
        Task<bool> TicketUpdate(Ticket tickets);
        Task<Ticket> Ticket_GetOne(int id);
        Task<IEnumerable<Ticket>> Ticket_Count();
        Task<IEnumerable<Ticket>> Ticket_Analytics();
        Task<IEnumerable<Ticket>> Unhandled_Tickets();
    }
}