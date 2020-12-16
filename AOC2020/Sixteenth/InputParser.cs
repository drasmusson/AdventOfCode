using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Sixteenth
{
    public static class InputParser
    {
        public static List<Ticket> TicketList = GetNearbyTickets();
        public static Dictionary<string, List<(int, int)>> TicketFieldRules = GetValidRanges();
        public static Ticket YourTicket = GetYourTicket();

        private static List<Ticket> GetNearbyTickets()
        {
            var stringInput = Resources.ResourceManager.GetObject("SixteenthInput") as string;
            var nearbyTicketsSplit = stringInput.Split("nearby tickets:", StringSplitOptions.RemoveEmptyEntries).ToList();

            var nearbyTycketStringss = nearbyTicketsSplit.Last().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var nearbyTickets = new List<Ticket>();
            foreach (var nearbyTicketString in nearbyTycketStringss)
            {
                var ticketValueStrings = nearbyTicketString.Split(",");
                var ticket = new Ticket();
                foreach (var ticketValueString in ticketValueStrings)
                {
                    ticket.FieldValues.Add(int.Parse(ticketValueString));
                }
                nearbyTickets.Add(ticket);
            }

            return nearbyTickets;
        }

        private static Dictionary<string, List<(int, int)>> GetValidRanges()
        {
            var stringInput = Resources.ResourceManager.GetObject("SixteenthInput") as string;
            var yourTicketSplit = stringInput.Split("your ticket:", StringSplitOptions.RemoveEmptyEntries).ToList();

            var validRangeStrings = yourTicketSplit.First().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var ticketFieldRules = new Dictionary<string, List<(int, int)>>();

            foreach (var validRangeString in validRangeStrings)
            {
                var keySplit = validRangeString.Split(": ");

                var orSplit = keySplit.Last().Split(" or ");
                var firstLineSplit = orSplit.First().Split("-");

                var values = new List<(int, int)>();
                values.Add((int.Parse(firstLineSplit.First()), int.Parse(firstLineSplit.Last())));

                var secondLineSplit = orSplit.Last().Split("-");
                values.Add((int.Parse(secondLineSplit.First()), int.Parse(secondLineSplit.Last())));

                ticketFieldRules.Add(keySplit.First(), values);
            }

            return ticketFieldRules;
        }

        private static Ticket GetYourTicket()
        {
            var stringInput = Resources.ResourceManager.GetObject("SixteenthInput") as string;
            var yourTicketSplit = stringInput.Split("your ticket:", StringSplitOptions.RemoveEmptyEntries).ToList();

            var nearbyTicketsSplit = yourTicketSplit.Last().Split("nearby tickets:", StringSplitOptions.RemoveEmptyEntries).ToList();

            var yourTicketStrings = nearbyTicketsSplit.First().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var ticketValueStrings = yourTicketStrings.Last().Split(",");
            var ticket = new Ticket();
            foreach (var ticketValueString in ticketValueStrings)
            {
                ticket.FieldValues.Add(int.Parse(ticketValueString));
            }

            return ticket;
        }
    }
}
