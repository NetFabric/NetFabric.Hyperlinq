# LinqBenchmarks

Benchmarks comparing the perfomance of [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/) against `for`/`foreach` loops and the following libraries: 

- [Cistern.ValueLinq](https://github.com/manofstick/Cistern.ValueLinq)
- [JM.LinqFaster](https://github.com/jackmott/LinqFaster)
- [LinqAF](https://github.com/kevin-montrose/LinqAF)
- [Streams](https://github.com/nessos/Streams)
- [LinqOptimizer](https://github.com/nessos/LinqOptimizer)
- [StructLinq](https://github.com/reegeek/StructLinq)
- [NetFabric.Hyperlinq](https://github.com/NetFabric/NetFabric.Hyperlinq)

## Results

### `Range()`

- [Range()](Results/Range.Range.md)
- [Range().Select()](Results/Range.RangeSelect.md)
- [Range().Select().ToArray()](Results/Range.RangeSelectToArray.md)
- [Range().Select().ToList()](Results/Range.RangeSelectToList.md)
- [Range().ToArray()](Results/Range.RangeToArray.md)
- [Range().ToList()](Results/Range.RangeToList.md)

### `IEnumerable<int>`

- [enumerable.Contains()](Results/Enumerable.Int32.EnumerableInt32Contains.md)
- [enumerable.Distinct()](Results/Enumerable.Int32.EnumerableInt32Distinct.md)
- [enumerable.Select()](Results/Enumerable.Int32.EnumerableInt32Select.md)
- [enumerable.Skip().Take().Select()](Results/Enumerable.Int32.EnumerableInt32SkipTakeSelect.md)
- [enumerable.Skip().Take().Where()](Results/Enumerable.Int32.EnumerableInt32SkipTakeWhere.md)
- [enumerable.Sum()](Results/Enumerable.Int32.EnumerableInt32Sum.md)
- [enumerable.Where()](Results/Enumerable.Int32.EnumerableInt32Where.md)
- [enumerable.Where().Count()](Results/Enumerable.Int32.EnumerableInt32WhereCount.md)
- [enumerable.Where().Select()](Results/Enumerable.Int32.EnumerableInt32WhereSelect.md)
- [enumerable.Where().Select().ToArray()](Results/Enumerable.Int32.EnumerableInt32WhereSelectToArray.md)
- [enumerable.Where().Select().ToList()](Results/Enumerable.Int32.EnumerableInt32WhereSelectToList.md)

### `IEnumerable<FatReferenceType>`
- [enumerable.Any()](Results/Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny.md)
- [enumerable.FirstOrDefault()](Results/Enumerable.FatReferenceType.EnumerableFatReferenceTypeFirstOrDefault.md)

### `int[]`

- [array.Contains()](Results/Array.Int32.ArrayInt32Contains.md)
- [array.Distinct()](Results/Array.Int32.ArrayInt32Distinct.md)
- [array.Select()](Results/Array.Int32.ArrayInt32Select.md)
- [array.Select().ToList()](Results/Array.Int32.ArrayInt32SelectToList.md)
- [array.Skip().Take().Select()](Results/Array.Int32.ArrayInt32SkipTakeSelect.md)
- [array.Skip().Take().Where()](Results/Array.Int32.ArrayInt32SkipTakeWhere.md)
- [array.Sum()](Results/Array.Int32.ArrayInt32Sum.md)
- [array.Where()](Results/Array.Int32.ArrayInt32Where.md)
- [array.Where().Count()](Results/Array.Int32.ArrayInt32WhereCount.md)
- [array.Where().Select()](Results/Array.Int32.ArrayInt32WhereSelect.md)
- [array.Where().Select().ToArray()](Results/Array.Int32.ArrayInt32WhereSelectToArray.md)
- [array.Where().Select().ToList()](Results/Array.Int32.ArrayInt32WhereSelectToList.md)

### `FatValueType[]`

- [array.Contains()](Results/Array.ValueType.ArrayValueTypeContains.md)
- [array.Distinct()](Results/Array.ValueType.ArrayValueTypeDistinct.md)
- [array.Select()](Results/Array.ValueType.ArrayValueTypeSelect.md)
- [array.Select().Sum()](Results/Array.ValueType.ArrayValueTypeSelectSum.md)
- [array.Skip().Take().Select()](Results/Array.ValueType.ArrayValueTypeSkipTakeSelect.md)
- [array.Skip().Take().Where()](Results/Array.ValueType.ArrayValueTypeSkipTakeWhere.md)
- [array.Where()](Results/Array.ValueType.ArrayValueTypeWhere.md)
- [array.Where().Count()](Results/Array.ValueType.ArrayValueTypeWhereCount.md)
- [array.Where().Select()](Results/Array.ValueType.ArrayValueTypeWhereSelect.md)
- [array.Where().Select().ToArray()](Results/Array.ValueType.ArrayValueTypeWhereSelectToArray.md)
- [array.Where().Select().ToList()](Results/Array.ValueType.ArrayValueTypeWhereSelectToList.md)

### `List<int>`

- [list.Contains()](Results/List.Int32.ListInt32Contains.md)
- [list.Distinct()](Results/List.Int32.ListInt32Distinct.md)
- [list.Select()](Results/List.Int32.ListInt32Select.md)
- [list.Select().ToList()](Results/List.Int32.ListInt32SelectToList.md)
- [list.Skip().Take().Select()](Results/List.Int32.ListInt32SkipTakeSelect.md)
- [list.Skip().Take().Where()](Results/List.Int32.ListInt32SkipTakeWhere.md)
- [list.Sum()](Results/List.Int32.ListInt32Sum.md)
- [list.Where()](Results/List.Int32.ListInt32Where.md)
- [list.Where().Select()](Results/List.Int32.ListInt32WhereSelect.md)
- [list.Where().Select().ToArray()](Results/List.Int32.ListInt32WhereSelectToArray.md)
- [list.Where().Select().ToList()](Results/List.Int32.ListInt32WhereSelectToList.md)

### `List<FatValueType>`

- [list.Contains()](Results/List.ValueType.ListValueTypeContains.md)
- [list.Distinct()](Results/List.ValueType.ListValueTypeDistinct.md)
- [list.Select()](Results/List.ValueType.ListValueTypeSelect.md)
- [list.Select().Sum()](Results/List.ValueType.ListValueTypeSelectSum.md)
- [list.Skip().Take().Select()](Results/List.ValueType.ListValueTypeSkipTakeSelect.md)
- [list.Skip().Take().Where()](Results/List.ValueType.ListValueTypeSkipTakeWhere.md)
- [list.Where()](Results/List.ValueType.ListValueTypeWhere.md)
- [list.Where().Select()](Results/List.ValueType.ListValueTypeWhereSelect.md)
- [list.Where().Select().ToArray()](Results/List.ValueType.ListValueTypeWhereSelectToArray.md)
- [list.Where().Select().ToList()](Results/List.ValueType.ListValueTypeWhereSelectToList.md)

### `ImmutableArray<int>`

- [array.Contains()](Results/ImmutableArray.Int32.ImmutableArrayInt32Contains.md)
- [array.Select()](Results/ImmutableArray.Int32.ImmutableArrayInt32Select.md)
- [array.Skip().Take().Select()](Results/ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect.md)
- [array.Sum()](Results/ImmutableArray.Int32.ImmutableArrayInt32Sum.md)
- [array.Where()](Results/ImmutableArray.Int32.ImmutableArrayInt32Where.md)

