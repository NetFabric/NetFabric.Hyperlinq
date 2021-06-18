## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   634.9 ns |  6.67 ns |  5.92 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   206.7 ns |  1.40 ns |  1.17 ns |  0.33 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |   100 |   300.1 ns |  2.67 ns |  2.49 ns |  0.47 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |   100 |   209.7 ns |  0.70 ns |  0.62 ns |  0.33 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |   100 |   196.8 ns |  1.09 ns |  1.02 ns |  0.31 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |   100 |   230.9 ns |  0.87 ns |  0.81 ns |  0.36 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |   100 |   350.3 ns |  2.06 ns |  1.72 ns |  0.55 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |   100 |   232.6 ns |  0.50 ns |  0.41 ns |  0.37 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,168.6 ns |  4.90 ns |  3.83 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   789.1 ns |  2.65 ns |  2.35 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   209.2 ns |  0.60 ns |  0.53 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,192.1 ns |  5.24 ns |  4.38 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   780.3 ns |  3.58 ns |  3.18 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   208.0 ns |  0.74 ns |  0.62 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,190.9 ns | 11.63 ns | 10.31 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   440.0 ns |  1.36 ns |  1.27 ns |  0.37 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   743.3 ns |  5.20 ns |  4.61 ns |  0.62 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,530.2 ns | 23.55 ns | 20.88 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,789.9 ns | 24.40 ns | 22.82 ns |  0.73 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,157.4 ns |  6.61 ns |  6.19 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   789.6 ns |  5.00 ns |  4.44 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   758.0 ns |  4.30 ns |  3.81 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,158.5 ns |  4.83 ns |  3.77 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   789.2 ns |  4.96 ns |  4.40 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   761.8 ns |  3.01 ns |  2.81 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,178.0 ns |  8.81 ns |  8.24 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   778.2 ns |  2.60 ns |  2.43 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   782.6 ns |  3.64 ns |  3.04 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,551.7 ns | 31.19 ns | 29.17 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,147.7 ns | 14.49 ns | 12.85 ns |  0.79 | 0.0153 |     - |     - |      32 B |
