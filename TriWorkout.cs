using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutCore;

/*
 HW1 - TriWorkout.cs
 Name: Bud Robinson
 Date: 11/02/22

 Description: Makes an object that encapsulates an exercises name, distance run (miles),
 time spent active (minutes), and pace (varying measure)

NOTE: Pace Calculations are fucked

 */

namespace TriWorkoutCore
{
    /**
     * Class Invariants:
     * - minGoal, distanceGoal, paceGoal, minAchieved, distanceAchieved, and paceAchieved are always >= 0 when output
     */
    public partial class TriWorkout : Workout
    {
        public static readonly string [] cardio = {"Running", "Cycling", "Swimming"};

        private double minGoal = 0; // minutes
        private double distanceGoal = 0; //miles
        private double paceGoal = 0;

        private double minAchieved = -1;
        private double distanceAchieved = -1;
        private double paceAcheived = 0;

        /* Pre: a int between 0 and 2, doubles greater then 0
         * Post: A TriWorkout object with name, distance, minutes, and pace goals
         */
        public TriWorkout(int Name, double Distance, double MinuteGoal)
        {

            name = cardio[Name];
            distanceGoal = Distance;
            minGoal = MinuteGoal;
            if (name == "Running")
            {
                paceGoal = minGoal / distanceGoal;
            } else if (name == "Cycling")
            {
                paceGoal = distanceGoal / (minGoal / 60);
            }
            else
            {
                paceGoal = (minGoal * 60) / (distanceGoal / 0.0568182);
            }
        }

        /* Pre: two doubles that are greater or equal to zero
         * Post: A "completed" TriWorkout object
         */
        public override void TimeDone(double DistanceDone, double MinDone)
        {
            if (minAchieved >= 0 || distanceAchieved >= 0)
            {
                validation = false;
            }
            minAchieved = MinDone;
            distanceAchieved = DistanceDone;
            if (name == "Running")
            {
                paceAcheived = minAchieved / distanceAchieved;
            }
            else if (name == "Cycling")
            {
                paceAcheived = distanceAchieved / (minAchieved / 60);
            }
            else
            {
                paceAcheived = (minAchieved * 60) / (distanceAchieved / 0.0568182);
            }
            if (distanceAchieved >= distanceGoal && paceAcheived >= paceGoal)
            {
                completion = true; 
            }
            else
            {
                completion = false;
            }
            date = DateTime.Now;
        }

        /* Pre: paceGoal and distanceGoal are an integer greater then 0
         * Post: percentage of exercise processed as an average of distance and pace goal met (100 = 100%)
         */
        public override double PercentAchieved()
        {
            double solution = ((paceAcheived / paceGoal) * 100 + (distanceAchieved / distanceGoal) * 100) / 2;
            return solution;
        }

        /* Pre: look at PercentAchieved()
         * Post: an double representing an arbitrary score
         */
        public override double Score()
        {

            return distanceAchieved * PercentAchieved() / 10;
        }

        /* Pre:
         * Post: return minute goal;
         */
        public override double GetMinGoal()
        {
            return minGoal;
        }

        /* Pre:
         * Post: return distance goal;
         */
        public override double GetDisGoal()
        {
            return distanceGoal;
        }

        /* Pre:
         * Post: return pace goal
         */
        public override double GetPaceGoal()
        {
            return paceGoal;
        }

        /* Pre:
         * Post: return minutes achieved
         */
        public override double GetMinAchieved()
        {
            return minAchieved;
        }

        /* Pre:
         * Post: return distance achieved
         */
        public override double GetDisAchieved()
        {
            return distanceAchieved;
        }

        /* Pre:
         * Post: return pace achieved
         */
        public override double GetPaceAchieved()
        {
            return paceAcheived;
        }

        /* Pre: the existance of two TriWorkouts
         * Post: a new object, deep copying all of the information in the original object
         */
        public override TriWorkout TriClone()
        {

            TriWorkout Copy = new TriWorkout(0, this.distanceGoal, this.minGoal);
            Copy.name = this.name;
            Copy.distanceAchieved = this.distanceAchieved;
            Copy.minAchieved = this.minAchieved;
            Copy.paceAcheived = this.paceAcheived;
            Copy.validation = this.validation;
            Copy.completion = this.completion;
            return Copy;
        }
    }
}
