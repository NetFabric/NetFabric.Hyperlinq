## ElementAtBenchmarks

### Source
[ElementAtBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ElementAtBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |         Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    18.585 ns | 0.0733 ns | 0.0650 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    12.935 ns | 0.0287 ns | 0.0268 ns |  0.70 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   343.258 ns | 1.3405 ns | 1.1194 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   144.574 ns | 0.3296 ns | 0.2752 ns |  0.42 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   344.587 ns | 1.0413 ns | 0.8130 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   149.877 ns | 0.4437 ns | 0.3933 ns |  0.44 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     9.966 ns | 0.0418 ns | 0.0391 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |    14.887 ns | 0.0451 ns | 0.0422 ns |  1.49 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,794.411 ns | 6.5545 ns | 5.4733 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   969.878 ns | 4.0156 ns | 3.7562 ns |  0.54 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   344.638 ns | 1.2438 ns | 1.1026 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   341.807 ns | 1.5447 ns | 1.3694 ns |  0.99 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   344.314 ns | 0.9447 ns | 0.8375 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   370.607 ns | 1.3467 ns | 1.1245 ns |  1.08 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    10.000 ns | 0.0869 ns | 0.0770 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    14.735 ns | 0.0550 ns | 0.0487 ns |  1.47 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,793.513 ns | 5.0783 ns | 4.5017 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,604.776 ns | 3.7408 ns | 3.1238 ns |  0.89 | 0.0153 |     - |     - |      32 B |
