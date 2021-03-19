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
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                       Method |    Count |      Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |--------- |----------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|                      Foreach | 10000000 |  5.083 ms | 0.0922 ms | 0.1133 ms |  1.00 |    0.00 |     - |     - |     - |       1 B |
|                          For | 10000000 |  5.022 ms | 0.0300 ms | 0.0266 ms |  0.98 |    0.02 |     - |     - |     - |       2 B |
|                   For_Unsafe | 10000000 |  5.226 ms | 0.0301 ms | 0.0267 ms |  1.02 |    0.02 |     - |     - |     - |       2 B |
|               ForAdamczewski | 10000000 |  4.805 ms | 0.0371 ms | 0.0310 ms |  0.94 |    0.02 |     - |     - |     - |       2 B |
|         ForAdamczewskiUnsafe | 10000000 |  4.343 ms | 0.0677 ms | 0.0633 ms |  0.85 |    0.03 |     - |     - |     - |       1 B |
|                         Span | 10000000 |  5.173 ms | 0.1025 ms | 0.1220 ms |  1.02 |    0.04 |     - |     - |     - |       1 B |
|                       Memory | 10000000 |  5.072 ms | 0.0736 ms | 0.0723 ms |  0.99 |    0.02 |     - |     - |     - |       1 B |
|         ArraySegment_Foreach | 10000000 | 28.831 ms | 0.1434 ms | 0.1271 ms |  5.63 |    0.14 |     - |     - |     - |       6 B |
|             ArraySegment_For | 10000000 |  8.883 ms | 0.0334 ms | 0.0296 ms |  1.73 |    0.04 |     - |     - |     - |       2 B |
| ArraySegment_Wrapper_Foreach | 10000000 | 15.390 ms | 0.0593 ms | 0.0496 ms |  3.00 |    0.08 |     - |     - |     - |       3 B |
