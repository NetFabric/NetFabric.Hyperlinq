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
            var (array, length) = (skipCount == 0 && takeCount == source.Length)
                ? ToArrayWithLength(source, predicate)
                : IntervalToArrayWithLength(source, predicate, skipCount, takeCount);
            System.Array.Resize(ref array, length);
            return array;

            static (TSource[], int) ToArrayWithLength(TSource[] source, Predicate<TSource> predicate)
            {
                TSource[] array = null;
                var count = 0;
                for (var index = 0; index < source.Length; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                    {
                        if (count == 0)
                        {
                            const int DefaultCapacity = 4;

                            array = new TSource[DefaultCapacity];
                        }
                        else if (count == array.Length)
                        {
                            const int MaxArrayLength = 0x7FEFFFFF;

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

            static (TSource[], int) IntervalToArrayWithLength(TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
            {
                TSource[] array = null;
                var count = 0;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                    {
                        if (count == 0)
                        {
                            const int DefaultCapacity = 4;
                            
                            array = new TSource[DefaultCapacity];
                        }
                        else if (count == array.Length)
                        {
                            const int MaxArrayLength = 0x7FEFFFFF;

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
    }
}
