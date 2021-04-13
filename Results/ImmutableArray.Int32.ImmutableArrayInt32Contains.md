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
|               Method |    Job |  Runtime | Count |         Mean |     Error |    StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|----------:|----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **5.556 ns** | **0.0398 ns** | **0.0372 ns** |     **5.558 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     4.712 ns | 0.0395 ns | 0.0702 ns |     4.694 ns |  0.85 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     9.786 ns | 0.0467 ns | 0.0437 ns |     9.790 ns |  1.76 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    30.095 ns | 0.6438 ns | 1.0932 ns |    29.400 ns |  5.61 |    0.15 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    23.194 ns | 0.0926 ns | 0.0821 ns |    23.180 ns |  4.17 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    12.371 ns | 0.0713 ns | 0.0667 ns |    12.363 ns |  2.23 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 | .NET 5.0 |    10 |    19.675 ns | 0.0863 ns | 0.0721 ns |    19.653 ns |  3.54 |    0.03 |      - |     - |     - |         - |
|                      |        |          |       |              |           |           |              |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     3.140 ns | 0.0237 ns | 0.0221 ns |     3.135 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     5.536 ns | 0.0404 ns | 0.0358 ns |     5.538 ns |  1.76 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     9.426 ns | 0.2439 ns | 0.3938 ns |     9.159 ns |  3.12 |    0.09 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    16.825 ns | 0.0746 ns | 0.0583 ns |    16.819 ns |  5.35 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     5.917 ns | 0.0537 ns | 0.0503 ns |     5.920 ns |  1.88 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    12.013 ns | 0.0439 ns | 0.0410 ns |    11.999 ns |  3.83 |    0.03 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | .NET 6.0 |    10 |    16.412 ns | 0.3875 ns | 0.7086 ns |    16.031 ns |  5.46 |    0.24 |      - |     - |     - |         - |
|                      |        |          |       |              |           |           |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |   **526.668 ns** | **2.0570 ns** | **1.9241 ns** |   **527.075 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |   524.495 ns | 2.7849 ns | 2.6050 ns |   523.509 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |   397.416 ns | 1.8971 ns | 1.7745 ns |   397.511 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 2,073.985 ns | 8.3647 ns | 7.4151 ns | 2,072.001 ns |  3.94 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 2,085.787 ns | 8.1842 ns | 7.6556 ns | 2,085.557 ns |  3.96 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |   394.934 ns | 1.2253 ns | 1.0232 ns |   395.128 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 |   115.608 ns | 0.2967 ns | 0.2775 ns |   115.587 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |              |           |           |              |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |   354.122 ns | 1.6021 ns | 1.4202 ns |   354.162 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |   523.043 ns | 2.3431 ns | 2.0771 ns |   522.501 ns |  1.48 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |   269.495 ns | 1.2565 ns | 1.1753 ns |   269.813 ns |  0.76 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |   788.103 ns | 3.5405 ns | 3.3118 ns |   787.470 ns |  2.23 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |   524.271 ns | 2.9348 ns | 2.4507 ns |   523.534 ns |  1.48 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |   267.875 ns | 1.5547 ns | 1.3782 ns |   268.015 ns |  0.76 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 |   113.882 ns | 0.2955 ns | 0.2620 ns |   113.811 ns |  0.32 |    0.00 |      - |     - |     - |         - |
