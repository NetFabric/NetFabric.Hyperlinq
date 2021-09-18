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
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                  ForLoop |   100 | 493.5 ns | 0.30 ns | 0.27 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 | 493.7 ns | 0.50 ns | 0.42 ns | 1.00x slower |   0.00x |      - |         - |
|                     Linq |   100 | 141.6 ns | 0.14 ns | 0.12 ns | 3.48x faster |   0.00x |      - |         - |
|               LinqFaster |   100 | 170.1 ns | 0.15 ns | 0.14 ns | 2.90x faster |   0.00x |      - |         - |
|             LinqFasterer |   100 | 141.8 ns | 0.32 ns | 0.25 ns | 3.48x faster |   0.01x |      - |         - |
|                   LinqAF |   100 | 149.7 ns | 0.43 ns | 0.38 ns | 3.30x faster |   0.01x |      - |         - |
|               StructLinq |   100 | 532.2 ns | 0.67 ns | 0.56 ns | 1.08x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 | 543.4 ns | 0.18 ns | 0.16 ns | 1.10x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 | 151.5 ns | 0.23 ns | 0.20 ns | 3.26x faster |   0.00x | 0.0153 |      32 B |
