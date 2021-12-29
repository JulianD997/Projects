#include "node1.h"
#include "check_lists.h"
#include <iostream>

using namespace main_savitch_5;
using namespace std;


void list_print( node * head_ptr){
		for (node* i = head_ptr ; i != NULL; i = i->link())
		{
        cout << i->data() << ", ";
    	}
       cout << endl;
}




int main() {
    node* list1_head = NULL;
	list_head_insert(list1_head, 12.9);
    list_insert(list1_head, 23.5);
    list_insert(list1_head, 45.6);
	list_insert(list1_head, 67.7);
	list_insert(list1_head, 89.8);
	list_print(list1_head);
    check_list1(list1_head);
    cout << endl;
 
    node* list2_head = NULL;
    node* list2_tail = NULL;
    
    list_head_insert(list2_head,23.5);
    list_insert(list2_head,12.9);
	list_insert(list2_head,89.8);
    list_insert(list2_head,-123.5);
    list_insert(list2_head,67.7);
    list_insert(list2_head,45.6);
    list_print(list2_head);
    check_list2(list2_head);
    cout << endl;
    
    node* list3_head = NULL;
    node* list3_tail = NULL;
    
    list_copy(list1_head, list3_head, list3_tail);
    list_print(list1_head);
    check_list1(list3_head);
    cout <<"The data at the Tail of the list is: " << list3_tail->data() <<endl;
    cout << endl;
    
    list_head_remove(list2_head);
    list_print(list2_head);
    check_list2B(list2_head);
    cout << endl;
    
    list_remove(list_locate(list2_head,2));
    list_print(list2_head);
    check_list2C(list2_head);
}
