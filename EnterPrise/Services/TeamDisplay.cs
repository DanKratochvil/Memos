using EnterPrise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterPrise.Services
{
    public class TeamDisplay
    {
        static public void DisplayTeam(Team team)
        {
            DisplayMember(team.Captain);
            DisplayChildren(team.Captain);
        }

        static public void DisplayInfected(List<string> infected)
        {
            Console.WriteLine("Infected members:");
            for (int i = 0; i < infected.Count; i++)
            {
                Console.Write($"{infected[i]} ");
            }
            Console.WriteLine();
        }


        static public void DisplayChildrenNames(Member member, List<string> childrenNames)
        {
            Console.WriteLine();
            Console.WriteLine($"Children of {member.Name}:");
            for (int i = 0; i < childrenNames.Count; i++)
            {
                Console.Write($"{childrenNames[i]} ");
            }
            Console.WriteLine();
        }

        static private void DisplayChildren(Member member)
        {
            if (member.Children == null)
            {
                return;
            }
            else
            {
                foreach (Member child in member.Children)
                {
                    DisplayMember(child);
                    DisplayChildren(child);
                }
            }
        }

        static private void DisplayMember(Member member)
        {
            Console.Write($"Name:{member.Name} Parent:{member.Parent?.Name} Children:");
            foreach(var child in member.Children)
            {
                Console.Write($"{child.Name} ");
            }
            Console.WriteLine();
        }
    }
}
