#include "set.h"

//This was coded by Julian Duran on September 17th, 2019
//CS3305L section 02
//Professor Long 
//Lab 4

set::set(size_type initial_capacity)
{
    used = 0;
    capacity = initial_capacity;
    data = new value_type[capacity];
}

set::~set()
{
    data = NULL;
}

set::set(const set &s)
{
    used = s.used;
    capacity = s.capacity;
    data = s.data;
}

set& set::operator=(const set &s)
{
	used = s.used;
    data = new value_type[capacity];
    for (int i = 0; i < used; i++)
    {
        data[i] = s.data[i];
    }
}

bool set::erase(const value_type &target)
{
    int pos = -1;
    for (int i = 0; i < used; i++)
    {
        if (data[i] == target){
            pos = i;
            break;
        }
    }

    if(pos==-1)
        return false;

    for(int i=pos; i<used-1; i++)
        data[i] = data[i+1];

    used--;
    return true;
}


bool set::insert(const value_type &entry)
{
    if (used >= capacity)
        reserve(2 * capacity);

    for (int i = 0; i < used; i++)
    {
        if (data[i] == entry)
            return false;
    }

    data[used] = entry;
    used++;
    return true;

}

  void set::operator+=(const set& addend)
{
      for(int i=0; i<addend.used; i++)
	  {
          if(!contains(addend.data[i]))
            insert(addend.data[i]);
      }

  }

set::size_type set::size() const
{
    return used;
}

bool set::contains(const value_type &target) const
{
    for (int i = 0; i < used; i++)
    {
        if (data[i] == target)
            return true;
    }
    return false;
}

std::ostream &operator<<(std::ostream &output, const set &s)
{
    for (int i = 0; i < s.used; i++)
    {
        output << s.data[i];
        if (i != s.used - 1)
            output << ", ";
    }
    return output;
}

void set::reserve(size_type new_capacity)
{
    value_type *temp = new value_type[new_capacity];
    for (int i = 0; i < used; i++)
        temp[i] = data[i];
        
    delete data;
    data = temp;
}


