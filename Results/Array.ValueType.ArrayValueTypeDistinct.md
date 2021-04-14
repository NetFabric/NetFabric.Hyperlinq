## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |          4 |  1000 |   202.88 μs |  2.375 μs |  2.105 μs |   202.40 μs |  1.00 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |  1000 |   205.42 μs |  3.765 μs |  2.939 μs |   204.44 μs |  1.01 |    0.02 |  86.9141 | 43.4570 | 43.4570 | 276,496 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |  1000 |   190.56 μs |  1.868 μs |  2.076 μs |   189.89 μs |  0.94 |    0.02 |  73.9746 |       - |       - | 155,048 B |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |  1000 |   518.39 μs |  2.084 μs |  1.740 μs |   518.29 μs |  2.55 |    0.03 | 190.4297 |       - |       - | 400,168 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |  1000 |   155.94 μs |  0.612 μs |  0.543 μs |   156.09 μs |  0.77 |    0.01 |        - |       - |       - |      56 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |  1000 |    52.67 μs |  1.163 μs |  3.429 μs |    50.76 μs |  0.26 |    0.02 |        - |       - |       - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |  1000 |   165.60 μs |  2.199 μs |  2.057 μs |   164.81 μs |  0.82 |    0.01 |        - |       - |       - |         - |
|                      |        |          |            |       |             |           |           |             |       |         |          |         |         |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |  1000 |   202.44 μs |  1.863 μs |  1.556 μs |   202.77 μs |  1.00 |    0.00 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |  1000 |   223.64 μs |  6.181 μs | 18.127 μs |   229.44 μs |  1.15 |    0.06 |  86.9141 | 43.4570 | 43.4570 | 276,488 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |  1000 |   232.48 μs |  1.113 μs |  0.929 μs |   232.57 μs |  1.15 |    0.01 |  86.9141 | 43.4570 | 43.4570 | 276,360 B |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |  1000 | 5,390.95 μs | 89.743 μs | 83.946 μs | 5,358.91 μs | 26.60 |    0.34 | 179.6875 |       - |       - | 382,472 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |  1000 |   159.60 μs |  0.675 μs |  0.564 μs |   159.68 μs |  0.79 |    0.01 |        - |       - |       - |      56 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |  1000 |    52.21 μs |  0.643 μs |  0.601 μs |    52.28 μs |  0.26 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |  1000 |   183.55 μs |  1.345 μs |  1.123 μs |   183.27 μs |  0.91 |    0.01 |        - |       - |       - |         - |
