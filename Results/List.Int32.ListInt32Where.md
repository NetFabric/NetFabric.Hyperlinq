## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 132.9 ns | 0.11 ns | 0.09 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 360.7 ns | 0.21 ns | 0.18 ns |  2.71 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 776.7 ns | 3.19 ns | 2.83 ns |  5.85 |    0.02 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 466.2 ns | 0.78 ns | 0.61 ns |  3.51 |    0.01 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 790.2 ns | 1.60 ns | 1.42 ns |  5.94 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 327.0 ns | 1.35 ns | 1.26 ns |  2.46 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 176.5 ns | 0.24 ns | 0.22 ns |  1.33 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 376.4 ns | 0.83 ns | 0.78 ns |  2.83 |    0.01 |      - |     - |     - |         - |
