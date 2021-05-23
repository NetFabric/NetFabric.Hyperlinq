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

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-CGYYAC : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                       Method |   Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |-------- |-----------:|---------:|---------:|------:|--------:|------:|------:|------:|----------:|
|                      Foreach | 1000000 |   454.5 μs |  3.61 μs |  3.37 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|                          For | 1000000 |   452.5 μs |  3.69 μs |  3.27 μs |  1.00 |    0.01 |     - |     - |     - |         - |
|                   For_Unsafe | 1000000 |   450.1 μs |  2.38 μs |  1.98 μs |  0.99 |    0.01 |     - |     - |     - |         - |
|                         Span | 1000000 |   452.9 μs |  2.16 μs |  1.91 μs |  1.00 |    0.01 |     - |     - |     - |         - |
|         ArraySegment_Foreach | 1000000 | 2,882.3 μs | 18.69 μs | 16.57 μs |  6.34 |    0.05 |     - |     - |     - |       1 B |
|             ArraySegment_For | 1000000 |   835.7 μs |  6.87 μs |  6.43 μs |  1.84 |    0.01 |     - |     - |     - |         - |
|    ArraySegment_Expanded_For | 1000000 | 1,346.8 μs |  7.64 μs |  6.77 μs |  2.96 |    0.03 |     - |     - |     - |         - |
| ArraySegment_Wrapper_Foreach | 1000000 | 1,492.8 μs |  8.99 μs |  7.51 μs |  3.29 |    0.03 |     - |     - |     - |         - |
