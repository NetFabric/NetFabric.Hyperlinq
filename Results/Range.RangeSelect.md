## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|                   Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |     0 |   100 |  48.91 ns | 0.127 ns | 0.119 ns |     baseline |         |      - |         - |
|                     Linq |     0 |   100 | 412.42 ns | 1.148 ns | 1.074 ns | 8.43x slower |   0.02x | 0.0420 |      88 B |
|               LinqFaster |     0 |   100 | 367.04 ns | 3.022 ns | 2.827 ns | 7.51x slower |   0.06x | 0.4053 |     848 B |
|          LinqFaster_SIMD |     0 |   100 | 180.23 ns | 3.316 ns | 3.102 ns | 3.69x slower |   0.07x | 0.4053 |     848 B |
|                   LinqAF |     0 |   100 | 234.82 ns | 0.879 ns | 0.779 ns | 4.80x slower |   0.02x |      - |         - |
|               StructLinq |     0 |   100 | 194.79 ns | 0.962 ns | 0.900 ns | 3.98x slower |   0.02x | 0.0114 |      24 B |
| StructLinq_ValueDelegate |     0 |   100 | 180.21 ns | 0.277 ns | 0.259 ns | 3.68x slower |   0.01x |      - |         - |
|                Hyperlinq |     0 |   100 | 200.16 ns | 0.816 ns | 0.764 ns | 4.09x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |     0 |   100 | 186.71 ns | 0.299 ns | 0.265 ns | 3.82x slower |   0.01x |      - |         - |
