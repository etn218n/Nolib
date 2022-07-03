using System;
using System.Collections.Generic;

namespace Nolib.DataStructure
{
    public abstract class BinaryHeap<T> : IHeap<T> where T : IComparable
    {
        protected List<T> elements;

        public int Count => elements.Count;

        protected BinaryHeap(int reservedCapacity = 10)
        {
            elements = new List<T>(reservedCapacity);
        }

        public void Push(T element)
        {
            elements.Add(element);
            
            SiftUp(elements.Count - 1);
        }
        
        public void Push(T[] elementArray)
        {
            foreach (var element in elementArray)
                Push(element);
        }

        public void Clear()
        {
            elements.Clear();
        }

        public T Pop()
        {
            if (elements.Count == 0)
                throw new IndexOutOfRangeException();

            var rootElement = elements[0];
            var lastElementIndex = elements.Count - 1;

            elements[0] = elements[lastElementIndex];
            elements.RemoveAt(lastElementIndex);
            
            SiftDown(0);

            return rootElement;
        }

        public T Peek()
        {
            if (elements.Count == 0)
                throw new IndexOutOfRangeException();
            
            return elements[0];
        }
        
        public T[] Flatten()
        {
            var clones = new T[elements.Count];
            
            elements.CopyTo(clones);

            return clones;
        }

        protected int ParentIndexOf(int elementIndex)
        {
            if (elementIndex <= 0 || elementIndex >= elements.Count)
                return -1;

            return (int) Math.Floor((elementIndex - 1) * 0.5f);
        }
        
        protected int LeftChildIndexOf(int elementIndex)
        {
            if (elementIndex < 0 || elementIndex >= elements.Count)
                return -1;

            var leftChildIndex = elementIndex * 2 + 1;

            if (leftChildIndex >= elements.Count)
                return -1;
            
            return leftChildIndex;
        }
        
        protected int RightChildIndexOf(int elementIndex)
        {
            if (elementIndex < 0 || elementIndex >= elements.Count)
                return -1;
            
            var rightChildIndex = elementIndex * 2 + 2;

            if (rightChildIndex >= elements.Count)
                return -1;
            
            return rightChildIndex;
        }

        protected void Swap(int indexA, int indexB)
        {
            var temp = elements[indexA];
            elements[indexA] = elements[indexB];
            elements[indexB] = temp;
        }
        
        protected abstract void SiftUp(int elementIndex);
        protected abstract void SiftDown(int elementIndex);
    }
}