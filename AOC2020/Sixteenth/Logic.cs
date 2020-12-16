using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Sixteenth
{
    public static class Logic
    {
        public static long Run()
        {
            //var result1 = First();
            var result2 = Second();
            return result2;
        }

        private static long First()
        {
            List<Ticket> tickets = InputParser.TicketList;
            var ticketFieldRules = InputParser.TicketFieldRules;

            int lowestValid = 999;
            int highestValid = 0;

            foreach (var ticketFieldRule in ticketFieldRules)
            {
                foreach (var ruleRange in ticketFieldRule.Value)
                {
                    lowestValid = ruleRange.Item1 < lowestValid ? ruleRange.Item1 : lowestValid;
                    highestValid = ruleRange.Item2 > highestValid ? ruleRange.Item2 : highestValid;
                }
            }

            var invalidTicketValues = tickets.Select(t => t.GetMyInvalidFieldValues(lowestValid, highestValid)).ToList();
            var invalidTicketSum = invalidTicketValues.SelectMany(it => it).Sum();
            return invalidTicketSum;
        }


        private static long Second()
        {
            var ticketFieldRulesInput = InputParser.TicketFieldRules;

            int lowestValid = 999;
            int highestValid = 0;

            foreach (var ticketFieldRule in ticketFieldRulesInput)
            {
                foreach (var ruleRange in ticketFieldRule.Value)
                {
                    lowestValid = ruleRange.Item1 < lowestValid ? ruleRange.Item1 : lowestValid;
                    highestValid = ruleRange.Item2 > highestValid ? ruleRange.Item2 : highestValid;
                }
            }

            List<Ticket> tickets = InputParser.TicketList.Where(t => t.IsValid1(lowestValid, highestValid)).ToList();
            List<TicketFieldRule> fieldRules = ticketFieldRulesInput.Select(i => new TicketFieldRule(i)).ToList();

            foreach (var position in Enumerable.Range(0, 20))
            {
                foreach (var fieldRule in fieldRules)
                {
                    var ticketValues = tickets.Select(t => t.FieldValues[position]).ToList();

                    fieldRule.RemovePositionFromApplicableIfInvalid(position, ticketValues);
                }
            }

            var uniquePositionRules = fieldRules.Where(fr => fr.PositionsWhereRuleIsApplicable.Count() == 1).Select(x => x.PositionsWhereRuleIsApplicable.First()).ToList();

            RemovePositionRulesUntilOneForOne(fieldRules, uniquePositionRules);

            var relevantRulePositions = fieldRules.Where(fr => fr.FieldName.Contains("departure")).Select(rr => rr.PositionsWhereRuleIsApplicable.First()).ToList();

            long result = 1;
            var yourTicket = InputParser.YourTicket;
            foreach (var position in relevantRulePositions)
            {
                result *= yourTicket.FieldValues[position];
            }

            return result;
        }

        private static void RemovePositionRulesUntilOneForOne(List<TicketFieldRule> fieldRules, List<int> uniquePositionRules)
        {
            if (fieldRules.All(fr => fr.PositionsWhereRuleIsApplicable.Count() == 1))
            {
                return;
            }

            fieldRules.ForEach(fr => fr.RemovePositionsFromApplicable(uniquePositionRules));

            uniquePositionRules = fieldRules.Where(fr => fr.PositionsWhereRuleIsApplicable.Count() == 1).Select(x => x.PositionsWhereRuleIsApplicable.First()).ToList();

            RemovePositionRulesUntilOneForOne(fieldRules, uniquePositionRules);
        }
    }

    public class Ticket
    {
        public List<int> FieldValues { get; set; }

        public Ticket()
        {
            FieldValues = new List<int>();
        }

        public List<int> GetMyInvalidFieldValues(int lowestValid, int highestValid)
        {
            var invalidFieldValues = new List<int>();

            foreach (var fieldValue in FieldValues)
            {
                if (fieldValue < lowestValid || fieldValue > highestValid)
                {
                    invalidFieldValues.Add(fieldValue);
                }
            }
            return invalidFieldValues;
        }

        public bool IsValid1(int lowestValid, int highestValid)
        {
            foreach (var fieldValue in FieldValues)
            {
                if (fieldValue < lowestValid || fieldValue > highestValid)
                {
                    return false;
                }
            }
            return true; ;
        }
    }

    public class TicketFieldRule
    {
        public string FieldName { get; set; }
        public (int, int) FirstValidInterval { get; set; }
        public (int, int) SecondValidInterval { get; set; }
        public List<int> PositionsWhereRuleIsApplicable { get; set; }

        public TicketFieldRule(KeyValuePair<string, List<(int, int)>> input)
        {
            FieldName = input.Key;
            FirstValidInterval = input.Value.First();
            SecondValidInterval = input.Value.Last();
            PositionsWhereRuleIsApplicable = Enumerable.Range(0, 20).ToList();
        }

        public void RemovePositionsFromApplicable(List<int> poisitions)
        {
            if (PositionsWhereRuleIsApplicable.Count() != 1)
            {
                PositionsWhereRuleIsApplicable = PositionsWhereRuleIsApplicable.Where(i => !poisitions.Contains(i)).ToList();
            }
        }

        public void RemovePositionFromApplicableIfInvalid(int position, List<int> values)
        {
            foreach (var value in values)
            {
                if (!IsValueValid(value))
                {
                    PositionsWhereRuleIsApplicable = PositionsWhereRuleIsApplicable.Where(x => x != position).ToList();
                    return;
                }
            }
        }

        private bool IsValueValid(int value)
        {
            if (!(FirstValidInterval.Item1 <= value && value <= FirstValidInterval.Item2) && !(SecondValidInterval.Item1 <= value && value <= SecondValidInterval.Item2))
            {
                return false;
            }
            return true;
        }
    }
}
