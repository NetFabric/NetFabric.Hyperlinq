## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|                   Method | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 | 493.4 ns | 1.73 ns | 1.54 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 | 491.7 ns | 1.24 ns | 1.04 ns | 1.00x faster |   0.00x |      - |         - |
|                     Linq |   100 | 141.5 ns | 0.17 ns | 0.13 ns | 3.49x faster |   0.01x |      - |         - |
|               LinqFaster |   100 | 172.0 ns | 0.32 ns | 0.30 ns | 2.87x faster |   0.01x |      - |         - |
|             LinqFasterer |   100 | 142.3 ns | 0.47 ns | 0.44 ns | 3.47x faster |   0.02x |      - |         - |
|                   LinqAF |   100 | 151.5 ns | 0.70 ns | 0.65 ns | 3.26x faster |   0.02x |      - |         - |
|               StructLinq |   100 | 552.5 ns | 3.48 ns | 2.71 ns | 1.12x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 | 544.2 ns | 2.15 ns | 1.91 ns | 1.10x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 | 143.7 ns | 0.55 ns | 0.48 ns | 3.43x faster |   0.02x |      - |         - |
