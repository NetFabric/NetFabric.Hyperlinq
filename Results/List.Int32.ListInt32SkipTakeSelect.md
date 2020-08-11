## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    68.53 ns |  0.027 ns |  0.022 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,127.11 ns |  3.799 ns |  3.172 ns | 74.82 |    0.06 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,192.86 ns |  1.397 ns |  1.167 ns | 17.41 |    0.02 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   924.34 ns |  1.163 ns |  0.971 ns | 13.49 |    0.01 | 0.6542 |     - |     - |    1368 B |
|               LinqAF | 1000 |   100 | 6,413.21 ns | 18.613 ns | 17.411 ns | 93.61 |    0.26 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,137.53 ns |  3.427 ns |  3.206 ns | 16.59 |    0.05 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,008.64 ns |  2.009 ns |  1.678 ns | 14.72 |    0.03 | 0.0458 |     - |     - |      96 B |
|    Hyperlinq_Foreach | 1000 |   100 |   300.67 ns |  0.134 ns |  0.118 ns |  4.39 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   382.34 ns |  0.155 ns |  0.121 ns |  5.58 |    0.00 |      - |     - |     - |         - |
