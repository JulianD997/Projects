#include "bintree.h"
#include "build_tree.h"
#include <iostream>
using namespace std;

template <class T>
void printItem(T item)
{
    cout<<item<<" ";
}

//This was coded by Julian Duran.
//December 13th, 2019
//CS3305L/02

int main() {
    binary_tree_node<int> *s1 = sample1();
//    print(s1, 0);
//    cout<<endl;    
	
    cout << "Depth of S1:" << depth(s1) << endl;
    cout << "Max of S1: " <<   max_val(s1) << endl;
	cout << "Sum of S1: " << tree_sum(s1) << endl;
	cout << "Average of S1: " << tree_average(s1) << endl;
	cout << "S1 balanced? " << tree_is_balanced(s1) << endl;
    
    binary_tree_node<int> *s2 = sample2();
 //   print(s2, 0);
    cout<<endl;
    
    cout << "Depth of S2:" << depth(s2) << endl;
    cout << "Max of S2: " <<   max_val(s2) << endl;
	cout << "Sum of S2: " << tree_sum(s2) << endl;
	cout << "Average of S2: " << tree_average(s2) << endl;
	cout << "S2 balanced? " << tree_is_balanced(s2) << endl;
    
    binary_tree_node<double> *s3 =sample3();
    cout<<endl;
    
    cout << "Depth of S3:" << depth(s3) << endl;
    cout << "Max of S3: " <<   max_val(s3) << endl;
	cout << "Sum of S3: " << tree_sum(s3) << endl;
	cout << "Average of S3: " << tree_average(s3) << endl;
	cout << "S3 balanced? " << tree_is_balanced(s3) << endl;
    
    binary_tree_node<double> *s4 =sample4();
    cout<<endl;

    cout << "Depth of S4:" << depth(s4) << endl;
    cout << "Max of S4: " <<   max_val(s4) << endl;
    cout << "Sum of S4: " << tree_sum(s4) << endl;
	cout << "Average of S4: " << tree_average(s4) << endl;
	cout << "S4 balanced? " << tree_is_balanced(s4) << endl;

    binary_tree_node<string> *s5 = sample5();
    cout<<endl;

//    cout << "Depth of S5:" << depth(s5) << endl;
 //   cout << "Max of S5: " <<   max_val(s5) << endl;
//    cout << "Sum of S5: " << tree_sum(s5) << endl;
//	cout << "Average of S5: " << tree_average(s5) << endl;
	cout << "S5 balanced? " << tree_is_balanced(s5) << endl;
	
     
    binary_tree_node<double> *s6 =sample_bal1();
    cout<<endl;
    
    cout << "Depth of S6:" << depth(s6) << endl;
    cout << "Max of S6: " <<   max_val(s6) << endl;
    cout << "Sum of S6: " << tree_sum(s6) << endl;
	cout << "Average of S6: " << tree_average(s6) << endl;
	cout << "S6 balanced? " << tree_is_balanced(s6) << endl;
    
    binary_tree_node<double> *s7 =sample_bal2();
    cout<<endl;
    
    cout << "Depth of S7:" << depth(s7) << endl;
    cout << "Max of S7: " <<   max_val(s7) << endl;
    cout << "Sum of S7: " << tree_sum(s7) << endl;
	cout << "Average of S7: " << tree_average(s7) << endl;
	cout << "S7 balanced? " << tree_is_balanced(s7) << endl;

}
