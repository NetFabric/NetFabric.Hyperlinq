## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                  ForLoop | .NET 5 | .NET 5.0 |     0 |  1000 |   918.3 ns |  16.38 ns |  13.68 ns |   919.5 ns |  1.00 |    0.00 | 1.9226 |     - |     - |      4 KB |
|                     Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,271.8 ns |  45.11 ns |  85.83 ns | 2,311.4 ns |  2.34 |    0.07 | 1.9646 |     - |     - |      4 KB |
|               LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 2,494.2 ns |  17.69 ns |  16.55 ns | 2,498.2 ns |  2.72 |    0.05 | 3.8452 |     - |     - |      8 KB |
|          LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   870.1 ns |  13.63 ns |  12.75 ns |   873.4 ns |  0.95 |    0.02 | 3.8452 |     - |     - |      8 KB |
|                   LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 6,607.7 ns | 132.04 ns | 318.88 ns | 6,400.6 ns |  7.19 |    0.32 | 5.9280 |     - |     - |     12 KB |
|               StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,380.2 ns |  11.79 ns |  20.02 ns | 2,374.9 ns |  2.60 |    0.05 | 1.9493 |     - |     - |      4 KB |
|     StructLinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 |   939.8 ns |   8.01 ns |   7.50 ns |   942.1 ns |  1.03 |    0.01 | 1.9226 |     - |     - |      4 KB |
|                Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,208.7 ns |  44.14 ns | 117.82 ns | 2,134.0 ns |  2.39 |    0.12 | 1.9226 |     - |     - |      4 KB |
|      Hyperlinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 | 1,057.8 ns |   9.05 ns |   8.02 ns | 1,057.3 ns |  1.15 |    0.02 | 1.9226 |     - |     - |      4 KB |
|           Hyperlinq_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   484.9 ns |   7.51 ns |   6.66 ns |   484.3 ns |  0.53 |    0.01 | 1.9150 |     - |     - |      4 KB |
| Hyperlinq_IFunction_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   298.1 ns |  10.75 ns |  31.71 ns |   291.3 ns |  0.37 |    0.02 | 1.9155 |     - |     - |      4 KB |
|                          |        |          |       |       |            |           |           |            |       |         |        |       |       |           |
|                  ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 |   935.4 ns |  13.99 ns |  12.40 ns |   929.3 ns |  1.00 |    0.00 | 1.9226 |     - |     - |      4 KB |
|                     Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,117.1 ns |  14.17 ns |  13.25 ns | 2,119.9 ns |  2.27 |    0.03 | 1.9646 |     - |     - |      4 KB |
|               LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 | 2,761.2 ns |  24.75 ns |  23.15 ns | 2,754.0 ns |  2.95 |    0.04 | 3.8452 |     - |     - |      8 KB |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 2,731.2 ns |  17.67 ns |  13.79 ns | 2,730.4 ns |  2.92 |    0.04 | 3.8452 |     - |     - |      8 KB |
|                   LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 5,610.0 ns | 111.64 ns | 245.05 ns | 5,483.8 ns |  6.42 |    0.20 | 5.9280 |     - |     - |     12 KB |
|               StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,012.9 ns |  39.74 ns |  42.52 ns | 2,017.1 ns |  2.15 |    0.06 | 1.9493 |     - |     - |      4 KB |
|     StructLinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 |   784.5 ns |  11.99 ns |  10.63 ns |   783.6 ns |  0.84 |    0.02 | 1.9226 |     - |     - |      4 KB |
|                Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,340.3 ns |  45.17 ns |  64.78 ns | 2,359.7 ns |  2.49 |    0.11 | 1.9226 |     - |     - |      4 KB |
|      Hyperlinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 | 1,057.2 ns |   8.07 ns |   7.15 ns | 1,060.4 ns |  1.13 |    0.02 | 1.9226 |     - |     - |      4 KB |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 2,116.6 ns |  14.81 ns |  12.37 ns | 2,112.1 ns |  2.27 |    0.03 | 1.9150 |     - |     - |      4 KB |
| Hyperlinq_IFunction_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 1,500.5 ns |  10.18 ns |   9.52 ns | 1,499.7 ns |  1.60 |    0.02 | 1.9150 |     - |     - |      4 KB |
