## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|               Method |    Job |  Runtime | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |   534.5 ns |  2.12 ns |  1.77 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |   534.2 ns |  3.02 ns |  2.68 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |   400.7 ns |  1.46 ns |  1.30 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 2,111.2 ns | 12.78 ns | 10.67 ns |  3.95 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 2,117.3 ns | 12.55 ns | 11.13 ns |  3.96 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |   399.7 ns |  1.52 ns |  1.27 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 |   117.6 ns |  0.66 ns |  0.55 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |            |          |          |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |   358.4 ns |  0.86 ns |  0.76 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |   531.6 ns |  2.58 ns |  2.16 ns |  1.48 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |   179.0 ns |  2.50 ns |  2.09 ns |  0.50 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |   799.9 ns |  3.58 ns |  3.17 ns |  2.23 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |   530.5 ns |  3.01 ns |  2.52 ns |  1.48 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |   272.1 ns |  1.67 ns |  1.48 ns |  0.76 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 |   115.3 ns |  0.66 ns |  0.59 ns |  0.32 |    0.00 |      - |     - |     - |         - |
