using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterPrise.Models
{
    public class Team
    {
        private readonly List<string> allChildren = new ();
        private readonly List<string> allInfected = new ();
        private int stepCount = 0;

        public Member Captain { get; }
        public Member? FoundMember { get; private set; } = null;

        public Team(Member captain)
        {
            Captain = captain;
        }

        public List<String> GetAllChildren(Member member)
        { 
            GetChildren(member);
            return allChildren;
        }

        public List<string> GetAllInfected(Member member)
        {
            stepCount = GetStepsCount(member);
            member.IsInfected = true;
            allInfected.Add(member.Name);

            while (member.Parent != null)
            {
                GetInfectedChildren(member, stepCount, 1);
                member = member.Parent;
                if (member.IsInfected == false)
                {
                    member.IsInfected = true;
                    allInfected.Add(member.Name);
                }

                stepCount--;
            }

            return allInfected.ToList(); 
        }

        public void FindMemberByName(string name)
        {
            SearchName(Captain, name);
        }


        private void GetChildren(Member member)
        {
            if (member.Children == null)
            {
                return;
            }
            else
            {
                foreach (Member child in member.Children)
                {
                    allChildren!.Add(child.Name);
                    GetChildren(child);
                }
            }
        }

        private void GetInfectedChildren(Member member, int stepcount, int stepno)
        {
            if (member.Children == null || stepno++ > stepCount)
            {
                return;
            }
            else
            {
                foreach (Member child in member.Children)
                {
                    if (child.IsInfected == false)
                    {
                        child.IsInfected = true;
                        allInfected.Add(child.Name);
                    }
                    GetInfectedChildren(child, stepcount, stepno);
                }
            }
        }

        private void SearchName (Member member, string name)
        {
            if (member.Name == name)
            {
                Console.WriteLine($"Member found: {member.Name}");
                FoundMember = member;
                return;
            }

            if (member.Children == null)
            {
                return;
            }
            else
            {
                foreach (Member child in member.Children)
                {
                    SearchName(child, name);
                }
            }
        }

        private int GetStepsCount(Member member)
        {
            int steps = 0;
            while (member.Parent != null)
            {
                steps++;
                member = member.Parent;
            }
            return steps;
        }
    }
}
