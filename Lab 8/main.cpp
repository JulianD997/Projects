#include <cstdlib>
#include <iostream>
#include <set>
#include <algorithm>
#include "node2.h"
#include "bag5.h"

using namespace std;



// PROTOTYPE for a function used by this demonstration program
template <class Item, class SizeType, class MessageType>
void get_items(bag<Item>& collection, SizeType n, MessageType description)
// Postcondition: The string description has been written as a prompt to the
// screen. Then n items have been read from cin and added to the collection.
// Library facilities used: iostream, bag4.h
{
    Item user_input; // An item typed by the program's user
    SizeType i;

    cout << "Please type " << n << " " << description;
    cout << ", separated by spaces.\n";
    cout << "Press the <return> key after the final entry:\n";
    for (i = 1; i <= n; ++i)
    {
        cin >> user_input;
        collection.insert(user_input);
    }
    cout << endl;
}

int main()
{
	int x;
	int y;
	//Print Function Test 1
	bag <int> numbers;
	numbers.insert(9);
	numbers.insert(8);
	numbers.insert(7);
	numbers.insert(6);
	numbers.insert(5);
	numbers.insert(4);
	numbers.insert(3);
	numbers.insert(2);
	numbers.insert(1);
	cout << "Range from 2 to 6:" << endl;
	numbers.print_value_range(2,6);
	cout << "Range from 2 to 70:" << endl;
	numbers.print_value_range(2,70);
	cout << "Range from 3 to 1:" << endl;
	numbers.print_value_range(3,1);
	cout << "Range from 10 to 6:" << endl;
	numbers.print_value_range(10,6);
	cout << endl;


	//Test 2
	
	bag <int> numbers2;
	numbers2.insert(9);
    numbers2.insert(9);
    numbers2.insert(8);
    numbers2.insert(7);
    numbers2.insert(5);
    numbers2.insert(6);
    numbers2.insert(5);
    numbers2.insert(3);
    numbers2.insert(4);
    numbers2.insert(3);
    numbers2.insert(3);
    numbers2.insert(2);
    numbers2.insert(1);
    cout << "Before removing all repetitions:" << endl;
    numbers2.print_value_range(1,10);
    cout << "After removing all repetitions:" << endl;
	numbers2.remove_repetitions();
	numbers2.print_value_range(1,10);
	
	return EXIT_SUCCESS;
}
