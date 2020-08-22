## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                           Method |           Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------- |--------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                       Linq_Array |                Array |   100 |   694.7 ns |  3.55 ns |  2.96 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                 StructLinq_Array |                Array |   100 |   252.4 ns |  2.83 ns |  2.36 ns |  0.36 |      - |     - |     - |         - |
|              Hyperlinq_Array_For |                Array |   100 |   281.0 ns |  3.13 ns |  2.77 ns |  0.40 |      - |     - |     - |         - |
|          Hyperlinq_Array_Foreach |                Array |   100 |   321.7 ns |  2.82 ns |  2.64 ns |  0.46 |      - |     - |     - |         - |
|               Hyperlinq_Span_For |                Array |   100 |   280.9 ns |  2.39 ns |  2.12 ns |  0.40 |      - |     - |     - |         - |
|           Hyperlinq_Span_Foreach |                Array |   100 |   310.3 ns |  2.92 ns |  2.44 ns |  0.45 |      - |     - |     - |         - |
|             Hyperlinq_Memory_For |                Array |   100 |   486.4 ns |  5.00 ns |  4.68 ns |  0.70 |      - |     - |     - |         - |
|         Hyperlinq_Memory_Foreach |                Array |   100 |   312.8 ns |  2.52 ns |  2.36 ns |  0.45 |      - |     - |     - |         - |
|                                  |                      |       |            |          |          |       |        |       |       |           |
|            Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,239.1 ns |  4.18 ns |  3.26 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|      StructLinq_Enumerable_Value |     Enumerable_Value |   100 |   795.0 ns |  4.82 ns |  4.27 ns |  0.64 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   396.1 ns |  1.47 ns |  1.31 ns |  0.32 |      - |     - |     - |         - |
|                                  |                      |       |            |          |          |       |        |       |       |           |
|            Linq_Collection_Value |     Collection_Value |   100 | 1,228.2 ns |  6.84 ns |  6.06 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|      StructLinq_Collection_Value |     Collection_Value |   100 |   792.5 ns |  7.22 ns |  6.75 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Collection_Value |     Collection_Value |   100 |   369.3 ns |  2.73 ns |  2.42 ns |  0.30 |      - |     - |     - |         - |
|                                  |                      |       |            |          |          |       |        |       |       |           |
|                  Linq_List_Value |           List_Value |   100 | 1,249.9 ns |  9.66 ns |  8.56 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|            StructLinq_List_Value |           List_Value |   100 |   791.7 ns |  6.10 ns |  5.71 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|         Hyperlinq_List_Value_For |           List_Value |   100 |   521.8 ns |  2.03 ns |  1.90 ns |  0.42 |      - |     - |     - |         - |
|     Hyperlinq_List_Value_Foreach |           List_Value |   100 |   517.9 ns |  2.36 ns |  2.09 ns |  0.41 |      - |     - |     - |         - |
|                                  |                      |       |            |          |          |       |        |       |       |           |
|        Linq_Enumerable_Reference | Enumerable_Reference |   100 |   937.2 ns |  6.02 ns |  5.03 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|  StructLinq_Enumerable_Reference | Enumerable_Reference |   100 |   644.1 ns |  3.57 ns |  3.17 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|   Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   660.3 ns |  2.80 ns |  2.62 ns |  0.71 | 0.0153 |     - |     - |      32 B |
|                                  |                      |       |            |          |          |       |        |       |       |           |
|        Linq_Collection_Reference | Collection_Reference |   100 |   945.4 ns |  5.16 ns |  4.58 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|  StructLinq_Collection_Reference | Collection_Reference |   100 |   660.0 ns | 13.21 ns | 11.71 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|   Hyperlinq_Collection_Reference | Collection_Reference |   100 |   692.6 ns |  2.71 ns |  2.54 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                  |                      |       |            |          |          |       |        |       |       |           |
|              Linq_List_Reference |       List_Reference |   100 |   955.8 ns |  8.22 ns |  6.86 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|        StructLinq_List_Reference |       List_Reference |   100 |   602.3 ns |  5.19 ns |  4.60 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_List_Reference_For |       List_Reference |   100 |   568.9 ns |  3.24 ns |  2.87 ns |  0.60 |      - |     - |     - |         - |
| Hyperlinq_List_Reference_Foreach |       List_Reference |   100 |   497.7 ns |  6.54 ns |  6.12 ns |  0.52 |      - |     - |     - |         - |
