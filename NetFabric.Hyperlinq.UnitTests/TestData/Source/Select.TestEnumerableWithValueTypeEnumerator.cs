using System;
using System.Linq;
using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void Select_TestEnumerableWithValueTypeEnumerator()
    {
        _ = new TestEnumerableWithValueTypeEnumerator<TestValueType>()
            .AsValueEnumerable()
            .Select(_ => new TestReferenceType());
    }
}
