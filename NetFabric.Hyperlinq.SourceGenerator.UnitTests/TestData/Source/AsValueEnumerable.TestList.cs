using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_List()
    {
        // test calling AsValueEnumerable() on an ICollection
        _ = new TestList<TestValueType>().AsValueEnumerable();
    }
}





