## ListIterationBenchmarks

### Source
[ListIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ListIterationBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                   Method |    Categories |   Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |-------------- |-------- |------------:|------------:|------------:|------------:|------:|--------:|------:|------:|------:|----------:|
|          List_Enumerable |          List | 1000000 |  1,392.6 μs |    27.61 μs |    60.61 μs |  1,350.0 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|             List_Indexer |          List | 1000000 |  1,066.9 μs |     3.64 μs |     3.04 μs |  1,067.6 μs |  0.76 |    0.03 |     - |     - |     - |       1 B |
|                List_Span |          List | 1000000 |    457.8 μs |     2.98 μs |     3.32 μs |    456.8 μs |  0.32 |    0.01 |     - |     - |     - |         - |
|                          |               |         |             |             |             |             |       |         |       |       |       |           |
| ImmutableList_Enumerable | ImmutableList | 1000000 | 36,880.0 μs |   813.67 μs | 2,399.13 μs | 35,638.2 μs |  1.00 |    0.00 |     - |     - |     - |      10 B |
|    ImmutableList_Indexer | ImmutableList | 1000000 | 60,898.2 μs | 1,206.47 μs | 2,698.44 μs | 59,314.9 μs |  1.61 |    0.08 |     - |     - |     - |      16 B |
