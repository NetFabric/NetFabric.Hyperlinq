## SelectToListBenchmarks

### Source
[SelectToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToListBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                           Linq_List |                     Array |   100 |    312.9 ns |  1.55 ns |  1.38 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                     StructLinq_List |                     Array |   100 |    254.8 ns |  1.27 ns |  1.19 ns |  0.81 |    0.01 | 0.2179 |     - |     - |     456 B |
|                      Hyperlinq_List |                     Array |   100 |    248.8 ns |  3.14 ns |  2.79 ns |  0.80 |    0.01 | 0.2179 |     - |     - |     456 B |
|                      Hyperlinq_Span |                     Array |   100 |    247.6 ns |  1.12 ns |  1.04 ns |  0.79 |    0.00 | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |    273.1 ns |  0.78 ns |  0.70 ns |  0.87 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  1,158.8 ns | 10.03 ns |  9.38 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |  1,122.7 ns |  7.34 ns |  6.86 ns |  0.97 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |    610.0 ns |  2.28 ns |  2.02 ns |  0.53 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  1,140.9 ns |  4.55 ns |  4.25 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |  1,061.7 ns |  4.10 ns |  3.20 ns |  0.93 |    0.00 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    270.1 ns |  1.35 ns |  1.26 ns |  0.24 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    492.5 ns |  3.23 ns |  3.02 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |    424.2 ns |  1.74 ns |  1.46 ns |  0.86 |    0.01 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    766.9 ns |  4.33 ns |  4.05 ns |  1.56 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |    909.3 ns |  2.98 ns |  2.49 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |    910.5 ns |  3.42 ns |  2.86 ns |  1.00 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |    981.0 ns |  4.05 ns |  3.38 ns |  1.08 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    910.4 ns |  2.83 ns |  2.36 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |    902.4 ns |  5.84 ns |  5.46 ns |  0.99 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    637.5 ns |  2.49 ns |  2.33 ns |  0.70 |    0.00 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    513.5 ns |  2.04 ns |  1.81 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 |    919.2 ns |  4.83 ns |  4.52 ns |  1.79 |    0.01 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    748.3 ns |  2.14 ns |  1.89 ns |  1.46 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 10,643.7 ns | 52.84 ns | 44.13 ns |     ? |       ? | 0.6256 |     - |     - |    1328 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  9,952.2 ns | 36.03 ns | 30.09 ns |     ? |       ? | 0.6256 |     - |     - |    1336 B |
