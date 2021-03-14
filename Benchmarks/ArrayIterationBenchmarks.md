## ArrayIterationBenchmarks

### Source
[ArrayIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayIterationBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]   : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0  

```
|                       Method |    Count |      Mean |     Error |    StdDev | Ratio | RatioSD |
|----------------------------- |--------- |----------:|----------:|----------:|------:|--------:|
|                      Foreach | 10000000 |  4.859 ms | 0.0885 ms | 0.0828 ms |  1.00 |    0.00 |
|                          For | 10000000 |  4.807 ms | 0.0397 ms | 0.0352 ms |  0.99 |    0.02 |
|                   For_Unsafe | 10000000 |  4.818 ms | 0.0396 ms | 0.0351 ms |  0.99 |    0.02 |
|               ForAdamczewski | 10000000 |  4.587 ms | 0.0227 ms | 0.0189 ms |  0.95 |    0.02 |
|         ForAdamczewskiUnsafe | 10000000 |  4.121 ms | 0.0432 ms | 0.0383 ms |  0.85 |    0.02 |
|                         Span | 10000000 |  4.771 ms | 0.0216 ms | 0.0191 ms |  0.98 |    0.02 |
|                       Memory | 10000000 |  4.804 ms | 0.0539 ms | 0.0504 ms |  0.99 |    0.02 |
|         ArraySegment_Foreach | 10000000 | 28.829 ms | 0.2076 ms | 0.1942 ms |  5.93 |    0.10 |
|             ArraySegment_For | 10000000 |  8.417 ms | 0.0617 ms | 0.0578 ms |  1.73 |    0.03 |
| ArraySegment_Wrapper_Foreach | 10000000 | 15.080 ms | 0.0738 ms | 0.0690 ms |  3.10 |    0.05 |
