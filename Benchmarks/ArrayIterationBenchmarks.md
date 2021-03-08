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
|                       Method |    Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|----------------------------- |--------- |----------:|----------:|----------:|----------:|------:|--------:|
|                      Foreach | 10000000 |  4.656 ms | 0.0169 ms | 0.0150 ms |  4.657 ms |  1.00 |    0.00 |
|                          For | 10000000 |  4.723 ms | 0.0226 ms | 0.0200 ms |  4.722 ms |  1.01 |    0.01 |
|                   For_Unsafe | 10000000 |  4.675 ms | 0.0217 ms | 0.0192 ms |  4.680 ms |  1.00 |    0.01 |
|               ForAdamczewski | 10000000 |  4.713 ms | 0.0292 ms | 0.0243 ms |  4.709 ms |  1.01 |    0.01 |
|         ForAdamczewskiUnsafe | 10000000 |  4.061 ms | 0.0170 ms | 0.0150 ms |  4.061 ms |  0.87 |    0.00 |
|                         Span | 10000000 | 11.012 ms | 0.0779 ms | 0.0728 ms | 11.005 ms |  2.37 |    0.02 |
|                       Memory | 10000000 |  4.662 ms | 0.0236 ms | 0.0197 ms |  4.659 ms |  1.00 |    0.01 |
|         ArraySegment_Foreach | 10000000 | 29.066 ms | 0.1223 ms | 0.0955 ms | 29.070 ms |  6.24 |    0.03 |
|             ArraySegment_For | 10000000 |  4.657 ms | 0.0181 ms | 0.0151 ms |  4.658 ms |  1.00 |    0.00 |
| ArraySegment_Wrapper_Foreach | 10000000 | 15.541 ms | 0.3073 ms | 0.5301 ms | 15.191 ms |  3.37 |    0.13 |
