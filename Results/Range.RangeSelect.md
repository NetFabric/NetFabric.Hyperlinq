## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|               Method |    Job |  Runtime | Start | Count |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------ |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |     0 |  1000 |   378.9 ns |  4.24 ns |   3.76 ns |   377.1 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 4,809.6 ns | 20.06 ns |  17.79 ns | 4,813.1 ns | 12.70 |    0.14 | 0.0229 |     - |     - |      56 B |
|                 Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 6,363.6 ns | 45.89 ns |  35.83 ns | 6,351.9 ns | 16.83 |    0.10 | 0.0381 |     - |     - |      88 B |
|           LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 3,022.3 ns | 24.79 ns |  20.70 ns | 3,022.3 ns |  7.98 |    0.09 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 | 1,498.0 ns | 35.83 ns | 105.64 ns | 1,442.8 ns |  4.12 |    0.23 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 4,948.3 ns | 23.98 ns |  21.26 ns | 4,941.6 ns | 13.06 |    0.13 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 | 1,858.8 ns |  6.38 ns |   4.98 ns | 1,857.0 ns |  4.92 |    0.05 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 | 1,701.0 ns | 20.52 ns |  19.20 ns | 1,707.2 ns |  4.50 |    0.08 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 | 1,598.1 ns |  8.74 ns |   8.18 ns | 1,595.7 ns |  4.22 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 | 1,686.1 ns |  1.65 ns |   1.38 ns | 1,686.6 ns |  4.45 |    0.05 |      - |     - |     - |         - |
|                      |        |          |       |       |            |          |           |            |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 |   390.2 ns |  1.34 ns |   1.25 ns |   390.4 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 2,906.0 ns | 13.69 ns |  11.44 ns | 2,907.2 ns |  7.45 |    0.02 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 3,742.7 ns | 34.99 ns |  29.22 ns | 3,738.4 ns |  9.59 |    0.09 | 0.0420 |     - |     - |      88 B |
|           LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 | 3,404.1 ns | 23.01 ns |  20.39 ns | 3,406.1 ns |  8.72 |    0.06 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 3,062.1 ns | 33.74 ns |  29.91 ns | 3,048.6 ns |  7.85 |    0.07 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 4,489.0 ns | 31.44 ns |  26.25 ns | 4,484.8 ns | 11.51 |    0.09 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 | 1,601.4 ns |  8.54 ns |   7.57 ns | 1,601.0 ns |  4.10 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 | 1,679.2 ns |  3.35 ns |   2.97 ns | 1,679.6 ns |  4.30 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,129.2 ns |  8.06 ns |   7.54 ns | 2,130.0 ns |  5.46 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 | 1,720.8 ns | 10.02 ns |   9.37 ns | 1,723.9 ns |  4.41 |    0.03 |      - |     - |     - |         - |
