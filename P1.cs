using System;
using FitSetCore;

/*
 HW1 - P1.cs
 Name: Bud Robinson
 Date: 09/28/22

 Description: The main program. Demos the fit set class using functional decomposition

 Objective: Each FitSet object encapsulates its name, classification (arms, legs, core),
 weight, target repetitions, performed repetitions, and if and when the FitSet has been
 completed successfully. Once a exercise is started and repetitions entered the status
 is set and date recorded. The user is only able to set the weight and number of 
 repetitions once or the FitSet is considered invalid.
 */

namespace main
{
    class Program
    {
        static void Main()
        {
            // Into to Main()
            Console.WriteLine("Bud's P1 Main Execution: " +
                "A demo of my fit set class!\n\n");

            // Demo Loop
            // Assumptions: Inputting strings and positive integers when applicable
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Making A FitSet Object and displaying the Public Varaibles\n");

                // Make a FitSet object testFS with random weight and target reps
                FitSet testFS = new FitSet(rnd.Next(20, 200), rnd.Next(4, 20));
                // Inputing exercise name and exercise classification
                testFS.name = "Bench Press";
                testFS.classification = "Arms";

                //print exercise information
                Console.WriteLine($"Exercise Name: {testFS.name}\n" +
                    $"Exercise Classification: {testFS.classification}\n" +
                    $"Weight Per Rep: {testFS.weight} lbs\nTarget Reps: {testFS.tReps}\n\n");

                //----------------------------------------------------------
                // Inputting performed reps
                int randomNum = rnd.Next(8, 26);
                // Checks validity of exercise (completion, validation, and time completed)
                for (int z = 0; z < 2; z++)
                {
                    testFS.AttemptReps(randomNum);
                    Console.WriteLine($"Reps Attempted: {testFS.pReps}\nCompletion: {testFS.completion}\n" +
                        $"Validation: {testFS.validation}\nDate: {testFS.date}\n");
                    randomNum = randomNum - 5;
                }

                //----------------------------------------------------------
                // Checking percent of the exercise completed(pReps * 100 / tReps)
                Console.WriteLine($"Percent Achieved: {testFS.PercentAchieved()}%\n");

                // Checking Score  based on exercise stats (weight * pReps * 10 / tReps)
                Console.WriteLine($"Score: {testFS.Score()}\n");

                Console.WriteLine("-------------------------------------------------------------" +
                    "-------------------------------------");

            }
        }
    }
}