## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   129.5 ns |  0.18 ns |  0.16 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,432.2 ns |  3.94 ns |  3.29 ns | 41.94 |    0.05 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,450.0 ns |  2.73 ns |  2.28 ns | 11.20 |    0.02 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   912.3 ns |  4.91 ns |  4.35 ns |  7.04 |    0.03 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 6,422.8 ns | 24.28 ns | 22.71 ns | 49.58 |    0.19 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,235.9 ns |  3.08 ns |  2.57 ns |  9.54 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,113.7 ns |  3.19 ns |  2.98 ns |  8.60 |    0.02 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq | 1000 |   100 |   330.8 ns |  0.18 ns |  0.15 ns |  2.55 |    0.00 |      - |     - |     - |         - |
