## ArrayIterationBenchmarks

### Source
[ArrayIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayIterationBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                       Method |   Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |-------- |-----------:|---------:|---------:|-----------:|------:|--------:|------:|------:|------:|----------:|
|                      Foreach | 1000000 |   452.0 μs | 12.83 μs | 37.83 μs |   424.2 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|                          For | 1000000 |   418.5 μs |  1.42 μs |  1.19 μs |   418.3 μs |  0.87 |    0.05 |     - |     - |     - |         - |
|                   For_Unsafe | 1000000 |   452.8 μs | 13.08 μs | 38.57 μs |   424.4 μs |  1.01 |    0.12 |     - |     - |     - |         - |
|                         Span | 1000000 |   420.1 μs |  1.63 μs |  1.36 μs |   420.3 μs |  0.87 |    0.05 |     - |     - |     - |         - |
|         ArraySegment_Foreach | 1000000 | 2,936.3 μs | 36.57 μs | 34.21 μs | 2,947.8 μs |  6.07 |    0.30 |     - |     - |     - |       1 B |
|             ArraySegment_For | 1000000 |   812.7 μs |  2.33 μs |  1.95 μs |   812.6 μs |  1.69 |    0.09 |     - |     - |     - |         - |
|    ArraySegment_Expanded_For | 1000000 | 1,394.2 μs | 27.67 μs | 46.99 μs | 1,424.1 μs |  3.03 |    0.31 |     - |     - |     - |         - |
| ArraySegment_Wrapper_Foreach | 1000000 | 1,466.8 μs |  5.61 μs |  4.98 μs | 1,466.3 μs |  3.04 |    0.15 |     - |     - |     - |         - |
