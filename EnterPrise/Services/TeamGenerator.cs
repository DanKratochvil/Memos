using EnterPrise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterPrise.Services
{
    public class TeamGenerator
    {
        private readonly Random rnd = new();
        private int childrenCreated = 1;

        public int MaxLevel { get; }
        public int MinChildrenCount { get; }
        public int MaxChildrenCount { get; }

        public TeamGenerator(int maxLevel = 4, int minChildrenCount = 1, int maxChildrenCount = 3)
        {
            MaxLevel = maxLevel;
            MinChildrenCount = minChildrenCount;
            MaxChildrenCount = maxChildrenCount;
        }

        public Member CreateTestTeam()
        {
            Member captain = new ()
            {
                Name = "C",
                Parent = null,
            };

            CreateChildren(captain, MaxLevel, 1);
            return captain;
        }

        private void CreateChildren(Member parent, int maxLevel, int level)
        {
            if (level > maxLevel)
            {
                return;
            }

            int childrenCount = rnd.Next(MinChildrenCount, MaxChildrenCount + 1);

            for (int i = 0; i < childrenCount; i++)
            {
                Member child = new ()
                {
                    Name = $"{level}.{childrenCreated++}",
                    Parent = parent
                };
                parent.Children.Add(child);
                CreateChildren(child, maxLevel, level + 1);
            }
        }
    }
}
