using WorkoutCore;
using FitSetCore;
using TriWorkoutCore;
using HiitCore;

/*
 HW3 - FitSet.cs
 Name: Bud Robinson
 Date: 11/02/22

 Description: The SessionLog is a list that can hold objects of base class Workout
 */

namespace SessionLogCore
{
    /**
     * Class Invariants:
     * - item always greater then or equal to zero
     * - workouts can only be subclasses
     */
    public class SessionLog
    {
        private List<Workout?> workouts = new List<Workout?>();
        private int items = 0;
        private bool editable = true;
        private bool valid = true;

        public SessionLog()
        {
            
        }

        /* Pre: temp is a workout subclass object
         * Post: Workout object added to workouts list
         */
        public void AddWorkout(Workout temp)
        {
            if (editable)
            {
                workouts.Add(temp);
                items++;
            }
        }

        /* Pre: The temp session must have atleast one object
         * Post: return a deep copy of the temp session ontop of the current session
         */
        public void BuildSession(SessionLog temp)
        {
            if (editable)
            {
                for (int i = 0; i < temp.GetItems(); i++)
                {
                    if (workouts[i].GetType() == typeof(FitSet))
                    {
                        AddWorkout(temp.workouts[i].FitClone());
                    } else if (workouts[i].GetType() == typeof(TriWorkout))
                    {
                        AddWorkout(temp.workouts[i].TriClone());
                    }
                    else
                    {
                        AddWorkout(temp.workouts[i].HiitClone());
                    }
                    items++;
                }
            }
        }

        /* Pre: a index (int > 0)
         * Post: removes the object at the index
         */
        public void RemoveWorkout(int removeIndex)
        {
            if (editable)
            {
                workouts.RemoveAt(removeIndex);
                items--;
            }
        }

        /* Pre: workouts must contain atleast one subclass object
         * Post: output request for inputs, finishing a exercise session
         */
        public void JustDoIt()
        {
            editable = false;
            for (int i = 0; i < items; i++)
            {
                var x = workouts[i].GetType();
                Workout t = workouts[i];
                if (x == typeof(FitSet))
                {
                    Console.WriteLine($"\n\nExercise Name: {t.GetName()}\n" +
                        $"Exercise Classification: {t.GetClass()}\n" +
                        $"Weigh: {t.GetWeight()} lbs\nTarget Reps: {t.GetRepGoal()}\n\n" +
                        $"Attempted Reps: ");
                    t.AttemptReps(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine($"\n\nPercent Completed: {t.PercentAchieved()}\n" +
                        $"Score: {t.Score()}\nCompleted: {t.GetDate()}\n");
                }else if (x == typeof(TriWorkout))
                {
                    Console.WriteLine($"\n\nExercise Name: {t.GetName()}\n" +
                        $"Target Minutes: {t.GetMinGoal()}\n" +
                        $"Target Miles: {t.GetDisGoal()}\nTarget Pace: {t.GetPaceGoal()}\n" +
                        $"Attempted Minutes and Miles: ");
                    double a = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(" and ");
                    double b = Convert.ToDouble(Console.ReadLine());
                    t.TimeDone(a, b);
                    Console.WriteLine($"\n\nPercent Completed: {t.PercentAchieved()}\n" +
                        $"Score: {t.Score()}\nCompleted: {t.GetDate()}\n");
                }else
                {
                    Console.WriteLine($"\n\nExercise Name: {t.GetName()}\n" +
                        $"Target Rep: {t.GetRepGoal()}\n" +
                        $"Interval Time: {t.GetIntervalTime()}\nRest Time: {t.GetRestTime()}\n" +
                        $"Attempted Reps: ");
                    t.AttemptReps(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine($"\n\nPercent Completed: {t.PercentAchieved()}\n" +
                        $"Score: {t.Score()}\nCompleted: {t.GetDate()}\n\n");
                }
            }
            var difOfDays = workouts[0].GetDate() - workouts[items - 1].GetDate();
            if (difOfDays.Days > 0)
            {
                valid = false;
            }
        }

        /* Pre:
         * Post: return item number;
         */
        public int GetItems()
        {
            return items;
        }

        /* Pre:
         * Post: return validation;
         */
        public bool GetValid()
        {
            return valid;
        }

        /* Pre:
         * Post: return workout list
         */
        public List<Workout?> ShareSession()
        {
            return workouts;
        }
    }
}
