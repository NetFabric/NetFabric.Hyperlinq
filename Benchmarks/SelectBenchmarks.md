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
|                          Linq_Array |                     Array |   100 |   675.5 ns |  2.41 ns |  2.01 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   213.5 ns |  0.41 ns |  0.36 ns |  0.32 |      - |     - |     - |         - |
|                 Hyperlinq_Array_For |                     Array |   100 |   223.6 ns |  0.45 ns |  0.40 ns |  0.33 |      - |     - |     - |         - |
|             Hyperlinq_Array_Foreach |                     Array |   100 |   238.4 ns |  0.80 ns |  0.71 ns |  0.35 |      - |     - |     - |         - |
|                  Hyperlinq_Span_For |                     Array |   100 |   195.3 ns |  0.53 ns |  0.42 ns |  0.29 |      - |     - |     - |         - |
|              Hyperlinq_Span_Foreach |                     Array |   100 |   205.2 ns |  0.45 ns |  0.40 ns |  0.30 |      - |     - |     - |         - |
|                Hyperlinq_Memory_For |                     Array |   100 |   297.8 ns |  0.87 ns |  0.82 ns |  0.44 |      - |     - |     - |         - |
|            Hyperlinq_Memory_Foreach |                     Array |   100 |   235.1 ns |  0.71 ns |  0.63 ns |  0.35 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,204.2 ns |  2.61 ns |  2.18 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   752.8 ns |  2.53 ns |  2.37 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   230.0 ns |  0.98 ns |  0.92 ns |  0.19 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,244.2 ns |  3.32 ns |  2.77 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   794.3 ns |  3.15 ns |  2.63 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   206.4 ns |  0.59 ns |  0.52 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,192.9 ns |  4.07 ns |  3.61 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |   366.8 ns |  1.36 ns |  1.21 ns |  0.31 |      - |     - |     - |         - |
|            Hyperlinq_List_Value_For |                List_Value |   100 |   401.5 ns |  2.25 ns |  3.82 ns |  0.34 |      - |     - |     - |         - |
|        Hyperlinq_List_Value_Foreach |                List_Value |   100 |   434.5 ns |  0.94 ns |  0.88 ns |  0.36 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,932.5 ns | 23.60 ns | 19.71 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,995.1 ns | 17.30 ns | 15.34 ns |  0.76 | 0.1373 |     - |     - |     296 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   949.1 ns |  4.28 ns |  4.00 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   515.1 ns |  1.19 ns |  1.06 ns |  0.54 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   525.6 ns |  2.39 ns |  2.12 ns |  0.55 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   926.3 ns |  2.49 ns |  2.21 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   546.0 ns |  3.29 ns |  2.91 ns |  0.59 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   590.1 ns |  1.49 ns |  1.32 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   952.4 ns |  2.76 ns |  2.58 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   566.8 ns |  1.88 ns |  1.57 ns |  0.60 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference_For |            List_Reference |   100 |   376.6 ns |  0.99 ns |  0.83 ns |  0.40 |      - |     - |     - |         - |
|    Hyperlinq_List_Reference_Foreach |            List_Reference |   100 |   386.1 ns |  0.71 ns |  0.59 ns |  0.41 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,930.6 ns | 20.78 ns | 17.35 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,877.5 ns | 17.01 ns | 15.08 ns |  0.74 | 0.1373 |     - |     - |     296 B |
