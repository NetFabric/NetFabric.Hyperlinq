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
  Job-VMNIKZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|               Method |   Count |       Mean |   Error |  StdDev |        Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------- |-----------:|--------:|--------:|-------------:|--------:|------:|------:|------:|----------:|
|              Foreach | 1000000 |   410.6 μs | 2.11 μs | 1.65 μs |     baseline |         |     - |     - |     - |         - |
|                  For | 1000000 |   413.4 μs | 1.94 μs | 1.81 μs | 1.01x slower |   0.01x |     - |     - |     - |         - |
|           For_Unsafe | 1000000 |   410.5 μs | 1.62 μs | 1.51 μs | 1.00x faster |   0.00x |     - |     - |     - |         - |
| ForAdamczewskiUnsafe | 1000000 |   350.6 μs | 1.82 μs | 1.52 μs | 1.17x faster |   0.01x |     - |     - |     - |         - |
|                 Span | 1000000 |   408.3 μs | 1.73 μs | 1.53 μs | 1.01x faster |   0.01x |     - |     - |     - |         - |
| ArraySegment_Foreach | 1000000 | 2,784.3 μs | 7.78 μs | 6.50 μs | 6.78x slower |   0.03x |     - |     - |     - |       1 B |
|     ArraySegment_For | 1000000 |   800.8 μs | 3.75 μs | 3.13 μs | 1.95x slower |   0.01x |     - |     - |     - |         - |
|  ArraySegment_AsSpan | 1000000 |   409.3 μs | 1.34 μs | 1.25 μs | 1.00x faster |   0.00x |     - |     - |     - |         - |
| ArraySegment_AsArray | 1000000 | 1,054.0 μs | 2.24 μs | 2.09 μs | 2.57x slower |   0.01x |     - |     - |     - |         - |
