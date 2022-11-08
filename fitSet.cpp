//
// Created by Bud Robinson on 10/10/2022.
//

//NOTES: Invariants

#include <iostream>
#include <stdio.h>
#include <ctime>
#include "fitSet.h"

using namespace std;

fitSet::fitSet();{

}
fitSet::fitSet(string name, string classification, int weight, int tReps){
    Name = name;
    Classification = classification;
    Weight = weight;
    TargetReps = tReps;
    PerformReps = -1;
}
fitSet::~fitSet(){

}

string fitSet::GetName(){
    return Name;
}
string fitSet::GetClass(){
    return Classification;
}
int fitSet::GetWeight(){
    return Weight;
}
int fitSet::GetTReps(){
    return TargetReps;
}
int fitSet::GetPReps(){
    return PerformReps;
}
bool fitSet::GetComplete(){
    return Completion;
}
bool fitSet::GetValid(){
    return Validation;
}
char* fitSet::GetTime(){
    return LoggedTime;
}

void fitSet::PerformedReps(int pReps){
    while (pReps < 0){
        cout << "\n\nERROR: Performed reps given is negative, try again: ";
        cin >> pReps;
    }
    if (PerformReps != -1){
        Validation = false;
    }
    PerformReps = pReps;
    if(PerformReps >= TargetReps){
        Completion = true;
    }
    // current date/time based on current system
    time_t now = time(0);
    // convert now to string form
    LoggedTime = ctime(&now);
}
float fitSet::PercentAchieved(){
    return ((float) PerformReps * 100) / (float) TargetReps;
}
float fitSet::Score(){
    return (float) Weight * this->PercentAchieved() / 10;
}