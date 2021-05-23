## ListIterationBenchmarks

### Source
[ListIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ListIterationBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21222.10
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host]     : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT
  Job-QJGPYZ : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Runtime=.NET 6.0  

```
|                   Method |    Categories |   Count |        Mean |       Error |      StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |-------------- |-------- |------------:|------------:|------------:|------:|--------:|------:|------:|------:|----------:|
|           List_numerable |          List | 1000000 |  1,987.8 μs |   113.79 μs |   335.50 μs |  1.00 |    0.00 |     - |     - |     - |       1 B |
|             List_Indexer |          List | 1000000 |  1,332.8 μs |    34.49 μs |   101.71 μs |  0.69 |    0.13 |     - |     - |     - |         - |
|                List_Span |          List | 1000000 |    625.0 μs |    24.47 μs |    72.15 μs |  0.32 |    0.07 |     - |     - |     - |         - |
|                          |               |         |             |             |             |       |         |       |       |       |           |
| ImmutableList_Enumerable | ImmutableList | 1000000 | 45,007.3 μs | 1,574.97 μs | 4,643.83 μs |  1.00 |    0.00 |     - |     - |     - |      12 B |
|    ImmutableList_Indexer | ImmutableList | 1000000 | 65,105.0 μs | 1,295.17 μs | 3,343.25 μs |  1.46 |    0.17 |     - |     - |     - |      18 B |
