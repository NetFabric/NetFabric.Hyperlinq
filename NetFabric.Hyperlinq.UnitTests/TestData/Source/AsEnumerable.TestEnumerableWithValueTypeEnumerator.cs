using System;
using System.Linq;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void Count_TestEnumerableWithValueTypeEnumerator()
    {
        _ = new TestEnumerableWithValueTypeEnumerator<TestValueType>()
            .AsValueEnumerable()
            .AsEnumerable();
    }
}
