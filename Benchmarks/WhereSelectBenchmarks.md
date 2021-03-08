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
|                          Linq_Array |                     Array |   100 |   720.7 ns |  3.50 ns |  3.10 ns |  1.00 |    0.00 | 0.0496 |     - |     - |     104 B |
|                    StructLinq_Array |                     Array |   100 |   368.9 ns |  2.04 ns |  1.90 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   718.7 ns | 12.14 ns | 10.76 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   367.0 ns |  1.03 ns |  0.91 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   363.7 ns |  1.74 ns |  1.63 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,578.7 ns |  6.65 ns |  6.22 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,394.1 ns |  5.28 ns |  4.94 ns |  0.88 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   408.2 ns |  1.86 ns |  1.55 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,583.4 ns | 10.57 ns |  9.88 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,397.2 ns | 13.90 ns | 29.91 ns |  0.89 |    0.03 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   409.3 ns |  1.57 ns |  1.31 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,600.0 ns |  7.24 ns |  6.42 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|               StructLinq_List_Value |                List_Value |   100 |   772.7 ns |  4.36 ns |  4.08 ns |  0.48 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   817.2 ns |  2.65 ns |  2.35 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,715.3 ns | 18.30 ns | 16.22 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,570.4 ns | 23.15 ns | 21.65 ns |  0.97 |    0.01 | 0.0992 |     - |     - |     216 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,280.6 ns |  7.35 ns |  6.52 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   891.3 ns |  3.38 ns |  3.00 ns |  0.70 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   881.8 ns |  4.62 ns |  4.32 ns |  0.69 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,257.3 ns |  4.58 ns |  3.82 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   903.3 ns |  3.73 ns |  3.12 ns |  0.72 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   968.0 ns |  3.56 ns |  2.78 ns |  0.77 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,319.3 ns |  4.62 ns |  4.32 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   908.5 ns |  2.06 ns |  1.83 ns |  0.69 |    0.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   887.0 ns |  1.38 ns |  1.08 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,522.7 ns |  8.16 ns |  6.81 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,802.2 ns | 14.54 ns | 13.60 ns |  1.05 |    0.00 | 0.1068 |     - |     - |     224 B |
