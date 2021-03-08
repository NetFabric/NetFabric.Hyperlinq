## WhereBenchmarks

### Source
[WhereBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   491.2 ns |  3.52 ns |  3.12 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   267.2 ns |  1.34 ns |  1.18 ns |  0.54 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   271.0 ns |  1.47 ns |  1.30 ns |  0.55 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   269.4 ns |  1.07 ns |  0.83 ns |  0.55 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   271.3 ns |  1.91 ns |  1.69 ns |  0.55 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,372.9 ns |  6.32 ns |  5.61 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,271.1 ns |  6.81 ns |  6.04 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,237.1 ns |  6.36 ns |  5.64 ns |  0.90 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,370.9 ns |  5.69 ns |  4.75 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,276.3 ns |  6.67 ns |  5.91 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1,251.4 ns | 10.48 ns |  9.29 ns |  0.91 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,375.4 ns |  6.34 ns |  5.93 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   621.7 ns |  2.39 ns |  2.23 ns |  0.45 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   694.6 ns |  3.85 ns |  3.22 ns |  0.50 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,404.1 ns | 20.82 ns | 19.47 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,635.9 ns | 34.38 ns | 30.47 ns |  1.04 | 0.0687 |     - |     - |     152 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,122.8 ns |  6.73 ns |  5.97 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   701.0 ns |  3.02 ns |  2.82 ns |  0.62 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   738.5 ns |  3.54 ns |  3.31 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,022.3 ns |  6.21 ns |  5.81 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   736.8 ns |  4.40 ns |  3.90 ns |  0.72 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   769.7 ns |  4.81 ns |  4.27 ns |  0.75 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   996.4 ns |  5.21 ns |  4.88 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   698.1 ns |  3.23 ns |  2.86 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   671.7 ns |  3.85 ns |  3.22 ns |  0.67 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,321.3 ns | 18.66 ns | 15.58 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,481.6 ns | 23.36 ns | 20.71 ns |  1.03 | 0.0687 |     - |     - |     152 B |
