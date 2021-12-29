#include "sequence3.h"
#include <cassert>    
#include <cstdlib>

using namespace std;

namespace main_savitch_5
{

//The sequence has been initialized as an empty sequence
sequence()
{
	head_ptr = NULL;
	tail_ptr = NULL;
	cursor = NULL;
	precursor = NULL;
	many_nodes = 0;
}

//Copy Constructior
sequence(const sequence& source)
{
}

// Destructior
~sequence( )
{
}

// The first item on the sequence becomes the current item
// (but if the sequence is empty, then there is no current item).
void start( )
{
}

// If the current item was already the last item in the
// sequence, then there is no longer any current item. Otherwise, the new
// current item is the item immediately after the original current item.
void advance( )
{
}

// A new copy of entry has been inserted in the sequence
// before the current item. If there was no current item, then the new entry 
// has been inserted at the front of the sequence. In either case, the newly
// inserted item is now the current item of the sequence.
void insert(const value_type& entry)
{
}

// A new copy of entry has been inserted in the sequence after
// the current item. If there was no current item, then the new entry has 
// been attached to the end of the sequence. In either case, the newly
// inserted item is now the current item of the sequence.
void attach(const value_type& entry)
{
}


void operator =(const sequence& source)
{
}

// The current item has been removed from the sequence, and
// the item after this (if there is one) is now the new current item.
void remove_current( )
{
}

//Constant Member Functions

// The return value is the number of items in the sequence.
size_type size( ) const { return many_nodes; }
{
}

// A true return value indicates that there is a valid
// "current" item that may be retrieved by activating the current
// member function (listed below). A false return value indicates that
// there is no valid current item.
bool is_item( ) const { return (cursor != NULL); }
{
}
// The item returned is the current item in the sequence.
value_type current( ) const;
{
}

}
