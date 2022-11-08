//
// Created by budro on 10/17/2022.
//
/*
 * Thought Process: Linked list makes most sense, easier to get stuff out of it. Had trouble tracking memory leaks,
 * put off the assignment way to long. My bad.
 *
 * Invariants: head always starts as nullptr, node always starts empty
 */
#ifndef HW2_SESSIONLOG_H
#define HW2_SESSIONLOG_H

#include <iostream>
#include <stdio.h>
#include <list>
#include "fitSet.h"

using namespace std;
const int startSize = 2;

class sessionLog {
private:
    fitSet** ptr;
    int size;
    int numElement;
    bool completed;

public:
    sessionLog();
    sessionLog(const sessionLog& other);
    ~sessionLog();

    void addSet(fitSet newSet);
    void buildSession(sessionLog mergeThis);
    void removeSet(fitSet set);
    void justDoIt();
    fitSet* shareSession();
    int giveSize();
};


#endif //HW2_SESSIONLOG_H
