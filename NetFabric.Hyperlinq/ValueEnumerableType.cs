using System;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    record ValueEnumerableType(string Name, string EnumeratorType, string ItemType, bool IsCollection, bool IsList);
}
