using WorkoutCore;

/*
 HW1 - Hiit.cs
 Name: Bud Robinson
 Date: 11/02/22

 Description: Makes an object that encapsulates an exercises name (from a set list), repition goal,
 interval time to perform exercise, rest time after exercise, and performed repetitions.
 */

namespace HiitCore
{
    /**
     * Class Invariants:
     * - repGoal, repAchieved, intervalTime, and restTime always >= 0 by output
     */
    public partial class Hiit : Workout
    {
        public static readonly string[] exercises = {"high jacks", "plank jacks",
            "burpees", "jumping lunges", "mountain climbers", "jumping squats",
            "side lunges", "saw plank", "butt kicks", "sideplank walks", "jumping jacks"};

        private int repGoal = 0;
        private int repAchieved = -1;

        private double intervalTime = 0;
        private double restTime = 0;

        /* Pre: a int between 0-10, and the rest >= 0
         * Post: A Hiit object is made
         */
        public Hiit(int Name, int RepGoal, double IntervalTime, double RestTime)
        {
            name = exercises[Name];
            repGoal = RepGoal;
            intervalTime = IntervalTime;
            restTime = RestTime;
        }

        /* Pre: int >= 0
         * Post: the attempt of the exercise is recorded and judged
         */
        public override void AttemptReps(int RepDone)
        {
            if (repAchieved >= 0)
            {
                validation = false;
            }
            repAchieved = RepDone;
            if (repAchieved >= repGoal)
            {
                completion = true;
            }
            else
            {
                completion = false;
            }
            date = DateTime.Now;
        }

        /* Pre: repGoal is a double greater then 0
         * Post: percentage of reps achieved as an double (100 == 100%)
         */
        public override double PercentAchieved()
        {
            return repAchieved * 100 / repGoal;
        }

        /* Pre: repGoal >= 0
         * Post: a double representing an arbitrary score
         */
        public override double Score()
        {
            return intervalTime * PercentAchieved() / restTime;
        }

        /* Pre:
         * Post: return rep goal
         */
        public override double GetRepGoal()
        {
            return repGoal;
        }

        /* Pre:
         * Post: return rep achieved
         */
        public override double GetRepAchieved()
        {
            return repAchieved;
        }

        /* Pre:
         * Post: return interval time
         */
        public override double GetIntervalTime()
        {
            return intervalTime;
        }

        /* Pre:
         * Post: return rest time
         */
        public override double GetRestTime()
        {
            return restTime;
        }
        /* Pre: the existance of two Hiit Objects
         * Post: a new object, deep copying all of the information in the original object
         */
        public override Hiit HiitClone()
        {
            Hiit Copy = new Hiit(0, this.repGoal, this.intervalTime, this.restTime);
            Copy.name = this.name;
            Copy.repAchieved = this.repAchieved;
            Copy.validation = this.validation;
            Copy.completion = this.completion;
            return Copy;
        }
    }
}
