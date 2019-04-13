using System.Diagnostics;

namespace NetFabric.Hyperlinq.UnitTests
{
    // [DebuggerNonUserCode]
    static partial class AssertionExtensions
    {
        public static ValueEnumerablerAssertions<IValueEnumerable<TSource, TEnumerator>, TEnumerator, TSource> Should<TEnumerator, TSource>(this IValueEnumerable<TSource, TEnumerator> @this)
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            return new ValueEnumerablerAssertions<IValueEnumerable<TSource, TEnumerator>, TEnumerator, TSource>(@this);
        }    

        public static ValueReadOnlyCollectionAssertions<IValueReadOnlyCollection<TSource, TEnumerator>, TEnumerator, TSource> Should<TEnumerator, TSource>(this IValueReadOnlyCollection<TSource, TEnumerator> @this)
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            return new ValueReadOnlyCollectionAssertions<IValueReadOnlyCollection<TSource, TEnumerator>, TEnumerator, TSource>(@this);
        }  

        public static ValueReadOnlyListAssertions<IValueReadOnlyList<TSource, TEnumerator>, TEnumerator, TSource> Should<TEnumerator, TSource>(this IValueReadOnlyList<TSource, TEnumerator> @this)
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            return new ValueReadOnlyListAssertions<IValueReadOnlyList<TSource, TEnumerator>, TEnumerator, TSource>(@this);
        }    
    }
}