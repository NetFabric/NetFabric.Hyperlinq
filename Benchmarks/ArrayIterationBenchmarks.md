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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                       Method |   Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |-------- |-----------:|---------:|---------:|-----------:|------:|--------:|------:|------:|------:|----------:|
|                      Foreach | 1000000 |   450.5 μs | 12.65 μs | 37.29 μs |   424.6 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|                          For | 1000000 |   418.6 μs |  2.47 μs |  1.93 μs |   418.4 μs |  0.86 |    0.05 |     - |     - |     - |         - |
|                   For_Unsafe | 1000000 |   498.8 μs |  4.77 μs |  4.46 μs |   496.8 μs |  1.02 |    0.06 |     - |     - |     - |         - |
|                         Span | 1000000 |   421.8 μs |  2.60 μs |  2.43 μs |   421.8 μs |  0.86 |    0.05 |     - |     - |     - |         - |
|         ArraySegment_Foreach | 1000000 | 2,816.0 μs |  5.71 μs |  5.06 μs | 2,816.0 μs |  5.78 |    0.30 |     - |     - |     - |       1 B |
|             ArraySegment_For | 1000000 |   815.9 μs |  2.95 μs |  5.47 μs |   814.6 μs |  1.81 |    0.15 |     - |     - |     - |         - |
|    ArraySegment_Expanded_For | 1000000 | 1,327.3 μs |  5.61 μs |  4.98 μs | 1,328.7 μs |  2.72 |    0.14 |     - |     - |     - |         - |
| ArraySegment_Wrapper_Foreach | 1000000 | 1,577.4 μs |  5.57 μs |  5.21 μs | 1,577.6 μs |  3.23 |    0.16 |     - |     - |     - |         - |
