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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   589.9 ns |  2.07 ns |  1.83 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   226.2 ns |  0.87 ns |  0.77 ns |  0.38 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |   100 |   297.1 ns |  1.63 ns |  1.52 ns |  0.50 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |   100 |   208.8 ns |  0.62 ns |  0.58 ns |  0.35 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |   100 |   197.5 ns |  0.78 ns |  0.65 ns |  0.33 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |   100 |   208.3 ns |  0.62 ns |  0.52 ns |  0.35 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |   100 |   299.8 ns |  1.99 ns |  1.67 ns |  0.51 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |   100 |   232.3 ns |  0.60 ns |  0.50 ns |  0.39 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,197.2 ns |  5.22 ns |  4.88 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   749.6 ns |  2.16 ns |  1.92 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   229.6 ns |  0.50 ns |  0.42 ns |  0.19 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,230.5 ns | 15.98 ns | 13.34 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   777.3 ns |  3.24 ns |  2.87 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   206.6 ns |  0.66 ns |  0.55 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,183.7 ns |  4.01 ns |  3.56 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   439.6 ns |  1.84 ns |  1.63 ns |  0.37 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   759.3 ns |  3.40 ns |  3.01 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,848.7 ns | 33.67 ns | 29.85 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,724.6 ns | 19.11 ns | 16.94 ns |  0.69 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,168.8 ns |  5.61 ns |  5.25 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   699.4 ns |  1.85 ns |  1.54 ns |  0.60 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   775.8 ns |  5.45 ns |  5.35 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,172.4 ns |  6.69 ns |  5.93 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   756.2 ns |  2.48 ns |  2.20 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   754.2 ns |  2.39 ns |  1.99 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,180.1 ns |  9.98 ns |  8.85 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   755.6 ns |  5.35 ns |  4.74 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   752.5 ns |  3.45 ns |  3.06 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,323.5 ns | 41.43 ns | 38.76 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,159.2 ns | 19.05 ns | 16.88 ns |  0.70 | 0.0153 |     - |     - |      32 B |
