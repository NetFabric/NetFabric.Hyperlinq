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
|                       Method |    Count |      Mean |     Error |    StdDev | Ratio |
|----------------------------- |--------- |----------:|----------:|----------:|------:|
|                      Foreach | 10000000 |  5.695 ms | 0.0092 ms | 0.0086 ms |  1.00 |
|                          For | 10000000 |  4.515 ms | 0.0097 ms | 0.0086 ms |  0.79 |
|                   For_Unsafe | 10000000 |  4.460 ms | 0.0114 ms | 0.0107 ms |  0.78 |
|               ForAdamczewski | 10000000 |  4.371 ms | 0.0168 ms | 0.0149 ms |  0.77 |
|         ForAdamczewskiUnsafe | 10000000 |  3.878 ms | 0.0153 ms | 0.0128 ms |  0.68 |
|                         Span | 10000000 |  4.459 ms | 0.0083 ms | 0.0069 ms |  0.78 |
|                       Memory | 10000000 |  5.725 ms | 0.0208 ms | 0.0184 ms |  1.01 |
|         ArraySegment_Foreach | 10000000 | 28.060 ms | 0.0959 ms | 0.0748 ms |  4.93 |
|             ArraySegment_For | 10000000 |  5.701 ms | 0.0169 ms | 0.0150 ms |  1.00 |
| ArraySegment_Wrapper_Foreach | 10000000 | 14.684 ms | 0.0342 ms | 0.0320 ms |  2.58 |
