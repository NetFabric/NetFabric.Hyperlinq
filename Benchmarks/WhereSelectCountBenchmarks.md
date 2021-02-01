## WhereSelectCountBenchmarks

### Source
[WhereSelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectCountBenchmarks.cs)

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
|                         Method |           Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |   364.1 ns | 1.84 ns | 1.72 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                Hyperlinq_Array |                Array |   100 |   176.1 ns | 0.33 ns | 0.29 ns |  0.48 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |   220.7 ns | 0.39 ns | 0.34 ns |  0.61 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |   176.2 ns | 0.28 ns | 0.26 ns |  0.48 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,221.4 ns | 2.74 ns | 2.43 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   241.2 ns | 0.45 ns | 0.39 ns |  0.20 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 1,221.1 ns | 1.07 ns | 0.83 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |   263.9 ns | 1.00 ns | 0.94 ns |  0.22 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 1,203.9 ns | 2.59 ns | 2.16 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|           Hyperlinq_List_Value |           List_Value |   100 |   387.2 ns | 0.62 ns | 0.55 ns |  0.32 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 |   874.0 ns | 4.20 ns | 3.72 ns |  1.00 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   569.5 ns | 1.61 ns | 1.43 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |   863.5 ns | 3.63 ns | 3.21 ns |  1.00 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   517.9 ns | 0.95 ns | 0.89 ns |  0.60 | 0.0153 |     - |     - |      32 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   864.5 ns | 2.02 ns | 1.89 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   365.0 ns | 1.01 ns | 0.94 ns |  0.42 |      - |     - |     - |         - |
