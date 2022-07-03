using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ITTicketSystem.Data.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public TicketService(SqlConnectionConfiguration confirguation)
        {
            _configuration = confirguation;
        }

        //Insert New Ticket
        public async Task<bool> TicketInsert(Ticket tickets)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Title", tickets.Title, DbType.String);
                parameters.Add("Category", tickets.Category, DbType.String);
                parameters.Add("Description", tickets.Description, DbType.String);                
                parameters.Add("RequestedBy", tickets.RequestedBy, DbType.String);
                parameters.Add("AssignedTo", tickets.AssignedTo, DbType.String);

                await conn.ExecuteAsync("ITTicketSystem_InsertTicket", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        //Get a List of Tickets
        public async Task<IEnumerable<Ticket>> TicketList()
        {
            IEnumerable<Ticket> tickets;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                tickets = await conn.QueryAsync<Ticket>("ITTicketSystem_GetTickets", commandType: CommandType.StoredProcedure);
            }
            return tickets;
        }

        //Get a List of Historical Tickets 
        public async Task<IEnumerable<Ticket>> TicketListHistory()
        {
            IEnumerable<Ticket> tickets;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                tickets = await conn.QueryAsync<Ticket>("ITTicketSystem_GetHistoricalTickets", commandType: CommandType.StoredProcedure);
            }
            return tickets;
        }

        //Get One Ticket by ID
        public async Task<Ticket> Ticket_GetOne(int id)
        {
            Ticket ticket = new Ticket();
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using (var conn = new SqlConnection(_configuration.Value))
            {
                ticket = await conn.QueryFirstOrDefaultAsync<Ticket>("ITTicketSystem_GetOneTicket", parameters, commandType: CommandType.StoredProcedure);
            }
            return ticket;
        }

        // Update a Ticket
        public async Task<bool> TicketUpdate(Ticket tickets)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("TicketID", tickets.TicketID, DbType.Int32);
                parameters.Add("TicketStatus", tickets.TicketStatus, DbType.String);
                //parameters.Add("AssignedTo", tickets.AssignedTo, DbType.String);
                parameters.Add("TicketNotes", tickets.TicketNotes, DbType.String);
                parameters.Add("UpdatedDate", tickets.UpdatedDate, DbType.Date);
                await conn.ExecuteAsync("ITTicketSystem_UpdateTicket", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        // Get Ticket Count
        async Task<IEnumerable<Ticket>> ITicketService.Ticket_Count()
        {
            IEnumerable<Ticket> countTickets;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                countTickets = await conn.QueryAsync<Ticket>("ITTicketSystem_TicketCount", commandType: CommandType.StoredProcedure);
            }
            return countTickets;
        }

        // Get Ticket Analytics
        async Task<IEnumerable<Ticket>> ITicketService.Ticket_Analytics()
        {
            IEnumerable<Ticket> ticketAnalysis;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                ticketAnalysis = await conn.QueryAsync<Ticket>("ITTicketSystem_TicketAnalytics", commandType: CommandType.StoredProcedure);
            }
            return ticketAnalysis;
        }

        // Get Number of Unhandled Tickets
        async Task<IEnumerable<Ticket>> ITicketService.Unhandled_Tickets()
        {
            IEnumerable<Ticket> unhandledTickets;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                unhandledTickets = await conn.QueryAsync<Ticket>("ITTicketSystem_UnhandledTickets", commandType: CommandType.StoredProcedure);
            }
            return unhandledTickets;
        }
    }
}
