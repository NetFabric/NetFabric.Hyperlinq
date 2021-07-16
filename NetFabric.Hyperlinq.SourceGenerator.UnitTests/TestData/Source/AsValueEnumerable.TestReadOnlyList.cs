using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_ReadOnlyList()
    {
        // test calling AsValueEnumerable() on an IValueEnumerable
        _ = new TestReadOnlyList<TestValueType>().AsValueEnumerable();
    }
}





