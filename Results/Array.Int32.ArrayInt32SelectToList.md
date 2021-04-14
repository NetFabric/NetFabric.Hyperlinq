## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                   Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |--------- |------ |------------:|----------:|----------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | .NET 5 | .NET 5.0 |  1000 |  2,121.9 ns |  20.41 ns |  17.04 ns |  2,118.8 ns |  1.00 |    0.00 |  4.0207 |     - |     - |      8 KB |
|              ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  2,378.4 ns |  46.90 ns |  67.27 ns |  2,392.6 ns |  1.12 |    0.05 |  4.0207 |     - |     - |      8 KB |
|                     Linq | .NET 5 | .NET 5.0 |  1000 |  2,941.3 ns |  22.79 ns |  19.03 ns |  2,937.0 ns |  1.39 |    0.01 |  1.9608 |     - |     - |      4 KB |
|               LinqFaster | .NET 5 | .NET 5.0 |  1000 |  2,451.6 ns |  39.07 ns |  34.64 ns |  2,459.3 ns |  1.16 |    0.02 |  3.8605 |     - |     - |      8 KB |
|          LinqFaster_SIMD | .NET 5 | .NET 5.0 |  1000 |    997.3 ns |  18.52 ns |  17.32 ns |    991.6 ns |  0.47 |    0.01 |  3.8605 |     - |     - |      8 KB |
|                   LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,082.4 ns |  33.15 ns |  29.39 ns |  7,075.1 ns |  3.34 |    0.03 |  4.0207 |     - |     - |      8 KB |
|            LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 41,296.1 ns | 358.28 ns | 578.56 ns | 41,074.3 ns | 19.55 |    0.25 | 17.0898 |     - |     - |     35 KB |
|                  Streams | .NET 5 | .NET 5.0 |  1000 | 10,597.1 ns |  30.77 ns |  27.28 ns | 10,595.8 ns |  4.99 |    0.04 |  4.1962 |     - |     - |      9 KB |
|               StructLinq | .NET 5 | .NET 5.0 |  1000 |  2,126.1 ns |  10.13 ns |   8.98 ns |  2,125.9 ns |  1.00 |    0.01 |  1.9684 |     - |     - |      4 KB |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,188.5 ns |  10.34 ns |   9.17 ns |  1,187.5 ns |  0.56 |    0.01 |  1.9569 |     - |     - |      4 KB |
|                Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  2,118.5 ns |  14.53 ns |  12.13 ns |  2,121.9 ns |  1.00 |    0.01 |  1.9341 |     - |     - |      4 KB |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    803.1 ns |   9.73 ns |   8.13 ns |    804.6 ns |  0.38 |    0.01 |  1.9341 |     - |     - |      4 KB |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 |    597.8 ns |  15.44 ns |  45.51 ns |    571.5 ns |  0.30 |    0.02 |  1.9341 |     - |     - |      4 KB |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |  1000 |    365.5 ns |   7.30 ns |   5.70 ns |    365.5 ns |  0.17 |    0.00 |  1.9341 |     - |     - |      4 KB |
|                          |        |          |       |             |           |           |             |       |         |         |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |  1000 |  2,178.1 ns |  33.71 ns |  31.54 ns |  2,174.5 ns |  1.00 |    0.00 |  4.0207 |     - |     - |      8 KB |
|              ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2,184.9 ns |  36.41 ns |  30.40 ns |  2,182.5 ns |  1.00 |    0.02 |  4.0207 |     - |     - |      8 KB |
|                     Linq | .NET 6 | .NET 6.0 |  1000 |  2,389.3 ns |  11.98 ns |  10.00 ns |  2,391.7 ns |  1.10 |    0.02 |  1.9608 |     - |     - |      4 KB |
|               LinqFaster | .NET 6 | .NET 6.0 |  1000 |  2,745.0 ns |  38.32 ns |  35.85 ns |  2,736.7 ns |  1.26 |    0.02 |  3.8605 |     - |     - |      8 KB |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |  1000 |  2,637.2 ns |  53.39 ns | 157.41 ns |  2,549.3 ns |  1.28 |    0.07 |  3.8605 |     - |     - |      8 KB |
|                   LinqAF | .NET 6 | .NET 6.0 |  1000 |  6,110.4 ns | 121.95 ns | 296.83 ns |  5,914.4 ns |  2.81 |    0.11 |  4.0207 |     - |     - |      8 KB |
|            LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 38,518.5 ns | 499.06 ns | 389.63 ns | 38,357.4 ns | 17.69 |    0.35 | 16.9678 |     - |     - |     35 KB |
|                  Streams | .NET 6 | .NET 6.0 |  1000 | 11,194.6 ns |  64.95 ns |  57.57 ns | 11,197.3 ns |  5.14 |    0.09 |  4.1962 |     - |     - |      9 KB |
|               StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,396.7 ns |  16.82 ns |  14.91 ns |  2,396.2 ns |  1.10 |    0.02 |  1.9684 |     - |     - |      4 KB |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,064.8 ns |  10.98 ns |  10.27 ns |  1,063.8 ns |  0.49 |    0.01 |  1.9569 |     - |     - |      4 KB |
|                Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  1,857.8 ns |  20.08 ns |  17.80 ns |  1,850.2 ns |  0.85 |    0.01 |  1.9341 |     - |     - |      4 KB |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,053.1 ns |  12.52 ns |  11.71 ns |  1,050.9 ns |  0.48 |    0.01 |  1.9341 |     - |     - |      4 KB |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 |  2,202.5 ns |  10.58 ns |   8.26 ns |  2,201.3 ns |  1.01 |    0.02 |  1.9341 |     - |     - |      4 KB |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |  1000 |  1,303.5 ns |   6.66 ns |   5.56 ns |  1,303.1 ns |  0.60 |    0.01 |  1.9341 |     - |     - |      4 KB |
