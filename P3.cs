using System;
using FitSetCore;
using TriWorkoutCore;
using HiitCore;
using SessionLogCore;
using WorkoutCore;

/*
 HW3 - P3.cs
 Name: Bud Robinson
 Date: 11/02/22

 Description: The main program. Demos the fit set class using functional decomposition
 */

namespace main
{
    public class Program
    {
        // MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN MAIN 
        public static void Main()
        {
            Random rnd = new Random();
            // Into to Main()
            Console.WriteLine("Bud's P3 Main Execution: " +
                "A demo of my inheritance classes!\n\n");

            var test1 = new Program();
            test1.FitSetTesting();
            test1.TriWorkoutTesting();
            test1.HiitTesting();
            test1.SessionLogTesting();
        }

        // UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL UNIVERSAL 
        // Prints out percent achieved and score of exercise
        public void PercentAndScore(Workout temp)
        {
            // Checking percent of the exercise completed
            Console.WriteLine($"Percent Achieved: {temp.PercentAchieved()}%\n");

            // Checking Score  based on exercise stats
            Console.WriteLine($"Score: {temp.Score()}\n\n");
        }

        // FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST FITTEST 
        // FitSet Tests
        public void FitSetTesting()
        {
            // Assumptions: Inputting strings and positive integers when applicable
            FitSet test = MakeAFitSet();
            InputFitSetValues(test);
            PercentAndScore(test);

            // Testing Deep Copying
            FitSet test2 = test.FitClone();
            Console.WriteLine("----- Deep Copy Test -----\n");
            PrintFitSet(test2);

            Console.WriteLine("-------------------------------------------------------------" +
                    "-------------------------------------\n\n");
        }


        //Print FitSet
        public void PrintFitSet(Workout testFS)
        {
            Console.WriteLine($"Exercise Name: {testFS.GetName()}\n" +
                $"Exercise Classification: {testFS.GetClass()}\n" +
                $"Weight Per Rep: {testFS.GetWeight()} lbs\nTarget Reps: {testFS.GetRepGoal()}\n\n");
        }
        // Makes and fills in a FitSet
        public FitSet MakeAFitSet()
        {
            Random rnd = new Random();
            Console.WriteLine("Making A FitSet Object and displaying the Public Varaibles\n");

            // Make a FitSet object testFS with random weight and target reps
            FitSet testFS = new FitSet("dummy name", "dummy cat", rnd.Next(20, 200), rnd.Next(4, 20));

            //print exercise information
            PrintFitSet(testFS);

            return testFS;
        }
        // Checks validity of exercise (completion, validation, and time completed)
        public void InputFitSetValues(FitSet temp)
        {
            Random rnd = new Random();
            // Inputting performed reps
            int randomNum = rnd.Next(8, 26);
            // Checks validity of exercise (completion, validation, and time completed)
            for (int z = 0; z < 2; z++)
            {
                temp.AttemptReps(randomNum);
                Console.WriteLine($"Reps Attempted: {temp.GetRepAchieved()}\nCompletion: {temp.GetCompletion()}\n" +
                    $"Validation: {temp.GetValidation()}\nDate: {temp.GetDate()}\n\n");
                randomNum = randomNum - 5;
            }
        }

        // TRIWORKOUT TRIWORKOUT TRIWORKOUT TRIWORKOUT TRIWORKOUT TRIWORKOUT TRIWORKOUT TRIWORKOUT TRIWORKOUT TRIWORKOUT
        //TriWorkout Tests
        public void TriWorkoutTesting()
        {
            // Assumptions: Inputting strings and positive integers when applicable
            for (int i = 0; i < 3; i++)
            {
                TriWorkout test = MakeATriWorkout(i);
                InputTriWorkoutValues(test);
                PercentAndScore(test);
            }

            // Testing Deep Copying
            TriWorkout test1 = MakeATriWorkout(0);
            TriWorkout test2 = test1.TriClone();
            Console.WriteLine("----- Deep Copy Test -----\n");
            PrintTriWorkout(test2);

            Console.WriteLine("-------------------------------------------------------------" +
                    "-------------------------------------\n\n");
        }

        // Print TriWorkout
        public void PrintTriWorkout(Workout testFS)
        {
            Console.WriteLine($"Exercise Name: {testFS.GetName()}\n" +
                $"Distance: {testFS.GetDisGoal()} miles\n" +
                $"Time: {testFS.GetMinGoal()} min\nPace: {testFS.GetPaceGoal()}\n\n");
        }
        // Makes and fills in a TriWorkout
        public TriWorkout MakeATriWorkout(int num)
        {
            Random rnd = new Random();
            Console.WriteLine("Making A TriWorkout Object and displaying the Varaibles\n");

            // Make a TriWorkout object testFS with random weight and target reps
            TriWorkout testFS = new TriWorkout(num, rnd.Next(1, 10), rnd.Next(10, 200));

            //print exercise information
            PrintTriWorkout(testFS);
            return testFS;
        }
        // Checks validity of exercise (completion, validation, and time completed)
        public void InputTriWorkoutValues(TriWorkout temp)
        {
            Random rnd = new Random();
            // Inputting performed reps
            int randomNum1 = rnd.Next(6, 16);
            int randomNum2 = rnd.Next(50, 500);
            // Checks validity of exercise (completion, validation, and time completed)
            for (int z = 0; z < 2; z++)
            {
                temp.TimeDone(randomNum1, randomNum2);
                Console.WriteLine($"Distance Done: {temp.GetDisAchieved()} miles\nTime Done: {temp.GetDisAchieved()} min\n" +
                    $"Pace Done: {temp.GetPaceAchieved()}\nCompletion: {temp.GetCompletion()}\nValidation: {temp.GetValidation()}\n" +
                    $"Date: {temp.GetDate()}\n\n");
                randomNum1 = randomNum1 - 5;
                randomNum2 = randomNum2 - 49;
            }
        }

        // HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT HIIT 
        //Hiit Tests
        public void HiitTesting()
        {
            // Assumptions: Inputting strings and positive integers when applicable
            for (int i = 0; i < 3; i++)
            {
                Hiit test = MakeAHiit(i);
                InputHiitValues(test);
                PercentAndScore(test);
            }

            // Testing Deep Copying
            Hiit test1 = MakeAHiit(0);
            Hiit test2 = test1.HiitClone();
            Console.WriteLine("----- Deep Copy Test -----\n");
            PrintHiit(test2);

            Console.WriteLine("-------------------------------------------------------------" +
                    "-------------------------------------\n\n");
        }

        // Print Hiit
        public void PrintHiit(Workout testFS)
        {
            Console.WriteLine($"Exercise Name: {testFS.GetName()}\nRep Goal: { testFS.GetRepGoal()}\n" +
                $"Interval Time: {testFS.GetIntervalTime()} sec\nRest Time: {testFS.GetRestTime()} sec\n\n");
        }
        // Makes and fills in a Hiit
        public Hiit MakeAHiit(int num)
        {
            Random rnd = new Random();
            Console.WriteLine("Making A Hiit Object and displaying the Varaibles\n");

            // Make a Hiit object testFS with random weight and target reps
            Hiit testFS = new Hiit(num, rnd.Next(50, 75), rnd.Next(45, 120), rnd.Next(30, 60));

            //print exercise information
            PrintHiit(testFS);

            return testFS;
        }
        // Checks validity of exercise (completion, validation, and time completed)
        public void InputHiitValues(Hiit temp)
        {
            Random rnd = new Random();
            // Inputting performed reps
            int randomNum1 = rnd.Next(60, 90);
            // Checks validity of exercise (completion, validation, and time completed)
            for (int z = 0; z < 2; z++)
            {
                temp.AttemptReps(randomNum1);
                Console.WriteLine($"Reps Attempted: {temp.GetRepAchieved()}\nCompletion: {temp.GetCompletion()}\n" +
                    $"Validation: {temp.GetValidation()}\nDate: {temp.GetDate()}\n\n");
                randomNum1 = randomNum1 - 50;
            }
        }

        // SESSIONLOG SESSIONLOG SESSIONLOG SESSIONLOG SESSIONLOG SESSIONLOG SESSIONLOG SESSIONLOG SESSIONLOG SESSIONLOG SESSIONLOG 
        //SessionLog Tests
        public void SessionLogTesting()
        {
            // Assumptions: Inputting strings and positive integers when applicable
            SessionLog Log = MakeASessionLog();
            DisplayLastLogFitSet(Log);
            DeleteLastLogAndDisplay(Log);
            //TestBuildSession(Log);
            // NOTE: JustDoIt Works, but is inelegant and against what was wanted by P2
            Log.JustDoIt();

            Console.WriteLine("-------------------------------------------------------------" +
                    "-------------------------------------\n\n");
        }
        // Makes a SessionLog and populates it with different subclass objects
        public SessionLog MakeASessionLog()
        {
            SessionLog List = new SessionLog();
            for (int i = 4; i < 7; i++)
            {
                Hiit test = MakeAHiit(i);
                List.AddWorkout(test);
            }
            TriWorkout test2 = MakeATriWorkout(0);
            List.AddWorkout(test2);

            FitSet test3 = MakeAFitSet();
            List.AddWorkout(test3);

            return List;
        }
        // Displays the last Logged object (function custom made for a fitset)
        public void DisplayLastLogFitSet(SessionLog temp)
        {
            Console.WriteLine("----- Showing Last Log Input -----\n");
            Workout testFS = temp.ShareSession()[temp.GetItems() - 1];
            PrintFitSet(testFS);
        }
        // Removes an object and shows new next
        public void DeleteLastLogAndDisplay(SessionLog temp)
        {
            temp.RemoveWorkout(temp.GetItems() - 1);
            Console.WriteLine("----- Showing New Last Log Input -----\n");
            PrintTriWorkout(temp.ShareSession()[temp.GetItems() - 1]);
        }
        // Demonstrating Build Session
        // NOTES: BuildSession Not Working
        public void TestBuildSession(SessionLog temp)
        {
            SessionLog NewLog = new SessionLog();
            NewLog.BuildSession(temp);
            Console.WriteLine("----- Showing Last Log Input -----\n");
            PrintTriWorkout(temp.ShareSession()[temp.GetItems() - 1]);
        }
    }
}