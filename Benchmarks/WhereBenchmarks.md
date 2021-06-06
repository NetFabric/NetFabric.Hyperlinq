## WhereBenchmarks

### Source
[WhereBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   468.6 ns |  1.69 ns |  1.41 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   293.9 ns |  5.43 ns |  4.24 ns |  0.63 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   459.4 ns |  3.21 ns |  2.84 ns |  0.98 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   281.2 ns |  3.56 ns |  3.33 ns |  0.60 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   292.9 ns |  3.54 ns |  3.31 ns |  0.63 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,316.1 ns |  6.43 ns |  5.70 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,192.8 ns |  6.54 ns |  5.80 ns |  0.91 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   454.0 ns |  5.33 ns |  4.98 ns |  0.34 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,336.9 ns |  7.84 ns |  6.95 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,188.0 ns |  4.55 ns |  4.04 ns |  0.89 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   317.1 ns |  4.24 ns |  3.96 ns |  0.24 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,335.1 ns | 10.22 ns |  9.06 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   520.6 ns |  6.76 ns |  6.00 ns |  0.39 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,200.0 ns |  4.20 ns |  3.72 ns |  0.90 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,636.3 ns | 16.42 ns | 14.55 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,793.0 ns | 13.00 ns | 12.16 ns |  1.03 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,367.6 ns |  6.31 ns |  5.59 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,210.8 ns |  5.67 ns |  5.03 ns |  0.89 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,204.7 ns |  7.32 ns |  6.11 ns |  0.88 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,353.5 ns |  5.74 ns |  5.09 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,202.1 ns |  4.64 ns |  4.11 ns |  0.89 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,288.8 ns |  3.05 ns |  2.70 ns |  0.95 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,360.9 ns |  5.95 ns |  5.56 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,196.2 ns |  5.49 ns |  4.87 ns |  0.88 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,224.8 ns |  5.59 ns |  5.23 ns |  0.90 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,502.2 ns | 28.22 ns | 23.56 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,763.8 ns |  9.88 ns |  8.76 ns |  1.06 | 0.0153 |     - |     - |      32 B |
