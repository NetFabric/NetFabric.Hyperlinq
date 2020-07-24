# LinqBenchmarks

Benchmarks comparing the perfomance of [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/) against handwritten code and the following libraries: 

- [JM.LinqFaster](https://github.com/jackmott/LinqFaster)
- [StructLinq](https://github.com/reegeek/StructLinq)
- [NetFabric.Hyperlinq](https://github.com/NetFabric/NetFabric.Hyperlinq)

## Results

### `Range()`

- [Range()](Results/Range.md)
- [Range().Select()](Results/RangeSelect.md)
- [Range().Select().ToArray()](Results/RangeSelectToArray.md)
- [Range().Select().ToList()](Results/RangeSelectToList.md)
- [Range().ToArray()](Results/RangeToArray.md)
- [Range().ToList()](Results/RangeToList.md)

### `IEnumerable<int>`

- [enumerable.Distinct()](Results/EnumerableInt32Distinct.md)
- [enumerable.Select()](Results/EnumerableInt32Select.md)
- [enumerable.Skip().Take().Select()](Results/EnumerableInt32SkipTakeSelect.md)
- [enumerable.Skip().Take().Where()](Results/EnumerableInt32SkipTakeWhere.md)
- [enumerable.Where()](Results/EnumerableInt32Where.md)
- [enumerable.Where().Count()](Results/EnumerableInt32WhereCount.md)
- [enumerable.Where().Select()](Results/EnumerableInt32WhereSelect.md)
- [enumerable.Where().Select().ToArray()](Results/EnumerableInt32WhereSelectToArray.md)
- [enumerable.Where().Select().ToList()](Results/EnumerableInt32WhereSelectToList.md)

### `int[]`

- [array.Distinct()](Results/ArrayInt32Distinct.md)
- [array.Select()](Results/ArrayInt32Select.md)
- [array.Skip().Take().Select()](Results/ArrayInt32SkipTakeSelect.md)
- [array.Skip().Take().Where()](Results/ArrayInt32SkipTakeWhere.md)
- [array.Where()](Results/ArrayInt32Where.md)
- [array.Where().Count()](Results/ArrayInt32WhereCount.md)
- [array.Where().Select()](Results/ArrayInt32WhereSelect.md)
- [array.Where().Select().ToArray()](Results/ArrayInt32WhereSelectToArray.md)
- [array.Where().Select().ToList()](Results/ArrayInt32WhereSelectToList.md)

### `FatValueType[]`

- [array.Distinct()](Results/ArrayValueTypeDistinct.md)
- [array.Select()](Results/ArrayValueTypeSelect.md)
- [array.Skip().Take().Select()](Results/ArrayValueTypeSkipTakeSelect.md)
- [array.Skip().Take().Where()](Results/ArrayValueTypeSkipTakeWhere.md)
- [array.Where()](Results/ArrayValueTypeWhere.md)
- [array.Where().Count()](Results/ArrayValueTypeWhereCount.md)
- [array.Where().Select()](Results/ArrayValueTypeWhereSelect.md)
- [array.Where().Select().ToArray()](Results/ArrayValueTypeWhereSelectToArray.md)
- [array.Where().Select().ToList()](Results/ArrayValueTypeWhereSelectToList.md)

### `List<int>`

- [list.Distinct()](Results/ListInt32Distinct.md)
- [list.Select()](Results/ListInt32Select.md)
- [list.Skip().Take().Select()](Results/ListInt32SkipTakeSelect.md)
- [list.Skip().Take().Where()](Results/ListInt32SkipTakeWhere.md)
- [list.Where()](Results/ListInt32Where.md)
- [list.Where().Select()](Results/ListInt32WhereSelect.md)
- [list.Where().Select().ToArray()](Results/ListInt32WhereSelectToArray.md)
- [list.Where().Select().ToList()](Results/ListInt32WhereSelectToList.md)

### `List<FatValueType>`

- [list.Distinct()](Results/ListValueTypeDistinct.md)
- [list.Select()](Results/ListValueTypeSelect.md)
- [list.Skip().Take().Select()](Results/ListValueTypeSkipTakeSelect.md)
- [list.Skip().Take().Where()](Results/ListValueTypeSkipTakeWhere.md)
- [list.Where()](Results/ListValueTypeWhere.md)
- [list.Where().Select()](Results/ListValueTypeWhereSelect.md)
- [list.Where().Select().ToArray()](Results/ListValueTypeWhereSelectToArray.md)
- [list.Where().Select().ToList()](Results/ListValueTypeWhereSelectToList.md)

