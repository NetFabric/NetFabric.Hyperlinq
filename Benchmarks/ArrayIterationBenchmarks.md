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
  Job-XVAVUK : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|               Method |   Count |       Mean |   Error |  StdDev |        Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------- |-----------:|--------:|--------:|-------------:|--------:|------:|------:|------:|----------:|
|              Foreach | 1000000 |   412.6 μs | 2.14 μs | 1.67 μs |     baseline |         |     - |     - |     - |         - |
|                  For | 1000000 |   429.4 μs | 2.29 μs | 2.03 μs | 1.04x slower |   0.01x |     - |     - |     - |         - |
|           For_Unsafe | 1000000 |   413.0 μs | 3.60 μs | 2.81 μs | 1.00x slower |   0.01x |     - |     - |     - |         - |
|       ForAdamczewski | 1000000 |   408.5 μs | 2.42 μs | 2.14 μs | 1.01x faster |   0.01x |     - |     - |     - |         - |
| ForAdamczewskiUnsafe | 1000000 |   352.8 μs | 1.71 μs | 1.52 μs | 1.17x faster |   0.01x |     - |     - |     - |         - |
|                 Span | 1000000 |   413.7 μs | 3.02 μs | 2.82 μs | 1.00x slower |   0.01x |     - |     - |     - |         - |
| ArraySegment_Foreach | 1000000 | 2,796.4 μs | 7.48 μs | 7.00 μs | 6.78x slower |   0.04x |     - |     - |     - |       1 B |
|     ArraySegment_For | 1000000 |   805.3 μs | 4.55 μs | 3.55 μs | 1.95x slower |   0.01x |     - |     - |     - |         - |
|  ArraySegment_AsSpan | 1000000 |   412.9 μs | 2.45 μs | 2.29 μs | 1.00x slower |   0.01x |     - |     - |     - |         - |
| ArraySegment_AsArray | 1000000 |   802.6 μs | 4.70 μs | 4.17 μs | 1.94x slower |   0.01x |     - |     - |     - |         - |
