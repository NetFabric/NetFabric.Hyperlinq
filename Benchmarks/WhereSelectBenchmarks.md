## WhereSelectBenchmarks

### Source
[WhereSelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   685.4 ns |  5.29 ns |  4.69 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                    StructLinq_Array |                     Array |   100 |   341.1 ns |  4.00 ns |  3.55 ns |  0.50 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   320.2 ns |  2.11 ns |  1.76 ns |  0.47 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   342.0 ns |  1.98 ns |  1.76 ns |  0.50 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   311.5 ns |  1.76 ns |  1.56 ns |  0.45 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,534.6 ns |  6.02 ns |  5.33 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,295.4 ns |  7.73 ns |  6.45 ns |  0.84 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   344.9 ns |  1.64 ns |  1.54 ns |  0.22 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,534.1 ns |  6.13 ns |  4.79 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,314.8 ns |  5.35 ns |  5.01 ns |  0.86 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   337.7 ns |  1.82 ns |  1.52 ns |  0.22 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,560.1 ns |  6.92 ns |  5.78 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|               StructLinq_List_Value |                List_Value |   100 |   641.5 ns |  2.23 ns |  2.09 ns |  0.41 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,309.6 ns |  7.32 ns |  6.49 ns |  0.84 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,566.5 ns | 18.63 ns | 16.51 ns |  1.00 | 0.0763 |     - |     - |     168 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,182.6 ns | 15.41 ns | 13.66 ns |  1.13 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,536.6 ns | 11.02 ns | 10.30 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,263.9 ns |  4.48 ns |  3.97 ns |  0.82 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,305.1 ns |  8.92 ns |  7.91 ns |  0.85 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,539.3 ns |  9.95 ns |  8.82 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,340.1 ns |  4.31 ns |  3.82 ns |  0.87 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,303.3 ns |  5.44 ns |  4.54 ns |  0.85 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,507.4 ns |  7.45 ns |  6.60 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,317.5 ns |  7.39 ns |  6.17 ns |  0.87 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,316.8 ns |  7.71 ns |  7.21 ns |  0.87 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,638.1 ns | 14.50 ns | 12.85 ns |  1.00 | 0.0763 |     - |     - |     168 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,311.7 ns | 22.40 ns | 20.96 ns |  1.15 | 0.0153 |     - |     - |      32 B |
