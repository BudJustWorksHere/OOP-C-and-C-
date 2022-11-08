//
// Created by budro on 10/17/2022.
//

#include "sessionLog.h"

using namespace std;

//Empty constructor (not needed since running with linked list)
sessionLog::sessionLog() {
    size = startSize;
    numElement = 0;
    ptr = new fitSet[size];
    completed = false;
    cout << "CONSTRUCTOR";
}
//Didn't have time for the copy constructor
sessionLog::sessionLog(const sessionLog& other){
    size = other.size;
    numElement = other.numElement;
    ptr = new fitSet [size];
    for(int i = 0; i < size; ++i)
    {
        ptr[i] = other.ptr[i];
    }
}
//Deletes the linked list starting from head
//PRE: linked list
//POST: no more list
sessionLog::~sessionLog(){
    delete [] ptr;
}

//Adds in newSet (fitSet object) into new Node, adds that to end of linked list
//PRE: Input a fitSet object
//POST: fitSet object contained in new Node
void sessionLog::addSet(fitSet newSet){
    if(completed){
        cout << "ERROR: Cannot add set after completion\n";
        return;
    }
    if(numElement == size){
        fitSet* ptrTemp = new fitSet[size*2];
        for(int i = 0; i < size; ++i){
            ptrTemp[i] = ptr[i];
        }
        delete [] ptr;
        size = size*2;
    }
    for(int i = 0; i < size; ++i){
        if(ptr[i] == nullptr){
            ptr[i] = newSet;
            numElement++;
            return;
        }
    }
}
//Supposed to add one sessionLog head onto the back of another linked list, never tested
//PRE: two logs with one that has contents
//POST: One combined log of the two linked lists
void sessionLog::buildSession(sessionLog mergeThis){
    tempPtr = mergeThis.shareSession();
    int i = 0;
    while(tempPtr[i] != nullptr){
        addSet(tempPtr[i]);
        i++;
    }
}
//Removes a set based off of weight, could be everything in fitSet, but no time :(
//PRE: A fitSet Object
//POST: A linked lists missing the inputted object.
void sessionLog::removeSet(fitSet set){
    if(completed){
        cout << "ERROR: Cannot remove set after completion\n";
        return;
    }
    for(int i = 0; i < size; ++i){
        if(ptr[i].GetName() == set.GetName() && ptr[i].GetTReps() == set.GetTReps()){
            ptr[i] = nullptr;
            numElement--;
        }
    }
}
//Prompts user about fitSet data and asks for their reps (feels like i did this wrong)
//PRE: a linked list with fitset data
//POST: the completion of the log and all of its exercvises
void sessionLog::justDoIt(){
    if(completed){
        cout << "ERROR: Session Completed\n";
        return;
    }
    fitSet set;
    int reps;
    for(int i = 0; i < numElement; ++i){
        set = ptr[i];
        cout << "Name: " << set.GetName();
        cout << "\nClass: " << set.GetClass();
        cout << "\nWeight: " << set.GetWeight();
        cout << "\nTarget Reps: " << set.GetTReps();
        cout << "\nPerformed Reps: ";
        cin >> reps;
        set.PerformedReps(reps);
    }
    completed = true;
}
//outputs the head of the linked list to print out data stored
//PRE: A linked list existing
//POST: Gives caller the linked list head
fitSet* sessionLog::shareSession(){
    return ptr;
}

int sessionLog::giveSize(){
    return size;
}