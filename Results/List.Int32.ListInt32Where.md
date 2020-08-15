## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

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
|              ForLoop |   100 | 132.6 ns | 0.13 ns | 0.11 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 360.9 ns | 0.36 ns | 0.30 ns |  2.72 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 816.7 ns | 1.47 ns | 1.30 ns |  6.16 |    0.01 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 464.0 ns | 1.35 ns | 1.26 ns |  3.50 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 837.6 ns | 1.95 ns | 1.63 ns |  6.32 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 346.7 ns | 0.40 ns | 0.33 ns |  2.61 |    0.00 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 177.8 ns | 0.22 ns | 0.21 ns |  1.34 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 365.7 ns | 0.60 ns | 0.54 ns |  2.76 |    0.00 |      - |     - |     - |         - |
