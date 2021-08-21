## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 117.59 ns | 0.084 ns | 0.065 ns |     baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 | 121.04 ns | 0.048 ns | 0.038 ns | 1.03x slower |   0.00x |      - |     - |     - |         - |
|                     Linq |   100 |  23.93 ns | 0.052 ns | 0.049 ns | 4.92x faster |   0.01x |      - |     - |     - |         - |
|               LinqFaster |   100 |  26.24 ns | 0.028 ns | 0.024 ns | 4.48x faster |   0.01x |      - |     - |     - |         - |
|             LinqFasterer |   100 |  67.53 ns | 0.104 ns | 0.092 ns | 1.74x faster |   0.00x | 0.2027 |     - |     - |     424 B |
|                   LinqAF |   100 |  23.89 ns | 0.012 ns | 0.010 ns | 4.92x faster |   0.00x |      - |     - |     - |         - |
|               StructLinq |   100 |  98.44 ns | 0.054 ns | 0.042 ns | 1.19x faster |   0.00x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  91.97 ns | 1.835 ns | 1.433 ns | 1.28x faster |   0.02x |      - |     - |     - |         - |
|                Hyperlinq |   100 |  31.27 ns | 0.054 ns | 0.045 ns | 3.76x faster |   0.01x |      - |     - |     - |         - |
|           Hyperlinq_SIMD |   100 |  25.53 ns | 0.032 ns | 0.028 ns | 4.61x faster |   0.01x |      - |     - |     - |         - |
