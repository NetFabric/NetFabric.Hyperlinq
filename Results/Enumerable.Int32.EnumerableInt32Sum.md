## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **59.61 ns** |   **0.338 ns** |   **0.316 ns** |   **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     61.28 ns |   0.392 ns |   0.367 ns |   1.03 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     78.57 ns |   0.404 ns |   0.337 ns |   1.32 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 25,264.09 ns | 148.237 ns | 138.661 ns | 423.86 |    3.59 | 8.3008 |     - |     - |  17,377 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    211.95 ns |   0.579 ns |   0.541 ns |   3.56 |    0.02 | 0.1185 |     - |     - |     248 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     76.69 ns |   0.331 ns |   0.259 ns |   1.28 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     60.51 ns |   0.331 ns |   0.309 ns |   1.02 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     59.26 ns |   0.370 ns |   0.346 ns |   0.99 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |        |         |        |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     36.39 ns |   0.192 ns |   0.179 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     29.21 ns |   0.159 ns |   0.141 ns |   0.80 |    0.00 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     58.58 ns |   0.629 ns |   0.588 ns |   1.61 |    0.02 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 24,322.11 ns |  99.111 ns |  92.709 ns | 668.39 |    4.15 | 8.1787 |     - |     - |  17,137 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    184.71 ns |   0.971 ns |   0.908 ns |   5.08 |    0.04 | 0.1185 |     - |     - |     248 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     47.04 ns |   0.499 ns |   0.467 ns |   1.29 |    0.01 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     39.09 ns |   0.154 ns |   0.129 ns |   1.07 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     38.66 ns |   0.198 ns |   0.185 ns |   1.06 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |        |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **4,419.09 ns** |  **13.751 ns** |  **11.482 ns** |   **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  4,684.50 ns |  20.660 ns |  16.130 ns |   1.06 |    0.00 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  4,705.70 ns |  25.582 ns |  23.929 ns |   1.06 |    0.01 | 0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 29,898.04 ns | 180.528 ns | 275.685 ns |   6.80 |    0.07 | 8.1787 |     - |     - |  17,377 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  5,594.94 ns |  30.068 ns |  23.475 ns |   1.27 |    0.01 | 0.1144 |     - |     - |     248 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  4,434.15 ns |  21.129 ns |  19.764 ns |   1.00 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4,428.47 ns |  20.534 ns |  18.203 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4,672.04 ns |  25.418 ns |  23.776 ns |   1.06 |    0.01 | 0.0153 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |        |         |        |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2,868.35 ns |  14.498 ns |  12.852 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  1,986.53 ns |  15.372 ns |  14.379 ns |   0.69 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  3,387.12 ns |   9.979 ns |   9.334 ns |   1.18 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 28,725.15 ns | 123.917 ns | 115.912 ns |  10.02 |    0.08 | 8.1787 |     - |     - |  17,137 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  2,832.19 ns |  12.472 ns |  11.666 ns |   0.99 |    0.01 | 0.1183 |     - |     - |     248 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,377.05 ns |   8.877 ns |   8.304 ns |   0.83 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,875.86 ns |  11.966 ns |  10.608 ns |   1.00 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  2,362.54 ns |   8.746 ns |   7.753 ns |   0.82 |    0.00 | 0.0191 |     - |     - |      40 B |
