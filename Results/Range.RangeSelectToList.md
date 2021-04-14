## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                   Method |    Job |  Runtime | Start | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |--------- |------ |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 2,316.2 ns |  20.46 ns |  15.97 ns | 2,322.9 ns |  1.00 |    0.00 | 4.0207 |     - |     - |      8 KB |
|              ForeachLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 6,363.8 ns | 127.22 ns | 281.92 ns | 6,161.3 ns |  2.70 |    0.09 | 4.0436 |     - |     - |      8 KB |
|                     Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 3,281.4 ns |  65.73 ns |  67.50 ns | 3,299.2 ns |  1.41 |    0.04 | 1.9798 |     - |     - |      4 KB |
|               LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 2,832.5 ns |  35.29 ns |  33.01 ns | 2,829.0 ns |  1.22 |    0.02 | 5.7793 |     - |     - |     12 KB |
|                   LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 6,807.0 ns |  30.60 ns |  27.12 ns | 6,806.5 ns |  2.94 |    0.02 | 4.0207 |     - |     - |      8 KB |
|               StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,121.4 ns |  13.43 ns |  12.56 ns | 2,118.1 ns |  0.92 |    0.01 | 1.9646 |     - |     - |      4 KB |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 |   770.3 ns |   5.50 ns |  10.20 ns |   771.6 ns |  0.33 |    0.00 | 1.9379 |     - |     - |      4 KB |
|                Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,327.7 ns |  45.48 ns |  74.72 ns | 2,350.2 ns |  0.98 |    0.05 | 1.9379 |     - |     - |      4 KB |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 | 1,068.8 ns |  18.17 ns |  16.99 ns | 1,068.5 ns |  0.46 |    0.01 | 1.9379 |     - |     - |      4 KB |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   553.9 ns |   8.24 ns |   8.46 ns |   552.0 ns |  0.24 |    0.00 | 1.9341 |     - |     - |      4 KB |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   356.7 ns |   4.46 ns |   4.17 ns |   356.9 ns |  0.15 |    0.00 | 1.9341 |     - |     - |      4 KB |
|                          |        |          |       |       |            |           |           |            |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 2,568.8 ns |  32.86 ns |  30.74 ns | 2,578.6 ns |  1.00 |    0.00 | 4.0207 |     - |     - |      8 KB |
|              ForeachLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 4,255.0 ns |  24.66 ns |  23.07 ns | 4,256.9 ns |  1.66 |    0.02 | 4.0436 |     - |     - |      8 KB |
|                     Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,468.4 ns |  15.82 ns |  14.03 ns | 2,467.7 ns |  0.96 |    0.01 | 1.9798 |     - |     - |      4 KB |
|               LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 | 3,425.5 ns |  37.01 ns |  34.62 ns | 3,409.3 ns |  1.33 |    0.02 | 5.7793 |     - |     - |     12 KB |
|                   LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 6,681.0 ns |  39.76 ns |  35.25 ns | 6,676.0 ns |  2.60 |    0.02 | 4.0207 |     - |     - |      8 KB |
|               StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 | 1,874.9 ns |  10.16 ns |   9.01 ns | 1,875.5 ns |  0.73 |    0.01 | 1.9646 |     - |     - |      4 KB |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 |   824.7 ns |  18.00 ns |  53.08 ns |   792.4 ns |  0.35 |    0.01 | 1.9379 |     - |     - |      4 KB |
|                Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,154.0 ns |  16.13 ns |  15.08 ns | 2,152.0 ns |  0.84 |    0.01 | 1.9379 |     - |     - |      4 KB |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 | 1,067.5 ns |   6.04 ns |   4.72 ns | 1,067.6 ns |  0.42 |    0.00 | 1.9379 |     - |     - |      4 KB |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 2,393.3 ns |  13.35 ns |  12.49 ns | 2,393.1 ns |  0.93 |    0.01 | 1.9341 |     - |     - |      4 KB |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 1,311.0 ns |  15.55 ns |  14.55 ns | 1,303.4 ns |  0.51 |    0.01 | 1.9341 |     - |     - |      4 KB |
