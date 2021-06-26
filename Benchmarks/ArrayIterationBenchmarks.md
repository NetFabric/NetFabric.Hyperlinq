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
  Job-SLIMHF : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|               Method |   Count |       Mean |    Error |   StdDev |        Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------- |-----------:|---------:|---------:|-------------:|--------:|------:|------:|------:|----------:|
|              Foreach | 1000000 |   432.4 μs |  3.92 μs |  3.06 μs |     baseline |         |     - |     - |     - |         - |
|                  For | 1000000 |   435.1 μs |  8.19 μs |  7.26 μs | 1.01x slower |   0.02x |     - |     - |     - |         - |
|           For_Unsafe | 1000000 |   434.8 μs |  8.67 μs |  8.11 μs | 1.00x slower |   0.02x |     - |     - |     - |         - |
|       ForAdamczewski | 1000000 |   369.4 μs |  6.03 μs |  5.03 μs | 1.17x faster |   0.02x |     - |     - |     - |         - |
| ForAdamczewskiUnsafe | 1000000 |   436.1 μs |  4.05 μs |  3.38 μs | 1.01x slower |   0.01x |     - |     - |     - |         - |
|                 Span | 1000000 |   431.5 μs |  2.91 μs |  2.43 μs | 1.00x faster |   0.01x |     - |     - |     - |         - |
| ArraySegment_Foreach | 1000000 | 2,890.1 μs | 34.93 μs | 30.97 μs | 6.69x slower |   0.07x |     - |     - |     - |       1 B |
|     ArraySegment_For | 1000000 |   836.4 μs |  9.11 μs |  7.60 μs | 1.94x slower |   0.02x |     - |     - |     - |         - |
|  ArraySegment_AsSpan | 1000000 |   430.0 μs |  4.37 μs |  3.65 μs | 1.01x faster |   0.01x |     - |     - |     - |         - |
| ArraySegment_AsArray | 1000000 |   575.1 μs |  3.28 μs |  2.91 μs | 1.33x slower |   0.01x |     - |     - |     - |         - |
|               Vector | 1000000 |   118.6 μs |  1.91 μs |  2.12 μs | 3.63x faster |   0.08x |     - |     - |     - |         - |
