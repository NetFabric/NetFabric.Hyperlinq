using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_ReadOnlyCollection()
    {
        // test calling AsValueEnumerable() on an IValueEnumerable
        _ = new TestReadOnlyCollection<TestValueType>().AsValueEnumerable();
    }
}





