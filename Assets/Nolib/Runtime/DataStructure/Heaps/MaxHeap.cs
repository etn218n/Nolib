using System;

namespace Nolib.DataStructure
{
    public class MaxHeap<T> : BinaryHeap<T> where T : IComparable
    {
        public MaxHeap(int reservedCapacity = 10) : base(reservedCapacity)
        {
        }

        protected override void SiftUp(int elementIndex)
        {
            while (true)
            {
                var parentIndex = ParentIndexOf(elementIndex);

                if (parentIndex == -1 || elements[elementIndex].CompareTo(elements[parentIndex]) < 0)
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

                var largestElementIndex = elementIndex;

                if (rightChildIndex != -1 && elements[rightChildIndex].CompareTo(elements[largestElementIndex]) > 0) 
                    largestElementIndex = rightChildIndex;

                if (leftChildIndex != -1 && elements[leftChildIndex].CompareTo(elements[largestElementIndex]) > 0) 
                    largestElementIndex = leftChildIndex;

                if (largestElementIndex == elementIndex) 
                    return;

                Swap(largestElementIndex, elementIndex);
                elementIndex = largestElementIndex;
            }
        }
    }
}
