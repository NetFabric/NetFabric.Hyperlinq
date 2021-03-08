## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   688.3 ns |  3.32 ns |  3.10 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   224.9 ns |  1.47 ns |  1.23 ns |  0.33 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |   100 |   233.3 ns |  1.29 ns |  1.21 ns |  0.34 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |   100 |   239.1 ns |  1.35 ns |  1.19 ns |  0.35 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |   100 |   226.0 ns |  1.37 ns |  1.21 ns |  0.33 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |   100 |   216.5 ns |  1.07 ns |  0.89 ns |  0.31 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |   100 |   312.7 ns |  1.43 ns |  1.27 ns |  0.45 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |   100 |   250.5 ns |  1.33 ns |  1.11 ns |  0.36 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,346.0 ns |  4.76 ns |  4.46 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   835.8 ns |  4.28 ns |  3.79 ns |  0.62 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   247.7 ns |  0.83 ns |  0.73 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,305.1 ns |  3.70 ns |  3.09 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   835.4 ns |  2.70 ns |  2.26 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   217.7 ns |  0.78 ns |  0.69 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,259.9 ns |  4.45 ns |  4.16 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   387.3 ns |  1.78 ns |  1.66 ns |  0.31 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |   100 |   414.9 ns |  2.64 ns |  2.34 ns |  0.33 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |   100 |   432.7 ns |  1.46 ns |  1.22 ns |  0.34 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,388.7 ns | 32.15 ns | 28.50 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,036.9 ns | 26.64 ns | 24.92 ns |  0.72 | 0.1373 |     - |     - |     288 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   999.7 ns |  2.93 ns |  2.60 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   541.4 ns |  1.90 ns |  1.69 ns |  0.54 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   552.7 ns |  6.03 ns |  5.35 ns |  0.55 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,027.5 ns |  4.63 ns |  4.11 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   594.1 ns |  1.88 ns |  1.57 ns |  0.58 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   595.8 ns |  1.95 ns |  1.72 ns |  0.58 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,033.0 ns |  5.23 ns |  4.89 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   593.2 ns |  3.68 ns |  3.45 ns |  0.57 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |   100 |   418.8 ns |  1.83 ns |  1.62 ns |  0.41 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |   100 |   454.1 ns |  0.68 ns |  0.64 ns |  0.44 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,598.4 ns | 43.27 ns | 36.14 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,193.7 ns | 27.90 ns | 24.73 ns |  0.72 | 0.1373 |     - |     - |     296 B |
