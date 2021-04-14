## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                  ForLoop | .NET 5 | .NET 5.0 |  1000 |  2,582.9 ns |  16.84 ns |  14.93 ns |  2,584.8 ns |  1.00 |    0.00 |  4.0207 |     - |     - |      8 KB |
|              ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4,522.0 ns |  41.80 ns |  37.05 ns |  4,511.0 ns |  1.75 |    0.02 |  4.0207 |     - |     - |      8 KB |
|                     Linq | .NET 5 | .NET 5.0 |  1000 |  3,197.7 ns |  63.66 ns |  75.78 ns |  3,214.0 ns |  1.23 |    0.04 |  1.9722 |     - |     - |      4 KB |
|               LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,179.2 ns |  21.28 ns |  18.86 ns |  3,180.3 ns |  1.23 |    0.01 |  3.8757 |     - |     - |      8 KB |
|                   LinqAF | .NET 5 | .NET 5.0 |  1000 |  9,094.9 ns |  46.58 ns |  41.29 ns |  9,102.6 ns |  3.52 |    0.03 |  4.0131 |     - |     - |      8 KB |
|            LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 59,936.9 ns | 951.70 ns | 843.66 ns | 60,171.3 ns | 23.20 |    0.30 | 17.6392 |     - |     - |     36 KB |
|                  Streams | .NET 5 | .NET 5.0 |  1000 | 11,472.5 ns | 152.31 ns | 135.02 ns | 11,420.2 ns |  4.44 |    0.05 |  4.1962 |     - |     - |      9 KB |
|               StructLinq | .NET 5 | .NET 5.0 |  1000 |  2,227.6 ns |  27.60 ns |  24.46 ns |  2,219.4 ns |  0.86 |    0.01 |  1.9684 |     - |     - |      4 KB |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,047.4 ns |   7.99 ns |   6.67 ns |  1,048.2 ns |  0.41 |    0.00 |  1.9569 |     - |     - |      4 KB |
|                Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  2,225.8 ns |  44.35 ns | 111.27 ns |  2,174.2 ns |  0.85 |    0.04 |  1.9341 |     - |     - |      4 KB |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    833.5 ns |  12.80 ns |  11.97 ns |    835.3 ns |  0.32 |    0.00 |  1.9341 |     - |     - |      4 KB |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 |    684.8 ns |   8.79 ns |   7.79 ns |    684.6 ns |  0.27 |    0.00 |  1.9341 |     - |     - |      4 KB |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |  1000 |    361.3 ns |   3.45 ns |   3.06 ns |    361.0 ns |  0.14 |    0.00 |  1.9341 |     - |     - |      4 KB |
|                          |        |          |       |             |           |           |             |       |         |         |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |  1000 |  2,684.0 ns |  53.79 ns | 149.04 ns |  2,613.9 ns |  1.00 |    0.00 |  4.0207 |     - |     - |      8 KB |
|              ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2,371.2 ns |  37.44 ns |  35.03 ns |  2,372.6 ns |  0.86 |    0.05 |  4.0207 |     - |     - |      8 KB |
|                     Linq | .NET 6 | .NET 6.0 |  1000 |  2,952.5 ns |  17.04 ns |  15.11 ns |  2,953.9 ns |  1.07 |    0.05 |  1.9722 |     - |     - |      4 KB |
|               LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,170.4 ns |  38.68 ns |  36.18 ns |  3,169.9 ns |  1.15 |    0.06 |  3.8757 |     - |     - |      8 KB |
|                   LinqAF | .NET 6 | .NET 6.0 |  1000 |  9,980.8 ns |  54.29 ns |  48.13 ns |  9,982.6 ns |  3.62 |    0.18 |  4.0131 |     - |     - |      8 KB |
|            LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 48,976.4 ns | 388.10 ns | 363.03 ns | 48,902.5 ns | 17.71 |    0.83 | 17.4561 |     - |     - |     36 KB |
|                  Streams | .NET 6 | .NET 6.0 |  1000 | 11,093.7 ns |  71.02 ns |  59.31 ns | 11,105.4 ns |  4.03 |    0.22 |  4.1962 |     - |     - |      9 KB |
|               StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,629.8 ns |  12.33 ns |  10.29 ns |  2,632.7 ns |  0.96 |    0.05 |  1.9684 |     - |     - |      4 KB |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,015.7 ns |  19.84 ns |  19.49 ns |  1,019.0 ns |  0.37 |    0.02 |  1.9569 |     - |     - |      4 KB |
|                Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  2,106.9 ns |  11.29 ns |  10.01 ns |  2,103.2 ns |  0.76 |    0.04 |  1.9341 |     - |     - |      4 KB |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,074.7 ns |   5.88 ns |   5.21 ns |  1,075.2 ns |  0.39 |    0.02 |  1.9341 |     - |     - |      4 KB |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 |  2,189.8 ns |  13.22 ns |  10.32 ns |  2,192.3 ns |  0.80 |    0.04 |  1.9341 |     - |     - |      4 KB |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |  1000 |  1,299.5 ns |   4.34 ns |   4.06 ns |  1,298.9 ns |  0.47 |    0.02 |  1.9341 |     - |     - |      4 KB |
