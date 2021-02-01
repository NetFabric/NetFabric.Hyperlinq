## SelectToListBenchmarks

### Source
[SelectToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToListBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                           Linq_List |                     Array |   100 |   313.9 ns |  0.99 ns |  0.87 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                     StructLinq_List |                     Array |   100 |   259.8 ns |  0.65 ns |  0.61 ns |  0.83 |    0.00 | 0.2179 |     - |     - |     456 B |
|                      Hyperlinq_List |                     Array |   100 |   222.9 ns |  0.43 ns |  0.36 ns |  0.71 |    0.00 | 0.2179 |     - |     - |     456 B |
|                      Hyperlinq_Span |                     Array |   100 |   221.4 ns |  0.86 ns |  0.77 ns |  0.71 |    0.00 | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |   202.7 ns |  0.68 ns |  0.57 ns |  0.65 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,079.1 ns |  2.63 ns |  2.46 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,032.1 ns |  3.91 ns |  3.47 ns |  0.96 |    0.00 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   617.7 ns |  0.95 ns |  0.88 ns |  0.57 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,117.5 ns |  3.96 ns |  3.31 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,029.1 ns |  3.21 ns |  3.00 ns |  0.92 |    0.00 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   252.1 ns |  1.15 ns |  1.08 ns |  0.23 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   504.9 ns |  1.24 ns |  1.03 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 |   442.3 ns |  0.88 ns |  0.78 ns |  0.88 |    0.00 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   385.6 ns |  1.02 ns |  0.91 ns |  0.76 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   883.2 ns |  2.55 ns |  2.26 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   872.5 ns |  1.61 ns |  1.43 ns |  0.99 |    0.00 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   953.2 ns |  1.67 ns |  1.39 ns |  1.08 |    0.00 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   919.5 ns |  1.37 ns |  1.07 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   857.0 ns |  1.77 ns |  1.65 ns |  0.93 |    0.00 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   604.9 ns |  4.90 ns |  4.34 ns |  0.66 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   458.1 ns |  1.16 ns |  1.03 ns |  1.00 |    0.00 | 0.2446 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   875.1 ns |  1.77 ns |  1.48 ns |  1.91 |    0.00 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   389.0 ns |  1.96 ns |  1.64 ns |  0.85 |    0.00 | 0.2179 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,480.1 ns | 14.18 ns | 12.57 ns |     ? |       ? | 0.6256 |     - |     - |    1320 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,036.1 ns | 22.12 ns | 19.61 ns |     ? |       ? | 0.6256 |     - |     - |    1336 B |
