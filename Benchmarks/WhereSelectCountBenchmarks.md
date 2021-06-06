## WhereSelectCountBenchmarks

### Source
[WhereSelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectCountBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   351.2 ns |  4.93 ns |  4.11 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                     Hyperlinq_Array |                     Array |   100 |   205.3 ns |  0.54 ns |  0.48 ns |  0.58 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,201.9 ns |  5.46 ns |  4.84 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   233.7 ns |  0.83 ns |  0.74 ns |  0.19 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,163.1 ns |  6.69 ns |  6.26 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   226.7 ns |  1.15 ns |  1.02 ns |  0.19 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,190.5 ns |  3.39 ns |  3.17 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   790.1 ns |  5.03 ns |  4.46 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,784.1 ns | 15.70 ns | 13.92 ns |  1.00 | 0.0763 |     - |     - |     168 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,498.6 ns |  5.24 ns |  4.90 ns |  0.52 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,238.5 ns |  4.32 ns |  3.83 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   743.7 ns |  3.76 ns |  3.52 ns |  0.60 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,219.2 ns |  5.79 ns |  5.42 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   766.8 ns |  4.34 ns |  3.85 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,207.0 ns |  3.77 ns |  3.53 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   743.7 ns |  2.69 ns |  2.51 ns |  0.62 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,810.9 ns | 21.97 ns | 19.47 ns |  1.00 | 0.0763 |     - |     - |     168 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,827.4 ns |  7.57 ns |  7.08 ns |  0.59 | 0.0153 |     - |     - |      32 B |
