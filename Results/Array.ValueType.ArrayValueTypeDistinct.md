## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |          4 |   100 | 11.625 μs | 0.0280 μs | 0.0219 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |          4 |   100 | 12.102 μs | 0.0332 μs | 0.0310 μs | 1.04x slower |   0.00x | 12.8784 |  26,976 B |
|                     Linq |          4 |   100 | 14.878 μs | 0.0142 μs | 0.0110 μs | 1.28x slower |   0.00x | 12.8174 |  26,848 B |
|             LinqFasterer |          4 |   100 | 15.346 μs | 0.0323 μs | 0.0286 μs | 1.32x slower |   0.00x | 22.6135 |  47,544 B |
|                   LinqAF |          4 |   100 | 42.733 μs | 0.1199 μs | 0.1063 μs | 3.67x slower |   0.01x | 20.6299 |  43,216 B |
|               StructLinq |          4 |   100 | 12.319 μs | 0.0272 μs | 0.0227 μs | 1.06x slower |   0.00x |  0.0153 |      56 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.129 μs | 0.0044 μs | 0.0041 μs | 2.27x faster |   0.00x |       - |         - |
|                Hyperlinq |          4 |   100 | 11.398 μs | 0.0134 μs | 0.0112 μs | 1.02x faster |   0.00x |       - |         - |
