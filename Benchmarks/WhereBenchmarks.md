## WhereBenchmarks

### Source
[WhereBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   482.7 ns |  2.93 ns |  2.60 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   255.5 ns |  1.88 ns |  1.76 ns |  0.53 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   275.0 ns |  2.62 ns |  2.32 ns |  0.57 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   283.5 ns |  1.19 ns |  0.99 ns |  0.59 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   258.8 ns |  1.24 ns |  1.16 ns |  0.54 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,378.9 ns |  4.68 ns |  4.15 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,281.6 ns |  4.92 ns |  4.36 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   245.6 ns |  1.43 ns |  1.27 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,372.2 ns |  5.77 ns |  5.40 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,309.7 ns |  5.30 ns |  4.70 ns |  0.95 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   246.7 ns |  1.16 ns |  1.03 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,430.2 ns |  3.68 ns |  3.07 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   592.9 ns |  3.64 ns |  3.22 ns |  0.41 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   668.1 ns |  1.79 ns |  1.59 ns |  0.47 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,788.7 ns | 13.25 ns | 11.07 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,136.0 ns | 13.36 ns | 11.85 ns |  1.07 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,384.4 ns |  5.79 ns |  4.83 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,292.5 ns |  4.30 ns |  3.59 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,279.8 ns |  7.65 ns |  6.39 ns |  0.92 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,404.8 ns |  6.73 ns |  5.97 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,286.7 ns |  3.31 ns |  3.10 ns |  0.92 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,255.1 ns |  3.37 ns |  3.15 ns |  0.89 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,379.1 ns |  4.52 ns |  4.01 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,288.6 ns |  5.30 ns |  4.70 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   675.4 ns |  2.44 ns |  2.28 ns |  0.49 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,819.7 ns | 23.74 ns | 22.20 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,155.6 ns | 15.89 ns | 12.40 ns |  1.07 | 0.0153 |     - |     - |      32 B |
