using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitSetCore;
using TriWorkoutCore;
using HiitCore;

/*
 HW3 - Workout.cs
 Name: Bud Robinson
 Date: 09/23/22

 Description: The core class. Acts as the base class for the subclasses of the assignment. Contains all of the methods.
 */

namespace WorkoutCore
{
    /**
     * Class Invariants:
     * - All methods present as virtual/arbitrary/normal
     * - All virtual methods have dummy outputs (if any)
     * - start as valid and incomplete
     */
    public abstract class Workout
    {
        // Name and Classification default as null
        private protected string? name;
        private protected bool validation = true;
        private protected bool completion = false;
        private protected DateTime date;

        /* Pre:
         * Post: percentage of reps achieved as an double (100 == 100%)
         */
        public abstract double PercentAchieved();

        /* Pre:
         * Post: an double representing an arbitrary score
         */
        public abstract double Score();

        /* Pre:
         * Post: return name
         */
        public string GetName()
        {
            return name;
        }

        /* Pre:
         * Post: return validation
         */
        public bool GetValidation()
        {
            return validation;
        }

        /* Pre:
         * Post: return completion
         */
        public bool GetCompletion()
        {
            return completion;
        }

        /* Pre:
         * Post: return date
         */
        public DateTime GetDate()
        {
            return date;
        }


        /* Virtual Dummy Methods
         * - all empty/useless
         */
        public virtual void AttemptReps(int RepDone)
        {

        }
        public virtual void TimeDone(double DistanceDone, double MinDone)
        {

        }
        public virtual string GetClass()
        {
            return "dummy";
        }
        public virtual int GetWeight()
        {
            return 0;
        }
        public virtual double GetRepGoal()
        {
            return 0;
        }
        public virtual double GetRepAchieved()
        {
            return 0;
        }
        public virtual double GetMinGoal()
        {
            return 0;
        }
        public virtual double GetDisGoal()
        {
            return 0;
        }
        public virtual double GetPaceGoal()
        {
            return 0;
        }
        public virtual double GetMinAchieved()
        {
            return 0;
        }
        public virtual double GetDisAchieved()
        {
            return 0;
        }
        public virtual double GetPaceAchieved()
        {
            return 0;
        }
        public virtual double GetIntervalTime()
        {
            return 0;
        }
        public virtual double GetRestTime()
        {
            return 0;
        }
        public virtual FitSet FitClone()
        {
            return new FitSet("dummy", "dummy", 1, 1);
        }
        public virtual TriWorkout TriClone()
        {
            return new TriWorkout(1, 1, 1);
        }
        public virtual Hiit HiitClone()
        {
            return new Hiit(1, 1, 1, 1);
        }
    }

    public partial class Dummy : Workout
    {
        public Dummy(string Name, bool Vali, bool Compl)
        {
            name = Name;
            validation = Vali;
            completion = Compl;
            date = DateTime.Now;
        }

        public override double PercentAchieved()
        {
            return 1;
        }

        public override double Score()
        {
            return 1;
        }
    }
}