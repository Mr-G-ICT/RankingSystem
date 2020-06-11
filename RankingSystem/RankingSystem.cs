using System;
using System.Collections.Generic;
using System.Text;

namespace RankingSystem
{
    class RankingSystem
    {
        private struct UserDetails
        {
            public int UserRank { get; set; }
            public int currentProgress;

        }

        private UserDetails currentUser;

        public int getUserRank
        {
            get { return currentUser.UserRank; }
        }

  

        public int setCurrentProgress
        {
            set { currentUser.currentProgress = currentUser.currentProgress + value; }
        }
        public void setupUser()
        {
            //have created this for futureproofing, incase i ever need to get data from a file etc.
            currentUser.UserRank = -8;
            currentUser.currentProgress = 0;
        }


        public int completeAnActivity(int ChallengeCompleted)
        {
            int diff =  ChallengeCompleted - currentUser.UserRank;
            int pointsScored = 0;

            if (diff == 0)
            {
                pointsScored = 3;
            }else if(diff == -1)
            {
                pointsScored = 1;
            }else if(diff > 0)
            {
                pointsScored = 10 * (diff * diff);
            }

            return pointsScored;   
        }


        public void updateUserRank()
        {
            currentUser.UserRank = currentUser.UserRank + 1;

            if (currentUser.UserRank == 0)
            {
                currentUser.UserRank = 1;
            }
        }

        public void CheckForLevelUp()
        {

            if (currentUser.currentProgress >= 100)
            {
                updateUserRank();
                currentUser.currentProgress = currentUser.currentProgress - 100;
            }


        }
    
}
}
