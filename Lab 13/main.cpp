#include "priority_queue.h"
#include <iostream>
#include <stdlib.h>    
#include <time.h>       

/* 
This was coded by Julian Duran.
December 10th, 2019
CS3305L/02 
*/

using namespace std;
int main(int argc, char** argv)

{
       priority_queue<int> q;
       cout << "Random numbers: ";
       for (int i = 0; i < 10; i++)
       {
              int randomNum = rand() % 100 + 1;
              cout << randomNum << " ";
              q.push(randomNum);
       }


       cout << endl;
       for (int i = 0; i < 10; i++)
       {
             cout << "Entery: " << q.top() << "  Order : " << q.orderOfTop() << endl;
             q.pop();
       }
       cout << "it worked" << endl;

       return 0;

}
