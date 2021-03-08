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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   492.9 ns |  2.71 ns |  2.53 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   273.5 ns |  1.31 ns |  1.23 ns |  0.55 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   283.3 ns |  1.29 ns |  1.21 ns |  0.57 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   278.9 ns |  0.80 ns |  0.75 ns |  0.57 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   268.9 ns |  2.22 ns |  2.08 ns |  0.55 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,428.1 ns |  3.90 ns |  3.26 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,298.4 ns |  4.94 ns |  4.38 ns |  0.91 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   284.4 ns |  1.58 ns |  1.48 ns |  0.20 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,422.6 ns |  4.60 ns |  4.30 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,315.1 ns | 19.72 ns | 23.48 ns |  0.92 |    0.02 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   312.3 ns |  1.51 ns |  1.34 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,392.6 ns |  4.42 ns |  4.14 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   641.3 ns |  2.68 ns |  2.38 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   736.1 ns |  2.29 ns |  2.03 ns |  0.53 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,464.9 ns | 33.09 ns | 27.63 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,722.9 ns | 21.03 ns | 18.64 ns |  1.05 |    0.01 | 0.0687 |     - |     - |     144 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,035.1 ns |  4.77 ns |  3.98 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   730.3 ns |  2.60 ns |  2.43 ns |  0.71 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   763.0 ns |  4.30 ns |  3.82 ns |  0.74 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,013.2 ns |  5.14 ns |  4.56 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   761.0 ns |  2.07 ns |  1.84 ns |  0.75 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   802.3 ns |  3.55 ns |  3.14 ns |  0.79 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,034.8 ns |  4.85 ns |  4.05 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   758.7 ns |  3.37 ns |  2.99 ns |  0.73 |    0.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   696.7 ns |  3.32 ns |  3.10 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,491.6 ns | 23.46 ns | 19.59 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,755.6 ns | 30.65 ns | 23.93 ns |  1.05 |    0.01 | 0.0687 |     - |     - |     152 B |
