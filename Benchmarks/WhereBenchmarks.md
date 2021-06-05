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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   476.1 ns |  1.28 ns |  1.00 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   420.7 ns |  2.05 ns |  1.60 ns |  0.88 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   454.9 ns |  8.96 ns |  7.48 ns |  0.96 |    0.02 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   285.2 ns |  3.14 ns |  2.78 ns |  0.60 |    0.01 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   281.9 ns |  3.91 ns |  3.66 ns |  0.59 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,435.5 ns |  4.18 ns |  3.49 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,312.0 ns |  4.36 ns |  3.87 ns |  0.91 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   318.3 ns |  5.67 ns |  4.73 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,425.6 ns |  5.94 ns |  4.96 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,250.3 ns |  4.41 ns |  4.12 ns |  0.88 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   457.9 ns |  2.28 ns |  2.02 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,424.8 ns |  6.49 ns |  5.75 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   537.2 ns |  6.07 ns |  5.38 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,192.8 ns |  4.17 ns |  3.69 ns |  0.84 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,588.5 ns | 28.72 ns | 25.46 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,824.0 ns | 38.62 ns | 34.24 ns |  1.05 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,472.5 ns |  9.86 ns |  9.23 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,315.8 ns |  5.21 ns |  4.35 ns |  0.89 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,323.7 ns | 12.74 ns | 10.64 ns |  0.90 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,445.5 ns |  4.36 ns |  4.08 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,281.3 ns |  7.90 ns |  7.01 ns |  0.89 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,201.4 ns |  5.52 ns |  4.90 ns |  0.83 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,486.3 ns |  3.86 ns |  3.61 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,313.5 ns |  4.98 ns |  4.41 ns |  0.88 |    0.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,239.1 ns |  5.14 ns |  4.02 ns |  0.83 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,582.2 ns | 12.88 ns | 12.04 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,766.2 ns | 26.21 ns | 20.46 ns |  1.04 |    0.00 | 0.0153 |     - |     - |      32 B |
