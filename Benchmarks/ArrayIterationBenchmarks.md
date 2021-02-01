## ArrayIterationBenchmarks

### Source
[ArrayIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayIterationBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                       Method |    Count |      Mean |     Error |    StdDev | Ratio | RatioSD |
|----------------------------- |--------- |----------:|----------:|----------:|------:|--------:|
|                      Foreach | 10000000 |  5.994 ms | 0.1155 ms | 0.1024 ms |  1.00 |    0.00 |
|                          For | 10000000 |  4.917 ms | 0.0722 ms | 0.0675 ms |  0.82 |    0.02 |
|                   For_Unsafe | 10000000 |  6.019 ms | 0.0699 ms | 0.0654 ms |  1.01 |    0.02 |
|               ForAdamczewski | 10000000 |  4.764 ms | 0.0291 ms | 0.0272 ms |  0.80 |    0.02 |
|         ForAdamczewskiUnsafe | 10000000 |  4.169 ms | 0.0829 ms | 0.0921 ms |  0.70 |    0.03 |
|                         Span | 10000000 |  4.720 ms | 0.0553 ms | 0.0491 ms |  0.79 |    0.02 |
|                       Memory | 10000000 |  6.107 ms | 0.0278 ms | 0.0260 ms |  1.02 |    0.02 |
|         ArraySegment_Foreach | 10000000 | 28.274 ms | 0.0372 ms | 0.0311 ms |  4.73 |    0.08 |
|             ArraySegment_For | 10000000 |  5.948 ms | 0.0457 ms | 0.0381 ms |  0.99 |    0.02 |
| ArraySegment_Wrapper_Foreach | 10000000 |  6.136 ms | 0.0263 ms | 0.0219 ms |  1.03 |    0.02 |
