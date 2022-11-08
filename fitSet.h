//
// Created by Bud Robinson on 10/10/2022.
//

#include <iostream>
#include <stdio.h>
#include <ctime>

#ifndef FITSET_H
#define FITSET_H

using namespace std;

class fitSet {
public:
    fitSet();
    fitSet(string name, string classification, int weight, int tReps);
    ~fitSet();

    string GetName();
    string GetClass();
    int GetWeight();
    int GetTReps();
    int GetPReps();
    bool GetComplete();
    bool GetValid();
    char* GetTime();

    void PerformedReps(int pReps);
    float PercentAchieved();
    float Score();

private:
    string Name;
    string Classification;
    int Weight;
    int TargetReps;
    int PerformReps;
    bool Completion = false;
    bool Validation = true;
    char* LoggedTime;
};


#endif //CLIONPROJECTS_FITSET_H
