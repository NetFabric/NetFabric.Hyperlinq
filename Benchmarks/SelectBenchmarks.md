## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   634.6 ns |  2.38 ns |  2.11 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   232.2 ns |  0.37 ns |  0.29 ns |  0.37 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |   100 |   226.5 ns |  3.05 ns |  2.54 ns |  0.36 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |   100 |   209.0 ns |  0.85 ns |  0.76 ns |  0.33 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |   100 |   199.0 ns |  0.86 ns |  0.76 ns |  0.31 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |   100 |   209.5 ns |  0.96 ns |  0.90 ns |  0.33 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |   100 |   352.7 ns |  1.13 ns |  1.00 ns |  0.56 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |   100 |   237.4 ns |  1.09 ns |  0.97 ns |  0.37 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,216.2 ns |  5.09 ns |  4.25 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   739.1 ns |  4.27 ns |  3.57 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   211.1 ns |  1.23 ns |  1.09 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,165.7 ns |  6.67 ns |  5.91 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   735.9 ns |  3.02 ns |  2.68 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   211.3 ns |  0.64 ns |  0.57 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,174.4 ns |  4.15 ns |  3.68 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   374.7 ns |  2.22 ns |  1.97 ns |  0.32 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |   100 |   379.3 ns |  1.18 ns |  1.04 ns |  0.32 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |   100 |   393.0 ns |  1.47 ns |  1.38 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,148.1 ns | 18.84 ns | 16.70 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,148.5 ns | 16.21 ns | 15.16 ns |  0.72 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,164.0 ns |  4.45 ns |  3.95 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   790.4 ns |  4.13 ns |  3.66 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   780.9 ns |  3.94 ns |  3.49 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,197.2 ns |  4.66 ns |  4.36 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   736.3 ns |  2.27 ns |  2.01 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   814.1 ns |  2.98 ns |  2.79 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,205.2 ns |  3.78 ns |  3.35 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   735.4 ns |  2.67 ns |  2.37 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |   100 |   403.9 ns |  1.10 ns |  0.97 ns |  0.34 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |   100 |   399.8 ns |  1.51 ns |  1.18 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,226.5 ns | 19.84 ns | 17.58 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,544.6 ns | 21.90 ns | 19.41 ns |  0.77 | 0.0153 |     - |     - |      32 B |
