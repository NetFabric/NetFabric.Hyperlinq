using System;

namespace NetFabric.Hyperlinq
{
    public interface IEnumeratorRef<T>
    {
        ref T Current { get; }

        bool MoveNext();
    }
}
