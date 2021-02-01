## WhereSelectBenchmarks

### Source
[WhereSelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectBenchmarks.cs)

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
|                      Linq_Array |                Array |   100 |   640.4 ns | 3.21 ns | 2.84 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                StructLinq_Array |                Array |   100 |   381.8 ns | 1.63 ns | 1.36 ns |  0.60 |      - |     - |     - |         - |
|                 Hyperlinq_Array |                Array |   100 |   352.3 ns | 1.15 ns | 1.02 ns |  0.55 |      - |     - |     - |         - |
|                  Hyperlinq_Span |                Array |   100 |   369.2 ns | 1.12 ns | 1.05 ns |  0.58 |      - |     - |     - |         - |
|                Hyperlinq_Memory |                Array |   100 |   412.5 ns | 1.53 ns | 1.35 ns |  0.64 |      - |     - |     - |         - |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|           Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,569.9 ns | 6.34 ns | 5.93 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Enumerable_Value |     Enumerable_Value |   100 | 1,353.8 ns | 3.07 ns | 2.87 ns |  0.86 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   385.8 ns | 0.86 ns | 0.80 ns |  0.25 |      - |     - |     - |         - |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|           Linq_Collection_Value |     Collection_Value |   100 | 1,516.2 ns | 2.88 ns | 2.69 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Collection_Value |     Collection_Value |   100 | 1,337.8 ns | 2.35 ns | 1.83 ns |  0.88 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Value |     Collection_Value |   100 |   403.9 ns | 2.13 ns | 1.99 ns |  0.27 |      - |     - |     - |         - |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|                 Linq_List_Value |           List_Value |   100 | 1,512.4 ns | 2.71 ns | 2.53 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|           StructLinq_List_Value |           List_Value |   100 |   773.6 ns | 2.41 ns | 2.01 ns |  0.51 |      - |     - |     - |         - |
|            Hyperlinq_List_Value |           List_Value |   100 |   777.2 ns | 1.50 ns | 1.33 ns |  0.51 |      - |     - |     - |         - |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|       Linq_Enumerable_Reference | Enumerable_Reference |   100 | 1,272.0 ns | 3.50 ns | 3.10 ns |  1.00 | 0.0725 |     - |     - |     152 B |
| StructLinq_Enumerable_Reference | Enumerable_Reference |   100 |   844.9 ns | 1.79 ns | 1.59 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|  Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   875.6 ns | 1.50 ns | 1.25 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|       Linq_Collection_Reference | Collection_Reference |   100 | 1,268.0 ns | 4.18 ns | 3.70 ns |  1.00 | 0.0725 |     - |     - |     152 B |
| StructLinq_Collection_Reference | Collection_Reference |   100 |   864.3 ns | 1.90 ns | 1.48 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|  Hyperlinq_Collection_Reference | Collection_Reference |   100 |   820.6 ns | 2.38 ns | 2.11 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|                                 |                      |       |            |         |         |       |        |       |       |           |
|             Linq_List_Reference |       List_Reference |   100 | 1,233.5 ns | 4.33 ns | 3.61 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|       StructLinq_List_Reference |       List_Reference |   100 |   845.7 ns | 3.21 ns | 2.84 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference |       List_Reference |   100 |   743.3 ns | 1.70 ns | 1.42 ns |  0.60 |      - |     - |     - |         - |
