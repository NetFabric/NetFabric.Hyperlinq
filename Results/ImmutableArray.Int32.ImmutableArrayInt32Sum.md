## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |    529.05 ns |   2.484 ns |   2.202 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    528.90 ns |   2.346 ns |   2.080 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  4,754.78 ns |  15.859 ns |  14.058 ns |  8.99 |    0.04 | 0.0229 |     - |     - |      56 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 33,360.06 ns | 243.328 ns | 203.190 ns | 63.07 |    0.45 | 8.4839 |     - |     - |  17,751 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  6,382.10 ns |  87.809 ns |  77.840 ns | 12.06 |    0.18 | 0.1221 |     - |     - |     264 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  1,855.45 ns |   9.539 ns |   8.456 ns |  3.51 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,828.65 ns |   7.007 ns |   5.851 ns |  3.46 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |     87.86 ns |   0.377 ns |   0.334 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    405.43 ns |   1.952 ns |   1.630 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    405.79 ns |   1.144 ns |   0.893 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  3,457.26 ns |  16.075 ns |  13.424 ns |  8.53 |    0.04 | 0.0267 |     - |     - |      56 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 30,200.85 ns | 253.121 ns | 224.385 ns | 74.39 |    0.50 | 8.3618 |     - |     - |  17,510 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  3,913.79 ns |  15.125 ns |  14.148 ns |  9.65 |    0.06 | 0.1221 |     - |     - |     264 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  1,322.79 ns |   3.077 ns |   2.878 ns |  3.26 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    594.96 ns |   1.287 ns |   1.141 ns |  1.47 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |     86.64 ns |   0.991 ns |   0.927 ns |  0.21 |    0.00 |      - |     - |     - |         - |
