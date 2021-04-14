## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Duplicates | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |------- |--------- |----------- |------ |------------:|----------:|----------:|------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |          4 |  1000 |   212.62 μs |  2.486 μs |  3.721 μs |   211.69 μs |  1.00 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |  1000 |   216.62 μs |  1.387 μs |  1.083 μs |   216.78 μs |  1.02 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |  1000 |   212.79 μs |  4.333 μs |  4.636 μs |   213.98 μs |  1.00 |    0.03 |  73.9746 |       - |       - | 155,112 B |
|           LinqFaster | .NET 5 | .NET 5.0 |          4 |  1000 |    35.60 μs |  0.097 μs |  0.076 μs |    35.63 μs |  0.17 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |  1000 | 5,244.20 μs | 52.920 μs | 46.912 μs | 5,236.92 μs | 24.82 |    0.42 | 179.6875 |       - |       - | 384,568 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |  1000 |   154.69 μs |  0.753 μs |  1.397 μs |   154.30 μs |  0.73 |    0.01 |        - |       - |       - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |  1000 |    53.24 μs |  1.063 μs |  3.100 μs |    51.68 μs |  0.26 |    0.01 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |  1000 |   155.21 μs |  2.650 μs |  2.479 μs |   155.63 μs |  0.73 |    0.01 |        - |       - |       - |         - |
|                      |        |          |            |       |             |           |           |             |       |         |          |         |         |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |  1000 |   209.88 μs |  1.490 μs |  2.761 μs |   209.00 μs |  1.00 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |  1000 |   232.39 μs |  6.231 μs | 18.371 μs |   219.67 μs |  1.12 |    0.09 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |  1000 |   235.70 μs |  1.663 μs |  1.298 μs |   235.71 μs |  1.12 |    0.02 |  86.9141 | 43.4570 | 43.4570 | 276,424 B |
|           LinqFaster | .NET 6 | .NET 6.0 |          4 |  1000 |    35.79 μs |  0.110 μs |  0.102 μs |    35.81 μs |  0.17 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |  1000 | 5,237.70 μs | 18.686 μs | 16.564 μs | 5,236.99 μs | 24.95 |    0.40 | 179.6875 |       - |       - | 383,520 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |  1000 |   155.93 μs |  0.551 μs |  0.488 μs |   155.91 μs |  0.74 |    0.01 |        - |       - |       - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |  1000 |    54.20 μs |  1.145 μs |  3.377 μs |    52.16 μs |  0.26 |    0.02 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |  1000 |   156.99 μs |  3.071 μs |  2.873 μs |   156.57 μs |  0.75 |    0.02 |        - |       - |       - |         - |
