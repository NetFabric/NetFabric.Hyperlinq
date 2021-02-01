## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                           Method |           Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------- |--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                       Linq_Array |                Array |   100 |   640.9 ns | 1.58 ns | 1.48 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                 StructLinq_Array |                Array |   100 |   210.7 ns | 0.48 ns | 0.42 ns |  0.33 |      - |     - |     - |         - |
|              Hyperlinq_Array_For |                Array |   100 |   216.8 ns | 0.42 ns | 0.38 ns |  0.34 |      - |     - |     - |         - |
|          Hyperlinq_Array_Foreach |                Array |   100 |   217.1 ns | 0.44 ns | 0.41 ns |  0.34 |      - |     - |     - |         - |
|               Hyperlinq_Span_For |                Array |   100 |   183.4 ns | 0.27 ns | 0.22 ns |  0.29 |      - |     - |     - |         - |
|           Hyperlinq_Span_Foreach |                Array |   100 |   258.6 ns | 0.69 ns | 0.58 ns |  0.40 |      - |     - |     - |         - |
|             Hyperlinq_Memory_For |                Array |   100 |   290.9 ns | 0.61 ns | 0.51 ns |  0.45 |      - |     - |     - |         - |
|         Hyperlinq_Memory_Foreach |                Array |   100 |   224.2 ns | 0.36 ns | 0.32 ns |  0.35 |      - |     - |     - |         - |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|            Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,222.6 ns | 7.88 ns | 6.58 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|      StructLinq_Enumerable_Value |     Enumerable_Value |   100 |   743.9 ns | 2.09 ns | 1.85 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   204.4 ns | 0.42 ns | 0.40 ns |  0.17 |      - |     - |     - |         - |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|            Linq_Collection_Value |     Collection_Value |   100 | 1,226.0 ns | 3.26 ns | 2.89 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|      StructLinq_Collection_Value |     Collection_Value |   100 |   777.9 ns | 1.39 ns | 1.23 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Collection_Value |     Collection_Value |   100 |   205.8 ns | 0.30 ns | 0.25 ns |  0.17 |      - |     - |     - |         - |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|                  Linq_List_Value |           List_Value |   100 | 1,220.9 ns | 4.65 ns | 4.12 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|            StructLinq_List_Value |           List_Value |   100 |   434.3 ns | 0.70 ns | 0.66 ns |  0.36 |      - |     - |     - |         - |
|         Hyperlinq_List_Value_For |           List_Value |   100 |   422.8 ns | 0.80 ns | 0.71 ns |  0.35 |      - |     - |     - |         - |
|     Hyperlinq_List_Value_Foreach |           List_Value |   100 |   404.2 ns | 0.57 ns | 0.48 ns |  0.33 |      - |     - |     - |         - |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|        Linq_Enumerable_Reference | Enumerable_Reference |   100 |   954.6 ns | 3.21 ns | 2.85 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|  StructLinq_Enumerable_Reference | Enumerable_Reference |   100 |   514.6 ns | 1.70 ns | 1.59 ns |  0.54 | 0.0153 |     - |     - |      32 B |
|   Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   563.0 ns | 0.82 ns | 0.76 ns |  0.59 | 0.0153 |     - |     - |      32 B |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|        Linq_Collection_Reference | Collection_Reference |   100 |   935.6 ns | 0.94 ns | 0.83 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|  StructLinq_Collection_Reference | Collection_Reference |   100 |   511.1 ns | 1.22 ns | 1.14 ns |  0.55 | 0.0153 |     - |     - |      32 B |
|   Hyperlinq_Collection_Reference | Collection_Reference |   100 |   587.5 ns | 1.63 ns | 1.45 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|              Linq_List_Reference |       List_Reference |   100 |   968.7 ns | 3.15 ns | 2.94 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|        StructLinq_List_Reference |       List_Reference |   100 |   562.5 ns | 1.23 ns | 1.15 ns |  0.58 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_List_Reference_For |       List_Reference |   100 |   373.2 ns | 1.13 ns | 1.00 ns |  0.39 |      - |     - |     - |         - |
| Hyperlinq_List_Reference_Foreach |       List_Reference |   100 |   404.0 ns | 0.77 ns | 0.64 ns |  0.42 |      - |     - |     - |         - |
