## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  48.82 ns | 0.170 ns | 0.142 ns |  48.74 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 |  49.43 ns | 0.175 ns | 0.164 ns |  49.34 ns | 1.01x slower |   0.01x |      - |         - |
|                     Linq |   100 |  22.64 ns | 0.517 ns | 1.113 ns |  22.03 ns | 1.99x faster |   0.01x |      - |         - |
|             LinqFasterer |   100 |  70.30 ns | 0.517 ns | 0.483 ns |  70.18 ns | 1.44x slower |   0.01x | 0.2142 |     448 B |
|               StructLinq |   100 | 105.90 ns | 0.349 ns | 0.309 ns | 105.84 ns | 2.17x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  87.16 ns | 0.284 ns | 0.252 ns |  87.02 ns | 1.79x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 |  30.81 ns | 0.110 ns | 0.092 ns |  30.80 ns | 1.58x faster |   0.01x |      - |         - |
|           Hyperlinq_SIMD |   100 |  24.84 ns | 0.075 ns | 0.070 ns |  24.81 ns | 1.97x faster |   0.01x |      - |         - |
