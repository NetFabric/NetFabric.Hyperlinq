## ArrayIterationBenchmarks

### Source
[ArrayIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayIterationBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1081 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-IRYCMS : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|               Method |   Count |       Mean |    Error |  StdDev |        Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------- |-----------:|---------:|--------:|-------------:|--------:|------:|------:|------:|----------:|
|              Foreach | 1000000 |   424.2 μs |  5.91 μs | 5.53 μs |     baseline |         |     - |     - |     - |         - |
|                  For | 1000000 |   428.7 μs |  2.69 μs | 2.52 μs | 1.01x slower |   0.01x |     - |     - |     - |         - |
|           For_Unsafe | 1000000 |   412.9 μs |  3.31 μs | 2.76 μs | 1.03x faster |   0.01x |     - |     - |     - |         - |
|       ForAdamczewski | 1000000 |   404.1 μs |  2.42 μs | 2.26 μs | 1.05x faster |   0.02x |     - |     - |     - |         - |
| ForAdamczewskiUnsafe | 1000000 |   355.1 μs |  3.48 μs | 3.25 μs | 1.19x faster |   0.02x |     - |     - |     - |         - |
|                 Span | 1000000 |   411.8 μs |  2.92 μs | 2.28 μs | 1.03x faster |   0.01x |     - |     - |     - |         - |
| ArraySegment_Foreach | 1000000 | 2,800.7 μs | 10.24 μs | 9.08 μs | 6.60x slower |   0.09x |     - |     - |     - |       1 B |
|     ArraySegment_For | 1000000 |   805.2 μs |  4.48 μs | 4.19 μs | 1.90x slower |   0.02x |     - |     - |     - |         - |
|  ArraySegment_AsSpan | 1000000 |   412.4 μs |  2.08 μs | 1.74 μs | 1.03x faster |   0.01x |     - |     - |     - |         - |
| ArraySegment_AsArray | 1000000 |   798.7 μs |  4.39 μs | 3.67 μs | 1.88x slower |   0.03x |     - |     - |     - |         - |
