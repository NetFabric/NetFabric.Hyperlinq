## ArrayIterationBenchmarks

### Source
[ArrayIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayIterationBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                       Method |    Count |      Mean |     Error |    StdDev | Ratio | RatioSD |
|----------------------------- |--------- |----------:|----------:|----------:|------:|--------:|
|                      Foreach | 10000000 |  6.009 ms | 0.0366 ms | 0.0306 ms |  1.00 |    0.00 |
|                          For | 10000000 |  4.805 ms | 0.0398 ms | 0.0311 ms |  0.80 |    0.00 |
|                   For_Unsafe | 10000000 |  6.207 ms | 0.0870 ms | 0.0771 ms |  1.03 |    0.01 |
|               ForAdamczewski | 10000000 |  4.672 ms | 0.0785 ms | 0.0771 ms |  0.78 |    0.01 |
|         ForAdamczewskiUnsafe | 10000000 |  4.129 ms | 0.0289 ms | 0.0271 ms |  0.69 |    0.00 |
|                         Span | 10000000 |  4.949 ms | 0.0294 ms | 0.0260 ms |  0.82 |    0.01 |
|                       Memory | 10000000 |  6.043 ms | 0.0389 ms | 0.0325 ms |  1.01 |    0.01 |
|         ArraySegment_Foreach | 10000000 | 28.636 ms | 0.1005 ms | 0.0891 ms |  4.77 |    0.02 |
|             ArraySegment_For | 10000000 |  6.061 ms | 0.1187 ms | 0.1052 ms |  1.01 |    0.02 |
| ArraySegment_Wrapper_Foreach | 10000000 |  6.059 ms | 0.0356 ms | 0.0316 ms |  1.01 |    0.01 |
