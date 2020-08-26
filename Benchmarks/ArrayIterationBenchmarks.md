## ArrayIterationBenchmarks

### Source
[ArrayIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayIterationBenchmarks.cs)

### References:
- Linq: 4.8.4180.0
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                  Method |   Count |       Mean |    Error |   StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |-------- |-----------:|---------:|---------:|------:|--------:|------:|------:|------:|----------:|
|              Enumerator | 1000000 |   574.1 μs |  3.43 μs |  2.86 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|                 Indexer | 1000000 |   585.2 μs |  3.52 μs |  3.29 μs |  1.02 |    0.01 |     - |     - |     - |         - |
|               IndexerLT | 1000000 |   587.4 μs |  3.87 μs |  3.43 μs |  1.02 |    0.01 |     - |     - |     - |         - |
|              IndexerLTE | 1000000 |   587.7 μs |  2.23 μs |  1.98 μs |  1.02 |    0.01 |     - |     - |     - |         - |
|               ArraySpan | 1000000 |   586.4 μs |  3.98 μs |  3.72 μs |  1.02 |    0.01 |     - |     - |     - |         - |
|              MemorySpan | 1000000 |   585.3 μs |  4.75 μs |  4.21 μs |  1.02 |    0.01 |     - |     - |     - |         - |
|                  Memory | 1000000 | 1,618.3 μs | 16.77 μs | 14.87 μs |  2.82 |    0.02 |     - |     - |     - |         - |
| ArraySegment_Enumerator | 1000000 | 2,914.3 μs | 24.12 μs | 21.38 μs |  5.08 |    0.04 |     - |     - |     - |         - |
|    ArraySegment_Indexer | 1000000 |   592.1 μs |  4.98 μs |  4.16 μs |  1.03 |    0.01 |     - |     - |     - |         - |
|  IEnumerable_Enumerator | 1000000 | 3,954.9 μs | 30.88 μs | 25.79 μs |  6.89 |    0.06 |     - |     - |     - |         - |
|           IList_Indexer | 1000000 | 4,223.5 μs | 27.70 μs | 23.13 μs |  7.36 |    0.05 |     - |     - |     - |         - |
