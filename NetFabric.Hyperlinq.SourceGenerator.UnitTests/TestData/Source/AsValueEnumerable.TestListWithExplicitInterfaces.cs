using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_ReadOnlyListWithExplicitInterfaces()
    {
        // test calling AsValueEnumerable() on an IValueEnumerable
        _ = new TestListWithExplicitInterfaces<TestValueType>().AsValueEnumerable();
    }
}





