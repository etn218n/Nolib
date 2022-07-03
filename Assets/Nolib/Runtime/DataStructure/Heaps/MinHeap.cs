using System;

namespace Nolib.DataStructure
{
    public class MinHeap<T> : BinaryHeap<T> where T : IComparable
    {
        public MinHeap(int reservedCapacity = 10) : base(reservedCapacity)
        {
        }

        protected override void SiftUp(int elementIndex)
        {
            while (true)
            {
                var parentIndex = ParentIndexOf(elementIndex);

                if (parentIndex == -1 || elements[elementIndex].CompareTo(elements[parentIndex]) > 0)
                    return;

                Swap(elementIndex, parentIndex);
                elementIndex = parentIndex;
            }
        }

        protected override void SiftDown(int elementIndex)
        {
            while (true)
            {
                var leftChildIndex  = LeftChildIndexOf(elementIndex);
                var rightChildIndex = RightChildIndexOf(elementIndex);

                var smallestElementIndex = elementIndex;

                if (rightChildIndex != -1 && elements[rightChildIndex].CompareTo(elements[smallestElementIndex]) < 0) 
                    smallestElementIndex = rightChildIndex;

                if (leftChildIndex != -1 && elements[leftChildIndex].CompareTo(elements[smallestElementIndex]) < 0) 
                    smallestElementIndex = leftChildIndex;

                if (smallestElementIndex == elementIndex)
                    return;

                Swap(smallestElementIndex, elementIndex);
                elementIndex = smallestElementIndex;
            }
        }
    }
}
