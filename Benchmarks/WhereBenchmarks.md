## WhereBenchmarks

### Source
[WhereBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereBenchmarks.cs)

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
|                          Method |           Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------- |--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                      Linq_Array |                Array |   100 |   476.2 ns | 3.07 ns | 2.56 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                StructLinq_Array |                Array |   100 |   265.0 ns | 0.52 ns | 0.44 ns |  0.56 |      - |     - |     - |         - |
|                 Hyperlinq_Array |                Array |   100 |   271.2 ns | 2.27 ns | 1.90 ns |  0.57 |      - |     - |     - |         - |
|                  Hyperlinq_Span |                Array |   100 |   326.3 ns | 4.87 ns | 4.06 ns |  0.69 |      - |     - |     - |         - |
|                Hyperlinq_Memory |                Array |   100 |   368.9 ns | 5.80 ns | 5.42 ns |  0.77 |      - |     - |     - |         - |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|           Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,348.2 ns | 2.99 ns | 2.65 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Value |     Enumerable_Value |   100 | 1,202.2 ns | 2.45 ns | 2.29 ns |  0.89 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   262.4 ns | 0.87 ns | 0.82 ns |  0.19 |      - |     - |     - |         - |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|           Linq_Collection_Value |     Collection_Value |   100 | 1,386.8 ns | 2.80 ns | 2.34 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Value |     Collection_Value |   100 | 1,244.6 ns | 4.08 ns | 3.82 ns |  0.90 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Value |     Collection_Value |   100 |   272.1 ns | 0.74 ns | 0.62 ns |  0.20 |      - |     - |     - |         - |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|                 Linq_List_Value |           List_Value |   100 | 1,341.1 ns | 5.56 ns | 4.93 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Value |           List_Value |   100 |   660.3 ns | 3.05 ns | 2.71 ns |  0.49 |      - |     - |     - |         - |
|            Hyperlinq_List_Value |           List_Value |   100 |   592.8 ns | 1.64 ns | 1.54 ns |  0.44 |      - |     - |     - |         - |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|       Linq_Enumerable_Reference | Enumerable_Reference |   100 | 1,003.0 ns | 2.76 ns | 2.45 ns |  1.00 | 0.0420 |     - |     - |      88 B |
| StructLinq_Enumerable_Reference | Enumerable_Reference |   100 |   714.5 ns | 1.51 ns | 1.41 ns |  0.71 | 0.0153 |     - |     - |      32 B |
|  Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   727.9 ns | 3.31 ns | 3.10 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|       Linq_Collection_Reference | Collection_Reference |   100 | 1,006.5 ns | 4.95 ns | 4.63 ns |  1.00 | 0.0420 |     - |     - |      88 B |
| StructLinq_Collection_Reference | Collection_Reference |   100 |   694.3 ns | 1.96 ns | 1.73 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|  Hyperlinq_Collection_Reference | Collection_Reference |   100 |   727.1 ns | 3.24 ns | 2.87 ns |  0.72 | 0.0153 |     - |     - |      32 B |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|             Linq_List_Reference |       List_Reference |   100 | 1,006.5 ns | 2.92 ns | 2.58 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|       StructLinq_List_Reference |       List_Reference |   100 |   705.6 ns | 2.00 ns | 1.77 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference |       List_Reference |   100 |   578.6 ns | 2.52 ns | 2.24 ns |  0.57 |      - |     - |     - |         - |
