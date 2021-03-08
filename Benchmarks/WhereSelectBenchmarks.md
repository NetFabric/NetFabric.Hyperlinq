## WhereSelectBenchmarks

### Source
[WhereSelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   702.0 ns |  5.32 ns |  4.71 ns |  1.00 |    0.00 | 0.0496 |     - |     - |     104 B |
|                    StructLinq_Array |                     Array |   100 |   358.7 ns |  1.67 ns |  1.48 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   639.4 ns | 12.60 ns | 12.94 ns |  0.91 |    0.02 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   351.0 ns |  0.80 ns |  0.71 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   351.2 ns |  1.84 ns |  1.72 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,520.3 ns |  5.94 ns |  5.26 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,354.8 ns |  3.85 ns |  3.21 ns |  0.89 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,397.5 ns |  6.32 ns |  5.91 ns |  0.92 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,526.6 ns | 10.32 ns |  9.15 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,344.8 ns |  5.53 ns |  4.91 ns |  0.88 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1,325.3 ns |  6.81 ns |  6.03 ns |  0.87 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,538.5 ns |  6.01 ns |  5.02 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|               StructLinq_List_Value |                List_Value |   100 |   759.1 ns |  3.32 ns |  3.11 ns |  0.49 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   852.1 ns |  4.14 ns |  3.67 ns |  0.55 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,654.8 ns | 20.70 ns | 18.35 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,684.7 ns | 18.72 ns | 17.51 ns |  1.00 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,214.3 ns |  5.50 ns |  5.14 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   865.9 ns |  5.05 ns |  4.47 ns |  0.71 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   862.3 ns |  2.26 ns |  1.88 ns |  0.71 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,215.4 ns |  3.19 ns |  2.83 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   873.8 ns |  3.37 ns |  2.99 ns |  0.72 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   941.5 ns |  3.10 ns |  2.90 ns |  0.77 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,268.8 ns |  6.14 ns |  5.45 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   894.6 ns |  3.74 ns |  3.13 ns |  0.71 |    0.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   848.6 ns |  2.93 ns |  2.60 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,440.3 ns | 14.08 ns | 11.75 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,613.7 ns | 15.16 ns | 13.44 ns |  1.03 |    0.00 | 0.1068 |     - |     - |     224 B |
