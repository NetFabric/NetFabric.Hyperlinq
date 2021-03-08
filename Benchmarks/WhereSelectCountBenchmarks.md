## WhereSelectCountBenchmarks

### Source
[WhereSelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectCountBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   311.0 ns |  1.27 ns |  1.13 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                     Hyperlinq_Array |                     Array |   100 |   179.1 ns |  0.41 ns |  0.39 ns |  0.58 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,230.8 ns |  4.24 ns |  3.97 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   260.2 ns |  0.85 ns |  0.79 ns |  0.21 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,211.5 ns |  2.55 ns |  2.39 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   216.4 ns |  0.99 ns |  0.87 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,204.5 ns |  3.22 ns |  2.86 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   641.8 ns |  1.79 ns |  1.67 ns |  0.53 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,789.2 ns |  8.70 ns |  7.71 ns |  1.00 | 0.0839 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,353.5 ns |  4.98 ns |  4.66 ns |  0.58 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   825.5 ns |  5.57 ns |  5.21 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   555.2 ns |  6.33 ns |  5.29 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   811.7 ns |  1.99 ns |  1.76 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   591.8 ns |  2.44 ns |  2.04 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   828.4 ns |  3.43 ns |  3.21 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   716.2 ns |  3.67 ns |  3.06 ns |  0.86 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,741.1 ns | 34.42 ns | 28.74 ns |  1.00 | 0.0839 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,554.6 ns |  6.29 ns |  5.25 ns |  0.62 | 0.0191 |     - |     - |      40 B |
