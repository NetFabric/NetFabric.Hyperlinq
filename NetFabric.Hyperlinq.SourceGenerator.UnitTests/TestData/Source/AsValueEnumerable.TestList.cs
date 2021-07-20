using NetFabric.Hyperlinq;

partial class TestsSource
{
    static void AsValueEnumerable_List()
    {
        // test calling AsValueEnumerable() on an implementation of IList<>
        _ = new TestList<TestValueType>().AsValueEnumerable();
    }
}





