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

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                       Method |   Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |-------- |-----------:|---------:|---------:|-----------:|------:|--------:|------:|------:|------:|----------:|
|                      Foreach | 1000000 |   421.7 μs |  2.74 μs |  2.43 μs |   421.4 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|                          For | 1000000 |   453.3 μs | 13.53 μs | 39.90 μs |   424.0 μs |  1.08 |    0.08 |     - |     - |     - |         - |
|                   For_Unsafe | 1000000 |   499.3 μs |  2.06 μs |  1.72 μs |   499.4 μs |  1.19 |    0.01 |     - |     - |     - |         - |
|                         Span | 1000000 |   423.4 μs |  2.07 μs |  1.94 μs |   423.7 μs |  1.00 |    0.01 |     - |     - |     - |         - |
|         ArraySegment_Foreach | 1000000 | 2,826.5 μs |  9.76 μs |  9.13 μs | 2,824.3 μs |  6.70 |    0.05 |     - |     - |     - |       1 B |
|             ArraySegment_For | 1000000 |   817.4 μs |  3.78 μs |  6.71 μs |   815.1 μs |  1.94 |    0.02 |     - |     - |     - |         - |
|    ArraySegment_Expanded_For | 1000000 | 1,403.9 μs | 27.63 μs | 40.50 μs | 1,425.7 μs |  3.27 |    0.10 |     - |     - |     - |       1 B |
| ArraySegment_Wrapper_Foreach | 1000000 | 1,468.3 μs |  4.87 μs |  4.32 μs | 1,466.8 μs |  3.48 |    0.02 |     - |     - |     - |         - |
