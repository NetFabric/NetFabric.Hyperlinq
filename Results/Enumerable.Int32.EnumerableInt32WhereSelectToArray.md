## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |    **10** |    **113.18 ns** |   **1.925 ns** |   **1.706 ns** |   **1.00** |    **0.00** |  **0.1031** |     **-** |     **-** |     **216 B** |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    191.80 ns |   0.862 ns |   0.720 ns |   1.70 |    0.02 |  0.1452 |     - |     - |     304 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    191.65 ns |   0.409 ns |   0.342 ns |   1.70 |    0.02 |  0.0880 |     - |     - |     184 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 53,101.05 ns | 261.894 ns | 218.693 ns | 470.41 |    5.51 | 15.3198 |     - |     - |  32,062 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    411.41 ns |   1.410 ns |   1.319 ns |   3.64 |    0.06 |  0.3481 |     - |     - |     728 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    195.51 ns |   0.632 ns |   0.591 ns |   1.73 |    0.03 |  0.0842 |     - |     - |     176 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    149.56 ns |   0.884 ns |   0.738 ns |   1.32 |    0.01 |  0.0420 |     - |     - |      88 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    152.86 ns |   0.580 ns |   0.543 ns |   1.35 |    0.02 |  0.0420 |     - |     - |      88 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |    136.74 ns |   0.788 ns |   0.699 ns |   1.21 |    0.02 |  0.0420 |     - |     - |      88 B |
|                      |        |          |       |              |            |            |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     79.33 ns |   1.081 ns |   0.844 ns |   1.00 |    0.00 |  0.1032 |     - |     - |     216 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    164.53 ns |   1.061 ns |   0.941 ns |   2.08 |    0.03 |  0.1452 |     - |     - |     304 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    168.54 ns |   0.718 ns |   0.599 ns |   2.13 |    0.03 |  0.0880 |     - |     - |     184 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 48,119.96 ns | 115.536 ns | 102.420 ns | 606.66 |    6.92 | 15.0757 |     - |     - |  31,612 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    349.82 ns |   2.261 ns |   2.115 ns |   4.42 |    0.05 |  0.3481 |     - |     - |     728 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    167.76 ns |   0.954 ns |   0.892 ns |   2.11 |    0.03 |  0.0842 |     - |     - |     176 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    121.39 ns |   1.068 ns |   0.946 ns |   1.53 |    0.02 |  0.0420 |     - |     - |      88 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    129.79 ns |   1.260 ns |   0.984 ns |   1.64 |    0.02 |  0.0420 |     - |     - |      88 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |    108.66 ns |   0.339 ns |   0.318 ns |   1.37 |    0.01 |  0.0421 |     - |     - |      88 B |
|                      |        |          |       |              |            |            |        |         |         |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **5,893.14 ns** |  **20.975 ns** |  **19.620 ns** |   **1.00** |    **0.00** |  **3.0441** |     **-** |     **-** |   **6,368 B** |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  7,422.18 ns |  37.410 ns |  31.239 ns |   1.26 |    0.01 |  2.1896 |     - |     - |   4,584 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  8,640.12 ns |  32.226 ns |  26.910 ns |   1.47 |    0.01 |  3.0212 |     - |     - |   6,336 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 57,233.40 ns | 188.652 ns | 147.287 ns |   9.71 |    0.05 | 16.2354 |     - |     - |  34,040 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 11,204.33 ns |  52.544 ns |  43.877 ns |   1.90 |    0.01 |  3.2806 |     - |     - |   6,880 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  7,592.20 ns |  26.034 ns |  21.739 ns |   1.29 |    0.01 |  1.0223 |     - |     - |   2,152 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,783.68 ns |  50.716 ns |  44.959 ns |   0.98 |    0.01 |  0.9842 |     - |     - |   2,064 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  7,691.79 ns |  40.941 ns |  38.296 ns |   1.31 |    0.01 |  0.9766 |     - |     - |   2,064 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,878.90 ns |  24.741 ns |  23.143 ns |   1.00 |    0.00 |  0.9842 |     - |     - |   2,064 B |
|                      |        |          |       |              |            |            |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  3,742.19 ns |  25.541 ns |  23.891 ns |   1.00 |    0.00 |  3.0441 |     - |     - |   6,368 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5,287.22 ns |  53.394 ns |  44.586 ns |   1.41 |    0.01 |  2.1896 |     - |     - |   4,584 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  6,042.06 ns |  33.406 ns |  31.248 ns |   1.61 |    0.01 |  3.0289 |     - |     - |   6,336 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 55,493.98 ns | 645.203 ns | 503.732 ns |  14.85 |    0.21 | 16.0522 |     - |     - |  33,589 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  8,527.11 ns |  54.926 ns |  51.378 ns |   2.28 |    0.02 |  3.2806 |     - |     - |   6,880 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,533.81 ns |  14.582 ns |  13.640 ns |   1.48 |    0.01 |  1.0223 |     - |     - |   2,152 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  4,042.44 ns |  16.694 ns |  15.616 ns |   1.08 |    0.01 |  0.9842 |     - |     - |   2,064 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  6,079.57 ns |  21.249 ns |  18.837 ns |   1.62 |    0.01 |  0.9842 |     - |     - |   2,064 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,826.51 ns |  14.467 ns |  12.824 ns |   1.02 |    0.01 |  0.9842 |     - |     - |   2,064 B |
