using WorkoutCore;

/*
 HW3 - FitSet.cs
 Name: Bud Robinson
 Date: 11/02/22

 Description:Makes an object that encapsulates an exercises name, classification (arms, legs, core),
 weight, target repetitions, performed repetitions, and date of completion of the rep.
 */

namespace FitSetCore
{
    /**
     * Class Invariants:
     * - weight, repGoal, repDone always greater then or equal to zero when output
     */
    public partial class FitSet : Workout
    {
        private string? classification;
        private int weight = 0;
        private int repGoal = 0;
        private int repDone = -1;

        /* Pre: ints greater then 0 
         * Post: A FitSet object (incomplete)
         */
        public FitSet(string Name, string Classification, int Weight, int RepGoal)
        {
            name = Name;
            classification = Classification;
            weight = Weight;
            repGoal = RepGoal;
        }

        /* Pre: a RepDone greater then -1
         * Post: The possible validation and completion of an object, can now call score and percentAchieved
         */
        public override void AttemptReps(int RepDone)
        {
            if (repDone >= 0)
            {
                validation = false;
            }
            repDone = RepDone;
            if (repDone >= repGoal)
            {
                completion = true;
            }
            else
            {
                completion = false;
            }
            date = DateTime.Now;
        }

        /* Pre: a repGoal and repDone present, with a goal greater then 0
         * Post: percentage of reps achieved as an double (100 == 100%)
         */
        public override double PercentAchieved()
        {
            return repDone * 100 / repGoal;
        }

        /* Pre: repDone present, then 0
         * Post: a double representing an arbitrary score
         */
        public override double Score()
        {
            return weight * PercentAchieved() / 10;
        }

        /* Pre:
         * Post: return classification
         */
        public override string GetClass()
        {
            return classification;
        }

        /* Pre:
         * Post: return weight
         */
        public override int GetWeight()
        {
            return weight;
        }

        /* Pre:
         * Post: return repGoal
         */
        public override double GetRepGoal()
        {
            return repGoal;
        }

        /* Pre:
         * Post: return repDone
         */
        public override double GetRepAchieved()
        {
            return repDone;
        }

        /* Pre: the existance of similar FitSets
         * Post: a new object, deep copying all of the information in the original object
         */
        public override FitSet FitClone()
        {
            FitSet Copy = new FitSet(this.name, this.classification, this.weight, this.repGoal);
            Copy.repDone = this.repDone;
            Copy.validation = this.validation;
            Copy.completion = this.completion;
            return Copy;
        }
    }
}