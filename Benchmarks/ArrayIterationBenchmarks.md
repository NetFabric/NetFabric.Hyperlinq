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
|                      Foreach | 10000000 |  6.345 ms | 0.0361 ms | 0.0338 ms |  1.00 |    0.00 |
|                          For | 10000000 |  4.890 ms | 0.0251 ms | 0.0196 ms |  0.77 |    0.00 |
|                   For_Unsafe | 10000000 |  6.231 ms | 0.0678 ms | 0.0634 ms |  0.98 |    0.01 |
|               ForAdamczewski | 10000000 |  4.771 ms | 0.0571 ms | 0.0477 ms |  0.75 |    0.01 |
|         ForAdamczewskiUnsafe | 10000000 |  4.381 ms | 0.0845 ms | 0.0749 ms |  0.69 |    0.01 |
|                         Span | 10000000 |  4.985 ms | 0.0764 ms | 0.0597 ms |  0.78 |    0.01 |
|                       Memory | 10000000 |  6.220 ms | 0.0462 ms | 0.0410 ms |  0.98 |    0.01 |
|         ArraySegment_Foreach | 10000000 | 29.045 ms | 0.0811 ms | 0.0678 ms |  4.57 |    0.03 |
|             ArraySegment_For | 10000000 |  6.332 ms | 0.0417 ms | 0.0370 ms |  1.00 |    0.01 |
| ArraySegment_Wrapper_Foreach | 10000000 |  6.242 ms | 0.0614 ms | 0.0574 ms |  0.98 |    0.01 |
