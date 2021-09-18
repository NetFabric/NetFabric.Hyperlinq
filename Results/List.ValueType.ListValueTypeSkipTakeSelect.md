## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |  1.662 μs | 0.0062 μs | 0.0055 μs |      baseline |         |       - |       - |         - |
|                     Linq | 1000 |   100 |  2.346 μs | 0.0064 μs | 0.0057 μs |  1.41x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster | 1000 |   100 |  5.056 μs | 0.0223 μs | 0.0186 μs |  3.04x slower |   0.02x |  9.2545 |       - |  19,368 B |
|             LinqFasterer | 1000 |   100 |  8.757 μs | 0.0845 μs | 0.0749 μs |  5.27x slower |   0.05x | 39.2151 |       - |  83,304 B |
|                   LinqAF | 1000 |   100 | 10.102 μs | 0.0706 μs | 0.0661 μs |  6.08x slower |   0.04x |       - |       - |         - |
|            LinqOptimizer | 1000 |   100 | 75.088 μs | 0.6592 μs | 0.6166 μs | 45.16x slower |   0.41x | 72.6318 | 18.0664 | 161,841 B |
|                 SpanLinq | 1000 |   100 |  2.259 μs | 0.0074 μs | 0.0069 μs |  1.36x slower |   0.01x |       - |       - |         - |
|                  Streams | 1000 |   100 | 11.545 μs | 0.0682 μs | 0.0638 μs |  6.95x slower |   0.05x |  0.5493 |       - |   1,176 B |
|               StructLinq | 1000 |   100 |  1.943 μs | 0.0029 μs | 0.0024 μs |  1.17x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.625 μs | 0.0032 μs | 0.0030 μs |  1.02x faster |   0.00x |       - |       - |         - |
|                Hyperlinq | 1000 |   100 |  1.930 μs | 0.0022 μs | 0.0017 μs |  1.16x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.731 μs | 0.0041 μs | 0.0038 μs |  1.04x slower |   0.00x |       - |       - |         - |
