using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_Collection()
    {
        // test calling AsValueEnumerable() on an implementation of ICollection<>
        _ = new TestCollection<TestValueType>().AsValueEnumerable();
    }
}





