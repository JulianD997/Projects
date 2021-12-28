#ifndef _PRIORITY_QUEUE_H
#define _PRIORITY_QUEUE_H
#include "heap.h"

using namespace std;

template <typename T>
class priority_queue
{   
public:
      priority_queue();
      void pop();
      void push(const T& item);
      bool empty() const;
      unsigned int size() const;
      T top() const;
      int orderOfTop();

private:
      heap<T> h;
};

template <typename T>
priority_queue<T>::priority_queue() : h()
{

}

template <typename T>
void priority_queue<T>::pop()
{
      assert(!empty());// priority_queue is not emtpy
      h.remove();
}

template <typename T>
void priority_queue<T>::push(const T& item)
{
      if (h.CAPACITY == h.size())
      {
            cout << "Queue full!" << endl;
            return;
      }
      h.insert(item);
}

template <typename T>
bool priority_queue<T>::empty() const
{
      return h.is_empty();
}

template <typename T>
unsigned int priority_queue<T>::size() const
{
      return h.size();
}

template <typename T>
T priority_queue<T>::top() const
{
      return h.max();
}

template <typename T>
int priority_queue<T>::orderOfTop()
{
      return h.orderOfMax();
}

#endif // _PRIORITY_QUEUE_H

