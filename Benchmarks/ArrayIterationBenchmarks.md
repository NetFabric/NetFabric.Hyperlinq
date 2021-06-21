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
  Job-UGMGOQ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|               Method |   Count |       Mean |    Error |  StdDev |        Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------- |-----------:|---------:|--------:|-------------:|--------:|------:|------:|------:|----------:|
|              Foreach | 1000000 |   411.6 μs |  3.58 μs | 2.99 μs |     baseline |         |     - |     - |     - |         - |
|                  For | 1000000 |   410.3 μs |  1.57 μs | 1.22 μs | 1.00x faster |   0.01x |     - |     - |     - |         - |
|           For_Unsafe | 1000000 |   411.1 μs |  1.58 μs | 1.48 μs | 1.00x faster |   0.01x |     - |     - |     - |         - |
|       ForAdamczewski | 1000000 |   404.1 μs |  1.83 μs | 1.53 μs | 1.02x faster |   0.01x |     - |     - |     - |         - |
| ForAdamczewskiUnsafe | 1000000 |   411.2 μs |  1.93 μs | 1.71 μs | 1.00x faster |   0.01x |     - |     - |     - |         - |
|                 Span | 1000000 |   411.1 μs |  1.74 μs | 1.36 μs | 1.00x faster |   0.01x |     - |     - |     - |         - |
| ArraySegment_Foreach | 1000000 | 2,790.2 μs | 10.03 μs | 7.83 μs | 6.78x slower |   0.06x |     - |     - |     - |       1 B |
|     ArraySegment_For | 1000000 |   801.6 μs |  2.79 μs | 2.33 μs | 1.95x slower |   0.02x |     - |     - |     - |         - |
|  ArraySegment_AsSpan | 1000000 |   410.4 μs |  1.33 μs | 1.24 μs | 1.00x faster |   0.01x |     - |     - |     - |         - |
| ArraySegment_AsArray | 1000000 |   560.8 μs |  2.97 μs | 2.63 μs | 1.36x slower |   0.01x |     - |     - |     - |         - |
|               Vector | 1000000 |   104.3 μs |  0.54 μs | 0.50 μs | 3.95x faster |   0.04x |     - |     - |     - |         - |
