using System;

namespace Nolib.DataStructure
{
    public interface IHeap<T> where T : IComparable
    {
        int Count { get; }
        
        void Push(T element);
        void Push(T[] elements);
        void Clear();
        T Pop();
        T Peek();
        T[] Flatten();
    }
}