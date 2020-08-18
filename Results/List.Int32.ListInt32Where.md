## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

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
|              ForLoop |   100 | 132.6 ns | 0.11 ns | 0.09 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 305.6 ns | 0.85 ns | 0.71 ns |  2.31 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 693.0 ns | 2.45 ns | 2.29 ns |  5.23 |    0.02 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 462.1 ns | 0.83 ns | 0.74 ns |  3.48 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 786.2 ns | 1.28 ns | 1.07 ns |  5.93 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 346.6 ns | 0.52 ns | 0.47 ns |  2.61 |    0.00 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 176.6 ns | 0.44 ns | 0.39 ns |  1.33 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 366.1 ns | 0.66 ns | 0.62 ns |  2.76 |    0.01 |      - |     - |     - |         - |
