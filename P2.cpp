// Created by Bud Robinson on 10/17/2022.
// File: P2.cpp

#include <iostream>
#include <stdio.h>
#include <stdlib.h> //rand
#include <memory> //smart pointers
#include "fitSet.h"
#include "fitSet.cpp"
#include "sessionLog.h"
#include "sessionLog.cpp"

using namespace std;

/*
 *
 * READ ME!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 *
 * Ran into trouble making sessionLog, couldn't figure out doing it with dynamic arrays (debugging wasn't going
 * anywhere). Decided to use linked lists. Completley bacuhed execution, functions stopped working. Have it partially
 * working. Hopefully Ill get some credit. Did this in one sitting, really tired. have to submit in 30 min. Gonna
 * comment the shit outta this code before bed. Sorry for the poor work whoever is grading this.
 *
 * This driver code assumes you put down string and positive integers when prompted
 *
 */

//-------------------------------------------------------------------------------------------------------------------
void FitSetTest();
void DisplayFitSetVariables(fitSet temp);
void syntheticPerformedReps(fitSet temp);
void percentageAndScore(fitSet temp);
//-------------------------------------------------------------------------------------------------------------------
void SessionLogTest();
void AddItemsToSession(shared_ptr<sessionLog>temp());
void DisplaySession(shared_ptr<sessionLog>temp());
void RemoveItemFromSession(shared_ptr<sessionLog>temp());
void CombineSession(shared_ptr<sessionLog>main(), shared_ptr<sessionLog>small());
void CopySession(shared_ptr<sessionLog>temp());
void PerformSession(shared_ptr<sessionLog>temp());
//-------------------------------------------------------------------------------------------------------------------

int main(){
    srand (time(NULL));

    // Intro to my FitSet Demo
    cout << "Bud's P1 Driver: A demo of my fit set class!\n\n";

    //The translation of my P1 Testing on fitSet
    FitSetTest();


    // Intro to my Session Log Demo
    cout << "Bud's P2 Driver: A demo of my session log class!\n\n";

    //P2 Testing
    SessionLogTest();
}
//-------------------------------------------------------------------------------------------------------------------
//P1 Tests
void FitSetTest(){
    // Assumptions: Inputting strings and positive integers when applicable
    for (int i = 0; i < 5; i++) {
        // Make a FitSet object testFS smartPointer
        fitSet test;
        test.AddData("testName", "testClass", rand() % 200 + 10, rand() % 20 + 2);

        //Creates new fitSet with random data, displays data (name, class, weight, tReps)
        DisplayFitSetVariables(test);

        // randomizing performed reps
        int randPReps = rand() % 22 + 10;
        test.PerformedReps(randPReps);

        //Create synthetic performed reps, view status after (pReps, Completion, Validation, LoggedTime)
        syntheticPerformedReps(test);

        //Output percentage of reps done and score for exercise
        percentageAndScore(test);
    }
}

void DisplayFitSetVariables(fitSet temp){
    // output temp data
    cout << "Name: " << temp.GetName();
    cout << "\nClass: " << temp.GetClass();
    cout << "\nWeight: " << temp.GetWeight();
    cout << "\nTarget Reps: " << temp.GetTReps();
    cout << "\nCompletion: " << temp.GetComplete() << "\n\n";
}
void syntheticPerformedReps(fitSet temp){
    // Checks validity of exercise (completion, validation, and time completed)
    for (int z = 0; z < 2; z++) {
        cout << "Performed Reps: " << temp.GetPReps();
        cout << "\nCompletion Status: " << temp.GetComplete();
        cout << "\nValidation Status: " << temp.GetValid();
        cout << "\nTime of Input: " << temp.GetTime() << "\n\n";
        temp.PerformedReps(temp.GetPReps() - 5);
    }
}

void percentageAndScore(fitSet temp){
    cout << "Percentage of Exercise Achieved: " << temp.PercentAchieved() << "%";
    cout << "\nExercise Score: " << temp.Score();
    cout << "\n-------------------------------------------------------------------------\n";
}

//-------------------------------------------------------------------------------------------------------------------
//P2 Tests
void SessionLogTest(){
    //Making two session logs
    //NOTE!!!!!!!!!!!
    //REMEMBER TO ADD SHARED POINTERS
    shared_ptr<sessionLog>L1(new sessionLog());
    shared_ptr<sessionLog>L2(new sessionLog());

    //Adding fitSets to L1 and L2
    AddItemsToSession(L1);
    AddItemsToSession(L2);

    //Displaying L1 and L2
    DisplaySession(L1);
    DisplaySession(L2);

    //Testing Remove
    RemoveItemFromSession(L2);
    DisplaySession(L2);

    //Testing buildSession
    CombineSession(L1, L2);
    DisplaySession(L1);

    //Testing Just Do It
    L2.justDoIt();
    DisplaySession(L2);
}

void AddItemsToSession(shared_ptr<sessionLog>temp()){
    for(int i = 0; i < 5; i++){
        fitSet test("testName", "testClass", rand() % 200 + 10, rand() % 20 + 2);
        temp.addSet(test);
    }
}

void DisplaySession(shared_ptr<sessionLog>temp()){
    int size = temp.giveSize();
    item* ptr = temp.shareSession();
    for(int i = 0; i < size; ++i){
        if(ptr[i]){
            DisplayFitSetVariables(ptr[i]);
        }
    }
}

void RemoveItemFromSession(shared_ptr<sessionLog>temp()){
    item* ptr = temp.shareSession();
    item saved = ptr[0];
    temp.removeSet(saved);
}

void CombineSession(shared_ptr<sessionLog>main(), shared_ptr<sessionLog>small()){
    main.buildSession(small);
}

void CopySession(shared_ptr<sessionLog>temp()){

}

void PerformSession(shared_ptr<sessionLog>temp()){

}
