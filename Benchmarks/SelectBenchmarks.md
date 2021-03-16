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
  Job-KXCEYC : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   662.5 ns | 13.09 ns | 12.85 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   234.5 ns |  0.94 ns |  0.84 ns |  0.35 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |   100 |   225.5 ns |  0.73 ns |  0.61 ns |  0.34 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |   100 |   209.5 ns |  0.83 ns |  0.78 ns |  0.32 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |   100 |   198.5 ns |  0.69 ns |  0.64 ns |  0.30 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |   100 |   208.6 ns |  0.48 ns |  0.45 ns |  0.31 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |   100 |   353.6 ns |  1.81 ns |  1.69 ns |  0.53 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |   100 |   237.4 ns |  1.06 ns |  0.99 ns |  0.36 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,214.8 ns |  5.55 ns |  4.92 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   738.4 ns |  4.03 ns |  3.77 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   210.4 ns |  0.54 ns |  0.47 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,165.4 ns |  4.55 ns |  3.80 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   736.0 ns |  3.95 ns |  3.30 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   210.7 ns |  0.78 ns |  0.69 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,169.6 ns |  5.22 ns |  4.63 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   371.5 ns |  1.38 ns |  1.22 ns |  0.32 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |   100 |   377.6 ns |  1.43 ns |  1.27 ns |  0.32 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |   100 |   391.5 ns |  1.21 ns |  1.07 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,242.1 ns | 26.11 ns | 21.80 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,225.4 ns | 15.83 ns | 14.03 ns |  0.72 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,166.3 ns |  8.20 ns |  7.27 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   786.8 ns |  2.88 ns |  2.41 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   791.6 ns |  9.23 ns |  8.18 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,196.1 ns |  2.06 ns |  1.61 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   737.8 ns |  2.97 ns |  2.78 ns |  0.62 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   814.8 ns |  2.78 ns |  2.46 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,201.1 ns |  3.43 ns |  2.86 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   735.1 ns |  2.54 ns |  2.12 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |   100 |   405.1 ns |  1.33 ns |  1.18 ns |  0.34 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |   100 |   399.4 ns |  1.41 ns |  1.18 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,095.8 ns | 37.36 ns | 29.17 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,536.8 ns | 16.65 ns | 15.58 ns |  0.78 | 0.0153 |     - |     - |      32 B |
