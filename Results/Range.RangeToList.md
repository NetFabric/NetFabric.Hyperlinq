## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|      Method |    Job |  Runtime | Start | Count |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------- |--------- |------ |------ |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 2,311.1 ns | 19.38 ns |  16.18 ns | 2,310.0 ns |  1.00 |    0.00 | 4.0207 |     - |     - |      8 KB |
| ForeachLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 5,947.5 ns | 35.92 ns |  29.99 ns | 5,947.2 ns |  2.57 |    0.02 | 4.0436 |     - |     - |      8 KB |
|        Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 2,052.0 ns | 23.91 ns |  21.19 ns | 2,046.8 ns |  0.89 |    0.01 | 1.9569 |     - |     - |      4 KB |
|  LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 1,068.5 ns | 21.43 ns |  19.00 ns | 1,069.9 ns |  0.46 |    0.01 | 3.8605 |     - |     - |      8 KB |
|      LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 3,055.4 ns | 60.92 ns | 139.97 ns | 2,982.5 ns |  1.34 |    0.06 | 1.9379 |     - |     - |      4 KB |
|  StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 |   865.5 ns |  8.38 ns |   7.84 ns |   865.6 ns |  0.37 |    0.00 | 1.9379 |     - |     - |      4 KB |
|   Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 |   310.6 ns |  6.24 ns |  12.32 ns |   307.5 ns |  0.14 |    0.00 | 1.9379 |     - |     - |      4 KB |
|             |        |          |       |       |            |          |           |            |       |         |        |       |       |           |
|     ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 2,596.5 ns | 18.52 ns |  16.41 ns | 2,596.7 ns |  1.00 |    0.00 | 4.0207 |     - |     - |      8 KB |
| ForeachLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 4,027.7 ns | 52.37 ns |  43.73 ns | 4,008.0 ns |  1.55 |    0.02 | 4.0436 |     - |     - |      8 KB |
|        Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 1,665.2 ns | 13.40 ns |  11.19 ns | 1,661.8 ns |  0.64 |    0.01 | 1.9569 |     - |     - |      4 KB |
|  LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 |   972.8 ns | 18.15 ns |  17.82 ns |   974.6 ns |  0.38 |    0.01 | 3.8605 |     - |     - |      8 KB |
|      LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 2,273.9 ns | 21.93 ns |  17.12 ns | 2,271.9 ns |  0.88 |    0.01 | 1.9379 |     - |     - |      4 KB |
|  StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 |   760.6 ns |  8.19 ns |  14.77 ns |   760.1 ns |  0.30 |    0.01 | 1.9379 |     - |     - |      4 KB |
|   Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 |   331.6 ns |  8.89 ns |  26.21 ns |   331.2 ns |  0.14 |    0.01 | 1.9379 |     - |     - |      4 KB |
