using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public static class TestEnumerable
    {
        public static IEnumerable<int> ReferenceType(int count)
        {
            for (var value = 0; value < count; value++)
                yield return value;            
        }

        public static Enumerable ValueType(int count) 
            => new Enumerable(count);

        public class Enumerable : IEnumerable<int>
        {
            readonly int count;

            public Enumerable(int count) 
                => this.count = count;

            public Enumerator GetEnumerator() 
                => new Enumerator(count);
            IEnumerator<int> IEnumerable<int>.GetEnumerator() 
                => new Enumerator(count);
            IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator(count);

            public struct Enumerator : IEnumerator<int>
            {
                readonly int count;

                public Enumerator(int count)
                {
                    this.count = count;
                    Current = -1;
                }

                public int Current { get; private set; }
                object IEnumerator.Current => Current;

                public bool MoveNext() => ++Current < count;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}