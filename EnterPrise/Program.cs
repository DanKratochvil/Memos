using EnterPrise.Models;
using EnterPrise.Services;

namespace Enterprise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxLevel = 5, minChildrenCount = 1, maxChildrenCount = 3;
            var teamGenerator = new TeamGenerator(maxLevel, minChildrenCount, maxChildrenCount);
            var team = new Team(teamGenerator.CreateTestTeam());
            TeamDisplay.DisplayTeam(team);

            Console.WriteLine("Infected member:");
            string? memberName = Console.ReadLine();
            team.FindMemberByName(memberName ?? "");

            if (team.FoundMember == null)
            {
                Console.WriteLine("Member not found");
                return;
            }

            var infected = team.GetAllInfected(team.FoundMember);
            TeamDisplay.DisplayInfected(infected);
        }
    }
}
