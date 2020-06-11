using System;
using System.Collections.Generic;
using System.Text;

namespace RankingSystem
{
    class RankingSystem
    {

        //simple sruct to hold the userrank and their progress to the next level
        private struct UserDetails
        {
            public int UserRank;
            public int currentProgress;

        }

        //set as global within the module as everything in this module relates to this user
        private UserDetails currentUser;

        //for security with additional modules.
        public int getUserRank
        {
            get { return currentUser.UserRank; }
        }

  
        //current progress as a set method due to the addition of points which is different to a standard get/set method
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
            //this is the key to the whole thing, if a user completes an activity then determine based on the
            //level of the character how many points are achieved. if the it is a same level challenge, then get
            //3 points, if it's any higher, then you get a multiple of 10

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
            //you can only go up 1 rank at a time, however you can never be at rank 0
            //so you skip that rank and hit level 1 as a boost!
            
            currentUser.UserRank = currentUser.UserRank + 1;

            if (currentUser.UserRank == 0)
            {
                currentUser.UserRank = 1;
            }
        }

        public void CheckForLevelUp()
        {
            //simple funciton that checks if you have achieved enough points to level up.
            if (currentUser.currentProgress >= 100)
            {
                updateUserRank();
                currentUser.currentProgress = currentUser.currentProgress - 100;
            }


        }
    
}
}
