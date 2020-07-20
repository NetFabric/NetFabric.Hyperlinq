# LinqBenchmarks

Benchmarks comparing the perfomance of [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/) against handwritten code and the following libraries: 

- [JM.LinqFaster](https://github.com/jackmott/LinqFaster)
- [StructLinq](https://github.com/reegeek/StructLinq)
- [NetFabric.Hyperlinq](https://github.com/NetFabric/NetFabric.Hyperlinq)

## Results

### Item Type: `int`

#### Source: array

- [array.Distinct()](Results/Int32ArrayDistinct.md)
- [array.Select()](Results/Int32ArraySelect.md)
- [array.Skip().Take().Select()](Results/Int32ArraySkipTakeSelect.md)
- [array.Skip().Take().Where()](Results/Int32ArraySkipTakeWhere.md)
- [array.Where()](Results/Int32ArrayWhere.md)
- [array.Where().Count()](Results/Int32ArrayWhereCount.md)
- [array.Where().Select()](Results/Int32ArrayWhereSelect.md)
- [array.Where().Select().ToArray()](Results/Int32ArrayWhereSelectToArray.md)
- [array.Where().Select().ToList()](Results/Int32ArrayWhereSelectToList.md)

#### Source: `List<>`

- [list.Distinct()](Results/Int32ListDistinct.md)
- [list.Select()](Results/Int32ListSelect.md)
- [list.Skip().Take().Select()](Results/Int32ListSkipTakeSelect.md)
- [list.Skip().Take().Where()](Results/Int32ListSkipTakeWhere.md)
- [list.Where()](Results/Int32ListWhere.md)
- [list.Where().Select()](Results/Int32ListWhereSelect.md)
- [list.Where().Select().ToArray()](Results/Int32ListWhereSelectToArray.md)
- [list.Where().Select().ToList()](Results/Int32ListWhereSelectToList.md)

#### Source: `Range()`

- [Range().Select()](Results/Int32RangeSelect.md)
- [Range().Select().ToArray()](Results/Int32RangeSelectToArray.md)
- [Range().Select().ToList()](Results/Int32RangeSelectToList.md)
- [Range().ToArray()](Results/Int32RangeToArray.md)
- [Range().ToList()](Results/Int32RangeToList.md)


### Item Type: Fat value type

#### Source: array

- [array.Distinct()](Results/ValueTypeArrayDistinct.md)
- [array.Select()](Results/ValueTypeArraySelect.md)
- [array.Skip().Take().Select()](Results/ValueTypeArraySkipTakeSelect.md)
- [array.Skip().Take().Where()](Results/ValueTypeArraySkipTakeWhere.md)
- [array.Where()](Results/ValueTypeArrayWhere.md)
- [array.Where().Count()](Results/ValueTypeArrayWhereCount.md)
- [array.Where().Select()](Results/ValueTypeArrayWhereSelect.md)
- [array.Where().Select().ToArray()](Results/ValueTypeArrayWhereSelectToArray.md)
- [array.Where().Select().ToList()](Results/ValueTypeArrayWhereSelectToList.md)

#### Source: `List<>`

- [list.Distinct()](Results/ValueTypeListDistinct.md)
- [list.Select()](Results/ValueTypeListSelect.md)
- [list.Skip().Take().Select()](Results/ValueTypeListSkipTakeSelect.md)
- [list.Skip().Take().Where()](Results/ValueTypeListSkipTakeWhere.md)
- [list.Where()](Results/ValueTypeListWhere.md)
- [list.Where().Select()](Results/ValueTypeListWhereSelect.md)
- [list.Where().Select().ToArray()](Results/ValueTypeListWhereSelectToArray.md)
- [list.Where().Select().ToList()](Results/ValueTypeListWhereSelectToList.md)
