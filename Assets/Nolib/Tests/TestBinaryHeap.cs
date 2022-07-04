using System;
using System.Collections.Generic;
using NUnit.Framework;
using Nolib.DataStructure;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tests
{
    public class TestBinaryHeap
    {
        private const int NumberOfRuns    = 100;
        private const int NumberOfSamples = 100;

        [Test]
        public void MaxHeap_Pop_ReturnHighestValue()
        {
            var results = Repeat(RunRandomMaxHeapPop, NumberOfRuns);

            Assert.IsTrue(results.TrueForAll(result => result == true));
        }
        
        [Test]
        public void MaxHeap_Push_GenerateValidHeap()
        {
            var results = Repeat(RunRandomMaxHeapPush, NumberOfRuns);

            Assert.IsTrue(results.TrueForAll(result => result == true));
        }
        
        [Test]
        public void MinHeap_Pop_ReturnLowestValue()
        {
            var results = Repeat(RunRandomMinHeapPop, NumberOfRuns);

            Assert.IsTrue(results.TrueForAll(result => result == true));
        }
        
        [Test]
        public void MinHeap_Push_GenerateValidHeap()
        {
            var results = Repeat(RunRandomMinHeapPush, NumberOfRuns);

            Assert.IsTrue(results.TrueForAll(result => result == true));
        }
        
        private int[] CreateRandomSamples(int numberOfSamples)
        {
            var samples = new int[numberOfSamples];

            for (int i = 0; i < numberOfSamples; i++)
                samples[i] = i;

            Shuffle(samples);

            return samples;
        }

        private void Shuffle(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var randomIndex = Random.Range(0, array.Length);
                var temp = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = temp;
            }
        }

        private List<bool> Repeat(Func<bool> action, int n)
        {
            var results = new List<bool>(n);

            for (int i = 0; i < n; i++)
                results.Add(RunRandomMaxHeapPush());

            return results;
        }

        private bool RunRandomMaxHeapPush()
        {
            var maxHeap = new MaxHeap<int>();
            var samples = CreateRandomSamples(Random.Range(0, NumberOfSamples));

            maxHeap.Push(samples);

            return IsValidMaxHeap(maxHeap);
        }

        private bool RunRandomMaxHeapPop()
        {
            var maxHeap = new MaxHeap<int>();
            var samples = CreateRandomSamples(Random.Range(0, NumberOfSamples));

            maxHeap.Push(samples);
            maxHeap.Pop();

            return IsValidMaxHeap(maxHeap);
        }

        private bool RunRandomMinHeapPush()
        {
            var minHeap = new MinHeap<int>();
            var samples = CreateRandomSamples(Random.Range(0, NumberOfSamples));

            minHeap.Push(samples);

            return IsValidMinHeap(minHeap);
        }

        private bool RunRandomMinHeapPop()
        {
            var minHeap = new MinHeap<int>();
            var samples = CreateRandomSamples(Random.Range(0, NumberOfSamples));

            minHeap.Push(samples);
            minHeap.Pop();

            return IsValidMinHeap(minHeap);
        }

        public void LogMaxHeap(MaxHeap<int> maxHeap)
        {
            Debug.Log("[" + string.Join(", ", maxHeap.Flatten()) + "]");
        }

        private bool IsValidMinHeap<T>(MinHeap<T> minHeap) where T : IComparable
        {
            var flattenMinHeap = minHeap.Flatten();

            for (int i = 0; i < flattenMinHeap.Length; i++)
            {
                var parentIndex     = (int) Math.Floor((i - 1) * 0.5f);
                var leftChildIndex  = 2 * i + 1;
                var rightChildIndex = 2 * i + 2;

                if (parentIndex > 0 && flattenMinHeap[i].CompareTo(flattenMinHeap[parentIndex]) < 0)
                    return false;

                if (leftChildIndex < flattenMinHeap.Length &&
                    flattenMinHeap[i].CompareTo(flattenMinHeap[leftChildIndex]) > 0)
                    return false;

                if (rightChildIndex < flattenMinHeap.Length &&
                    flattenMinHeap[i].CompareTo(flattenMinHeap[rightChildIndex]) > 0)
                    return false;
            }

            return true;
        }

        private bool IsValidMaxHeap<T>(MaxHeap<T> maxHeap) where T : IComparable
        {
            var flattenMaxHeap = maxHeap.Flatten();

            for (int i = 0; i < flattenMaxHeap.Length; i++)
            {
                var parentIndex     = (int) Math.Floor((i - 1) * 0.5f);
                var leftChildIndex  = 2 * i + 1;
                var rightChildIndex = 2 * i + 2;

                if (parentIndex > 0 && flattenMaxHeap[i].CompareTo(flattenMaxHeap[parentIndex]) > 0)
                    return false;

                if (leftChildIndex < flattenMaxHeap.Length &&
                    flattenMaxHeap[i].CompareTo(flattenMaxHeap[leftChildIndex]) < 0)
                    return false;

                if (rightChildIndex < flattenMaxHeap.Length &&
                    flattenMaxHeap[i].CompareTo(flattenMaxHeap[rightChildIndex]) < 0)
                    return false;
            }

            return true;
        }
    }
}