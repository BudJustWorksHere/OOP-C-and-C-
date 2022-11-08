using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 HW1 - FitSet.cs
 Name: Bud Robinson
 Date: 09/23/22

 Description: The core class. Makes an object that encapsulates an exercises name, classification (arms, legs, core),
 weight, target repetitions, performed repetitions, and date of completion of the rep.
 */

namespace FitSetCore
{
    /**
     * Class Invariants:
     * - validation = true
     */
    public class FitSet
    {
        // Name and Classification default as null
        public string? name { get; set; }
        public string? classification { get; set; }
        public int weight { get; } = 0;
        public int tReps { get; } = 0;
        public int pReps { get; private set; } = 0;
        public bool completion { get; private set; } = false;
        public DateTime date { get; private set; }
        public bool validation { get; private set; } = true;

        public FitSet(int Weight, int TReps)
        {
            weight = Weight;
            tReps = TReps;
        }

        /* Pre: 
         * Post: pReps = Preps, validaiton = false if pReps has been changed, completion
         *       = true if pReps exceeds tReps, date = time of function call.
         */
        public void AttemptReps(int Preps)
        {
            if (pReps != 0)
            {
                validation = false;
            }
            pReps = Preps;
            if (pReps >= tReps)
            {
                completion = true;
            }
            date = DateTime.Now;
        }

        /* Pre: tReps and pReps are an integer greater then 0
         * Post: percentage of reps achieved as an integer
         */
        public int PercentAchieved()
        {
            return this.pReps * 100 / this.tReps;
        }

        /* Pre: weight, tReps, and pReps are inteegers greater than 0
         * Post: an integer representing an arbitrary score
         */
        public int Score()
        {
            return this.weight * this.PercentAchieved() / 10;
        }

    }

}