using System;
using System.Collections.Generic;

namespace PriorityQueueWay1
{
    class PriorityQueue<T>
    {
        private class PriorityNode
        {
            public int Priority { get; set; }
            public T Data { get; set; }
        }

        private IList<PriorityNode> elements = new List<PriorityNode>();
        int heapSize = -1;
        bool isMinPriorityQueue;

        public PriorityQueue(bool isMin = false)
        {
            isMinPriorityQueue = isMin;
        }

        public int Count { get { return elements.Count; } }

        private void MaxHeapify(int i)
        {
            int left = LeftChild(i);
            int right = RightChild(i);

            int highest = i;

            if (left <= heapSize && elements[highest].Priority < elements[left].Priority)
                highest = left;
            if (right <= heapSize && elements[highest].Priority < elements[right].Priority)
                highest = right;

            if (highest != i)
            {
                Swap(highest, i);
                MaxHeapify(highest);
            }
        }

        private void MinHeapify(int i)
        {
            int left = LeftChild(i);
            int right = RightChild(i);

            int lowest = i;

            if (left <= heapSize && elements[lowest].Priority > elements[left].Priority)
                lowest = left;
            if (right <= heapSize && elements[lowest].Priority > elements[right].Priority)
                lowest = right;

            if (lowest != i)
            {
                Swap(lowest, i);
                MinHeapify(lowest);
            }
        }

        private void Swap(int i, int j)
        {
            PriorityNode temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }

        private int LeftChild(int i)
        {
            return i * 2 + 1;
        }

        private int RightChild(int i)
        {
            return i * 2 + 2;
        }

        private void BuildMaxHeap()
        {
            int startIdx = (heapSize / 2) - 1;
            for (int i = startIdx; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        private void BuildMinHeap()
        {
            int startIdx = (heapSize / 2) - 1;
            for (int i = startIdx; i >= 0; i--)
            {
                MinHeapify(i);
            }
        }

        public void Enqueue(int priority, T data)
        {
            PriorityNode newNode = new PriorityNode() { Priority = priority, Data = data };
            elements.Add(newNode);
            heapSize++;
            if (isMinPriorityQueue)
            {
                BuildMinHeap();
            }
            else
            {
                BuildMaxHeap();
            }
        }

        public T Dequeue()
        {
            if (heapSize > -1)
            {
                var returnVal = elements[0].Data;
                elements[0] = elements[heapSize];
                elements.RemoveAt(heapSize);
                heapSize--;
                if (isMinPriorityQueue)
                    MinHeapify(0);
                else
                    MaxHeapify(0);
                return returnVal;
            }
            else
            {
                throw new Exception("Queue is Empty!!!");
            }
        }

        public bool Contains(T item)
        {
            foreach(PriorityNode p in elements)
            {
                if (ReferenceEquals(p.Data, item))
                {
                    return true;
                }
            }
            return false;
        }

        public T Peek()
        {
            if (heapSize > -1)
            {
                return elements[0].Data;
            }
            throw new Exception("Queue is Empty!!!");
        }

        public int GetHeighestPriority()
        {
            int highestPriority = int.MinValue;
            foreach (PriorityNode p in elements)
            {
                highestPriority = Math.Max(p.Priority, highestPriority);
            }
            return highestPriority;
        }
    }
}
