## ArrayIterationBenchmarks

### Source
[ArrayIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayIterationBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.7.21377.19
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta45](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta45)

### Results:
``` ini

BenchmarkDotNet=v0.13.1.1606-nightly, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|               Method |   Count |       Mean |    Error |   StdDev |        Ratio | RatioSD | Allocated |
|--------------------- |-------- |-----------:|---------:|---------:|-------------:|--------:|----------:|
|              Foreach | 1000000 |   459.6 μs |  2.49 μs |  1.95 μs |     baseline |         |      13 B |
|                  For | 1000000 |   460.4 μs |  2.37 μs |  2.21 μs | 1.00x slower |   0.01x |         - |
|           For_Unsafe | 1000000 |   460.7 μs |  2.86 μs |  2.54 μs | 1.00x slower |   0.00x |         - |
|       ForAdamczewski | 1000000 |   386.4 μs |  2.78 μs |  2.60 μs | 1.19x faster |   0.01x |         - |
| ForAdamczewskiUnsafe | 1000000 |   387.7 μs |  4.10 μs |  3.84 μs | 1.18x faster |   0.01x |         - |
|                 Span | 1000000 |   460.5 μs |  2.08 μs |  1.85 μs | 1.00x slower |   0.01x |         - |
| ArraySegment_Foreach | 1000000 | 1,746.3 μs | 12.53 μs | 11.72 μs | 3.80x slower |   0.02x |       1 B |
|     ArraySegment_For | 1000000 |   646.1 μs |  7.65 μs |  6.39 μs | 1.41x slower |   0.01x |         - |
|  ArraySegment_AsSpan | 1000000 |   461.5 μs |  3.82 μs |  3.19 μs | 1.00x slower |   0.01x |       1 B |
| ArraySegment_AsArray | 1000000 |   626.8 μs |  3.41 μs |  3.03 μs | 1.36x slower |   0.01x |       1 B |
|               Vector | 1000000 |   119.9 μs |  1.72 μs |  1.61 μs | 3.83x faster |   0.06x |         - |
