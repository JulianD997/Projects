#include <string>
#include "bst.h"
using namespace std;

/*This lab was coded by Julian Duran.
CS 3305L/02
December 1st, 2019
Professor Long*/

int rnd() {
    return rand() % 10000;
}

int main() {

    
    binary_search_tree<int> bst3;
    for(int i = 0; i < 50; i++ ) {
        bst3.insert(rnd());
    }
    cout << bst3 << endl;
    cout << "balanced? " << bst3.is_balanced() <<  endl << endl;

}
