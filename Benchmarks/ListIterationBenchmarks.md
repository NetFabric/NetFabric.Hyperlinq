## ListIterationBenchmarks

### Source
[ListIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ListIterationBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                   Method |    Categories |   Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |-------------- |-------- |------------:|----------:|----------:|------------:|------:|--------:|------:|------:|------:|----------:|
|          List_Enumerable |          List | 1000000 |  1,406.4 μs |  27.92 μs |  57.66 μs |  1,373.8 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|             List_Indexer |          List | 1000000 |  1,071.0 μs |   3.83 μs |   3.20 μs |  1,070.7 μs |  0.77 |    0.03 |     - |     - |     - |       1 B |
|                List_Span |          List | 1000000 |    487.5 μs |  15.26 μs |  44.99 μs |    459.3 μs |  0.35 |    0.03 |     - |     - |     - |         - |
|                          |               |         |             |           |           |             |       |         |       |       |       |           |
| ImmutableList_Enumerable | ImmutableList | 1000000 | 35,277.5 μs | 345.09 μs | 322.79 μs | 35,354.5 μs |  1.00 |    0.00 |     - |     - |     - |      10 B |
|    ImmutableList_Indexer | ImmutableList | 1000000 | 63,181.9 μs | 315.41 μs | 295.03 μs | 63,129.3 μs |  1.79 |    0.02 |     - |     - |     - |      55 B |
