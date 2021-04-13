## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method |    Job |  Runtime | Duplicates | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |          **4** |    **10** |    **394.6 ns** |   **1.26 ns** |   **1.11 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |    10 |    383.0 ns |   1.64 ns |   1.28 ns |  0.97 |    0.01 |  0.3209 |     - |     - |     672 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |    10 |    738.5 ns |   2.85 ns |   2.66 ns |  1.87 |    0.01 |  0.2899 |     - |     - |     608 B |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |    10 |    853.8 ns |  10.87 ns |  10.17 ns |  2.16 |    0.03 |  0.6189 |     - |     - |   1,296 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |    10 |    475.6 ns |   2.49 ns |   2.33 ns |  1.21 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |    10 |    474.0 ns |   5.57 ns |   5.21 ns |  1.20 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |    10 |    422.0 ns |   1.25 ns |   1.17 ns |  1.07 |    0.01 |       - |     - |     - |         - |
|                      |        |          |            |       |             |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |    10 |    409.4 ns |   1.78 ns |   1.66 ns |  1.00 |    0.00 |  0.3171 |     - |     - |     664 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |    10 |    408.2 ns |   2.20 ns |   2.06 ns |  1.00 |    0.01 |  0.3171 |     - |     - |     664 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |    10 |    473.3 ns |   1.49 ns |   1.32 ns |  1.16 |    0.00 |  0.3128 |     - |     - |     656 B |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |    10 |    838.4 ns |   3.24 ns |   2.87 ns |  2.05 |    0.01 |  0.6189 |     - |     - |   1,296 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |    10 |    479.6 ns |   2.09 ns |   1.96 ns |  1.17 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |    10 |    462.8 ns |   2.30 ns |   1.92 ns |  1.13 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |    10 |    419.8 ns |   1.87 ns |   1.66 ns |  1.02 |    0.01 |       - |     - |     - |         - |
|                      |        |          |            |       |             |           |           |       |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |          **4** |  **1000** | **33,426.1 ns** | **141.78 ns** | **132.62 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |  1000 | 30,732.3 ns | 464.93 ns | 362.99 ns |  0.92 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |  1000 | 63,944.2 ns | 150.62 ns | 133.52 ns |  1.91 |    0.01 | 15.7471 |     - |     - |  33,104 B |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |  1000 | 76,392.9 ns | 205.29 ns | 181.99 ns |  2.29 |    0.01 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |  1000 | 31,681.2 ns |  94.23 ns |  78.68 ns |  0.95 |    0.00 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |  1000 | 31,981.1 ns | 552.24 ns | 431.15 ns |  0.96 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |  1000 | 32,167.1 ns | 160.73 ns | 142.48 ns |  0.96 |    0.01 |       - |     - |     - |         - |
|                      |        |          |            |       |             |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |  1000 | 33,683.8 ns | 120.97 ns | 113.16 ns |  1.00 |    0.00 | 27.7710 |     - |     - |  58,664 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |  1000 | 33,569.3 ns | 364.07 ns | 340.55 ns |  1.00 |    0.01 | 27.7710 |     - |     - |  58,664 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |  1000 | 40,361.9 ns | 299.93 ns | 280.56 ns |  1.20 |    0.01 | 27.7710 |     - |     - |  58,656 B |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |  1000 | 76,485.5 ns | 699.47 ns | 654.28 ns |  2.27 |    0.02 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |  1000 | 30,916.0 ns |  68.93 ns |  57.56 ns |  0.92 |    0.00 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |  1000 | 30,824.5 ns | 119.85 ns | 106.24 ns |  0.92 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |  1000 | 31,912.3 ns | 169.17 ns | 158.24 ns |  0.95 |    0.00 |       - |     - |     - |         - |
