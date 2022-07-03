using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITTicketSystem.Data.Tickets
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public string Description { get; set; }

        public string TicketStatus { get; set; }

        public string RequestedBy { get; set; }

        public string AssignedTo { get; set; }

        public string TicketNotes { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int TicketCount { get; set; }
        
        public string Status { get; set; }
        
        public string AppUser { get; set; }

        public int OpenTickets { get; set; }
        
        public int CompletedTickets {get; set; }
        
        public int CancelledTickets{get; set; }

        public DateTime RequestedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public int UnhandledTickets { get; set; }
    }
}
