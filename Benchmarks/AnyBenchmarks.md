## AnyBenchmarks

### Source
[AnyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyBenchmarks.cs)

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
|                              Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  8.874 ns | 0.0473 ns | 0.0442 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  8.295 ns | 0.0321 ns | 0.0300 ns |  0.93 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 21.884 ns | 0.1573 ns | 0.1314 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 11.296 ns | 0.0425 ns | 0.0332 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  5.370 ns | 0.1195 ns | 0.1118 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  8.238 ns | 0.0508 ns | 0.0476 ns |  1.53 |    0.03 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  5.860 ns | 0.0582 ns | 0.0544 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  1.569 ns | 0.0238 ns | 0.0199 ns |  0.27 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 62.273 ns | 0.4126 ns | 0.3222 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 52.364 ns | 0.1373 ns | 0.1146 ns |  0.84 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 22.123 ns | 0.3594 ns | 0.3361 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 13.315 ns | 0.0734 ns | 0.0650 ns |  0.60 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  5.171 ns | 0.0717 ns | 0.0635 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.568 ns | 0.0145 ns | 0.0135 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  5.851 ns | 0.0434 ns | 0.0406 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  1.552 ns | 0.0120 ns | 0.0100 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 61.675 ns | 0.2805 ns | 0.2624 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 58.200 ns | 0.1898 ns | 0.1585 ns |  0.94 |    0.00 | 0.0153 |     - |     - |      32 B |
