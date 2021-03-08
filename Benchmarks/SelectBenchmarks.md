## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   663.9 ns |  4.95 ns |  3.87 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   216.4 ns |  0.85 ns |  0.75 ns |  0.33 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |   100 |   223.8 ns |  1.21 ns |  1.07 ns |  0.34 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |   100 |   232.6 ns |  0.81 ns |  0.72 ns |  0.35 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |   100 |   220.2 ns |  0.70 ns |  0.59 ns |  0.33 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |   100 |   208.1 ns |  0.86 ns |  0.76 ns |  0.31 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |   100 |   300.7 ns |  1.33 ns |  1.18 ns |  0.45 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |   100 |   238.5 ns |  1.61 ns |  1.51 ns |  0.36 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,202.4 ns |  7.28 ns |  6.81 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   804.7 ns |  2.91 ns |  2.58 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   760.8 ns |  4.59 ns |  4.29 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,255.0 ns |  4.88 ns |  4.57 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   803.8 ns |  4.28 ns |  3.80 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   804.1 ns |  4.24 ns |  3.97 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,246.2 ns |  7.50 ns |  7.02 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   374.3 ns |  1.37 ns |  1.28 ns |  0.30 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |   100 |   379.3 ns |  2.02 ns |  1.79 ns |  0.30 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |   100 |   438.2 ns |  1.85 ns |  1.64 ns |  0.35 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,049.3 ns | 71.78 ns | 59.94 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,039.2 ns | 42.93 ns | 38.05 ns |  0.75 | 0.1373 |     - |     - |     296 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   970.1 ns |  4.77 ns |  4.23 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   521.8 ns |  3.76 ns |  3.52 ns |  0.54 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   567.1 ns |  2.01 ns |  1.88 ns |  0.58 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   982.2 ns |  7.73 ns |  7.23 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   572.1 ns |  3.56 ns |  3.16 ns |  0.58 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   597.5 ns |  2.98 ns |  2.49 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   963.6 ns |  4.80 ns |  4.26 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   571.2 ns |  1.89 ns |  1.68 ns |  0.59 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |   100 |   404.5 ns |  1.52 ns |  1.35 ns |  0.42 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |   100 |   438.0 ns |  1.18 ns |  0.98 ns |  0.45 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,251.7 ns | 41.70 ns | 36.97 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,954.0 ns | 20.49 ns | 18.17 ns |  0.72 | 0.1373 |     - |     - |     296 B |
