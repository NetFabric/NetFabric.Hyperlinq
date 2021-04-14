## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method |    Job |  Runtime | Duplicates | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |          4 |  1000 | 36.091 μs | 0.2693 μs | 0.2387 μs | 36.068 μs |  1.00 |    0.00 | 27.7710 |     - |     - |  58,672 B |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |  1000 | 40.298 μs | 0.2795 μs | 0.2477 μs | 40.215 μs |  1.12 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |  1000 | 75.624 μs | 0.4006 μs | 0.3747 μs | 75.606 μs |  2.10 |    0.02 | 15.7471 |     - |     - |  33,112 B |
|           LinqFaster | .NET 5 | .NET 5.0 |          4 |  1000 |  8.031 μs | 0.0646 μs | 0.0539 μs |  8.027 μs |  0.22 |    0.00 |       - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |  1000 | 92.975 μs | 1.7137 μs | 2.6681 μs | 91.914 μs |  2.60 |    0.11 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |  1000 | 32.985 μs | 0.5876 μs | 0.4907 μs | 33.145 μs |  0.91 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |  1000 | 33.296 μs | 0.5875 μs | 0.5208 μs | 33.413 μs |  0.92 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |  1000 | 33.138 μs | 0.1410 μs | 0.1177 μs | 33.162 μs |  0.92 |    0.01 |       - |     - |     - |         - |
|                      |        |          |            |       |           |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |  1000 | 39.542 μs | 0.7850 μs | 2.0122 μs | 38.155 μs |  1.00 |    0.00 | 27.7710 |     - |     - |  58,664 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |  1000 | 36.926 μs | 0.2956 μs | 0.2468 μs | 36.912 μs |  0.96 |    0.03 | 27.7710 |     - |     - |  58,664 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |  1000 | 61.558 μs | 1.2305 μs | 2.9719 μs | 59.742 μs |  1.56 |    0.14 | 27.7710 |     - |     - |  58,664 B |
|           LinqFaster | .NET 6 | .NET 6.0 |          4 |  1000 |  7.008 μs | 0.0205 μs | 0.0182 μs |  7.007 μs |  0.18 |    0.01 |       - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |  1000 | 89.543 μs | 0.5797 μs | 0.5139 μs | 89.597 μs |  2.32 |    0.09 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |  1000 | 32.316 μs | 0.3130 μs | 0.2928 μs | 32.366 μs |  0.83 |    0.04 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |  1000 | 32.310 μs | 0.5138 μs | 0.4555 μs | 32.481 μs |  0.84 |    0.04 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |  1000 | 33.812 μs | 0.2183 μs | 0.1935 μs | 33.757 μs |  0.88 |    0.03 |       - |     - |     - |         - |
