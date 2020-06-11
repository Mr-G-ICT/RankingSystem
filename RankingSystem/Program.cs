using System;

namespace RankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int pointsscored;
            
            Console.WriteLine("Hello World!");

            RankingSystem determineUserRank = new RankingSystem();

            determineUserRank.setupUser();
            pointsscored = determineUserRank.completeAnActivity(-4);

            Console.WriteLine(pointsscored + "points scored");

            determineUserRank.setCurrentProgress = pointsscored;

            determineUserRank.CheckForLevelUp();

            Console.WriteLine(determineUserRank.getUserRank);



        }



    }
}
