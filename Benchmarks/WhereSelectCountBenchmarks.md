## WhereSelectCountBenchmarks

### Source
[WhereSelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectCountBenchmarks.cs)

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
|                         Method |           Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |   356.2 ns | 2.14 ns | 1.79 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                Hyperlinq_Array |                Array |   100 |   179.2 ns | 1.60 ns | 1.42 ns |  0.50 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |   205.2 ns | 2.00 ns | 1.87 ns |  0.58 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |   233.8 ns | 1.40 ns | 1.17 ns |  0.66 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,194.9 ns | 9.13 ns | 8.54 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   234.8 ns | 1.88 ns | 1.76 ns |  0.20 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 1,263.4 ns | 7.12 ns | 6.66 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |   287.5 ns | 1.70 ns | 1.59 ns |  0.23 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 1,265.3 ns | 7.93 ns | 7.03 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|           Hyperlinq_List_Value |           List_Value |   100 |   375.1 ns | 2.46 ns | 2.18 ns |  0.30 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 |   821.7 ns | 5.60 ns | 4.96 ns |  1.00 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   564.9 ns | 2.82 ns | 2.50 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |   820.1 ns | 6.00 ns | 5.32 ns |  1.00 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   532.9 ns | 3.71 ns | 3.47 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   852.0 ns | 4.53 ns | 4.24 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   448.9 ns | 2.84 ns | 2.66 ns |  0.53 |      - |     - |     - |         - |
