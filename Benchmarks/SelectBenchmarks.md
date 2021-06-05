## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   642.6 ns |  2.60 ns |  2.17 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   206.1 ns |  0.58 ns |  0.52 ns |  0.32 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |   100 |   273.0 ns |  1.36 ns |  1.13 ns |  0.42 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |   100 |   209.9 ns |  0.67 ns |  0.56 ns |  0.33 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |   100 |   172.1 ns |  0.72 ns |  0.64 ns |  0.27 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |   100 |   208.8 ns |  0.72 ns |  0.60 ns |  0.32 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |   100 |   298.9 ns |  1.53 ns |  1.36 ns |  0.47 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |   100 |   232.7 ns |  0.57 ns |  0.48 ns |  0.36 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,138.7 ns |  5.13 ns |  4.80 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   754.1 ns |  6.10 ns |  5.41 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   229.8 ns |  0.52 ns |  0.46 ns |  0.20 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,230.2 ns | 11.48 ns | 10.17 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   758.3 ns |  5.50 ns |  5.15 ns |  0.62 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   207.7 ns |  0.54 ns |  0.50 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,227.2 ns |  5.49 ns |  4.58 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   438.1 ns |  0.93 ns |  0.82 ns |  0.36 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   742.3 ns |  4.22 ns |  3.74 ns |  0.60 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,756.0 ns | 28.27 ns | 26.45 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,746.1 ns | 31.36 ns | 29.34 ns |  0.70 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,170.2 ns |  4.51 ns |  4.00 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   703.7 ns |  4.61 ns |  4.08 ns |  0.60 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   785.8 ns |  7.09 ns |  6.28 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,173.1 ns |  5.95 ns |  5.27 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   758.6 ns |  4.39 ns |  3.89 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   755.6 ns |  3.61 ns |  3.38 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,130.5 ns |  7.47 ns |  6.24 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   753.1 ns |  4.04 ns |  3.58 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   753.5 ns |  4.30 ns |  3.81 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,635.0 ns | 40.24 ns | 35.67 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,152.2 ns | 20.92 ns | 18.54 ns |  0.78 | 0.0153 |     - |     - |      32 B |
