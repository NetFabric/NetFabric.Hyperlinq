## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  68.56 ns | 2.122 ns |  6.021 ns |  67.31 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 |  71.26 ns | 1.539 ns |  3.776 ns |  70.92 ns | 1.03x slower |   0.07x |      - |         - |
|                     Linq |   100 |  39.61 ns | 0.902 ns |  1.532 ns |  39.73 ns | 1.81x faster |   0.18x |      - |         - |
|               LinqFaster |   100 |  25.43 ns | 4.676 ns | 13.787 ns |  15.25 ns | 3.27x faster |   1.34x |      - |         - |
|          LinqFaster_SIMD |   100 |  14.17 ns | 0.129 ns |  0.121 ns |  14.09 ns | 5.50x faster |   0.42x |      - |         - |
|             LinqFasterer |   100 |  22.79 ns | 0.129 ns |  0.114 ns |  22.73 ns | 3.45x faster |   0.23x |      - |         - |
|                   LinqAF |   100 |  28.38 ns | 0.112 ns |  0.105 ns |  28.33 ns | 2.74x faster |   0.20x |      - |         - |
|               StructLinq |   100 | 162.04 ns | 0.454 ns |  0.379 ns | 161.99 ns | 2.05x slower |   0.12x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |  71.44 ns | 0.172 ns |  0.144 ns |  71.38 ns | 1.11x faster |   0.06x |      - |         - |
|                Hyperlinq |   100 |  34.38 ns | 0.758 ns |  1.202 ns |  33.65 ns | 2.10x faster |   0.15x | 0.0153 |      32 B |
|           Hyperlinq_SIMD |   100 |  24.70 ns | 0.056 ns |  0.050 ns |  24.67 ns | 3.18x faster |   0.21x |      - |         - |
