using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this TSource[] source)
            => (TSource[])source.Clone();

        [Pure]
        static TSource[] ToArray<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            var array = new TSource[takeCount];
            if (takeCount != 0)
                System.Array.Copy(source, skipCount, array, 0, takeCount);
            return array;
        }

        // Based on https://github.com/dotnet/runtime/blob/4359ebfc9943608b34f411366b1e544ac45702b7/src/libraries/Common/src/System/Collections/Generic/EnumerableHelpers.cs
        [Pure]
        static TSource[] ToArray<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var (array, length) = ToArrayWithLength(source, predicate, skipCount, takeCount);
            System.Array.Resize(ref array, length);
            return array;

            static (TSource[], int) ToArrayWithLength(TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
            {
                int count;

                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                    {
                        const int DefaultCapacity = 4;
                        var array = new TSource[DefaultCapacity];
                        array[0] = item;
                        count = 1;

                        for (index++; index < end; index++)
                        {
                            item = source[index];
                            if (predicate(item))
                            {
                                if (count == array.Length)
                                {
                                    // MaxArrayLength is defined in Array.MaxArrayLength and in gchelpers in CoreCLR.
                                    // It represents the maximum number of elements that can be in an array where
                                    // the size of the element is greater than one byte; a separate, slightly larger constant,
                                    // is used when the size of the element is one.
                                    const int MaxArrayLength = 0x7FEFFFFF;

                                    // This is the same growth logic as in List<T>:
                                    // If the array is currently empty, we make it a default size.  Otherwise, we attempt to 
                                    // double the size of the array.  Doubling will overflow once the size of the array reaches
                                    // 2^30, since doubling to 2^31 is 1 larger than Int32.MaxValue.  In that case, we instead 
                                    // constrain the length to be MaxArrayLength (this overflow check works because of the 
                                    // cast to uint).  Because a slightly larger constant is used when T is one byte in size, we 
                                    // could then end up in a situation where arr.Length is MaxArrayLength or slightly larger, such 
                                    // that we constrain newLength to be MaxArrayLength but the needed number of elements is actually 
                                    // larger than that.  For that case, we then ensure that the newLength is large enough to hold 
                                    // the desired capacity.  This does mean that in the very rare case where we've grown to such a 
                                    // large size, each new element added after MaxArrayLength will end up doing a resize.
                                    var newLength = count << 1;
                                    if ((uint)newLength > MaxArrayLength)
                                        newLength = MaxArrayLength <= count ? count + 1 : MaxArrayLength;

                                    System.Array.Resize(ref array, newLength);
                                }

                                array[count] = item;
                                count++;
                            }
                        }

                        return (array, count);
                    }
                }

                return default; // it's empty
            }
        }
    }
}
