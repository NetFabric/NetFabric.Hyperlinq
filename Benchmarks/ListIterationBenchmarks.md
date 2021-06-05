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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                   Method |    Categories |   Count |        Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |-------------- |-------- |------------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|          List_Enumerable |          List | 1000000 |  1,344.6 μs |   7.83 μs |   6.54 μs |  1.00 |    0.00 |     - |     - |     - |       1 B |
|             List_Indexer |          List | 1000000 |  1,176.2 μs |   5.95 μs |   5.56 μs |  0.87 |    0.01 |     - |     - |     - |       1 B |
|                List_Span |          List | 1000000 |    459.5 μs |   6.01 μs |   5.32 μs |  0.34 |    0.00 |     - |     - |     - |         - |
|                          |               |         |             |           |           |       |         |       |       |       |           |
| ImmutableList_Enumerable | ImmutableList | 1000000 | 35,174.0 μs | 356.44 μs | 315.97 μs |  1.00 |    0.00 |     - |     - |     - |      10 B |
|    ImmutableList_Indexer | ImmutableList | 1000000 | 62,851.2 μs | 274.72 μs | 256.97 μs |  1.79 |    0.02 |     - |     - |     - |      16 B |
