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
|               Method |    Job |  Runtime | Duplicates | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----------- |------ |---------:|---------:|---------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |          4 |  1000 | 30.78 μs | 0.216 μs | 0.168 μs |  1.00 |    0.00 | 27.7710 |     - |     - |  58,672 B |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |  1000 | 33.24 μs | 0.402 μs | 0.376 μs |  1.08 |    0.02 | 27.7710 |     - |     - |  58,672 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |  1000 | 63.44 μs | 0.224 μs | 0.198 μs |  2.06 |    0.01 | 15.7471 |     - |     - |  33,104 B |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |  1000 | 75.38 μs | 0.396 μs | 0.371 μs |  2.45 |    0.01 | 53.9551 |     - |     - | 113,186 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |  1000 | 31.72 μs | 0.118 μs | 0.105 μs |  1.03 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |  1000 | 31.98 μs | 0.238 μs | 0.223 μs |  1.04 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |  1000 | 32.43 μs | 0.157 μs | 0.147 μs |  1.05 |    0.01 |       - |     - |     - |         - |
|                      |        |          |            |       |          |          |          |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |  1000 | 33.91 μs | 0.140 μs | 0.131 μs |  1.00 |    0.00 | 27.7710 |     - |     - |  58,664 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |  1000 | 33.38 μs | 0.480 μs | 0.401 μs |  0.98 |    0.01 | 27.7710 |     - |     - |  58,664 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |  1000 | 41.41 μs | 0.552 μs | 0.567 μs |  1.22 |    0.02 | 27.7710 |     - |     - |  58,656 B |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |  1000 | 76.81 μs | 0.601 μs | 0.563 μs |  2.27 |    0.02 | 53.9551 |     - |     - | 113,186 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |  1000 | 31.32 μs | 0.078 μs | 0.069 μs |  0.92 |    0.00 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |  1000 | 31.42 μs | 0.524 μs | 0.438 μs |  0.93 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |  1000 | 33.09 μs | 0.300 μs | 0.250 μs |  0.98 |    0.01 |       - |     - |     - |         - |
