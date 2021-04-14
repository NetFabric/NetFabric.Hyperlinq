## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method |    Job |  Runtime | Start | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------- |--------- |------ |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop | .NET 5 | .NET 5.0 |     0 |  1000 |   284.7 ns |  0.91 ns |  0.71 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 4,516.9 ns | 20.96 ns | 19.61 ns | 15.87 |    0.07 | 0.0229 |     - |     - |      56 B |
|            Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 4,015.0 ns | 31.00 ns | 27.48 ns | 14.10 |    0.10 | 0.0153 |     - |     - |      40 B |
|      LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 1,269.2 ns | 23.86 ns | 24.51 ns |  4.47 |    0.09 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   817.5 ns |  9.13 ns |  7.62 ns |  2.87 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 1,605.7 ns |  5.53 ns |  4.32 ns |  5.64 |    0.02 |      - |     - |     - |         - |
|      StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 |   286.5 ns |  1.85 ns |  1.73 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 |   304.2 ns |  2.51 ns |  2.23 ns |  1.07 |    0.01 |      - |     - |     - |         - |
|                 |        |          |       |       |            |          |          |       |         |        |       |       |           |
|         ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 |   288.5 ns |  1.49 ns |  1.32 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 2,926.5 ns | 16.59 ns | 14.70 ns | 10.15 |    0.08 | 0.0267 |     - |     - |      56 B |
|            Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,412.4 ns | 24.67 ns | 23.08 ns |  8.36 |    0.09 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 | 1,280.2 ns | 25.19 ns | 24.74 ns |  4.44 |    0.09 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 |   857.6 ns |  9.21 ns |  8.61 ns |  2.97 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 1,613.3 ns | 11.85 ns | 10.50 ns |  5.59 |    0.05 |      - |     - |     - |         - |
|      StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 |   281.3 ns |  3.62 ns |  3.21 ns |  0.98 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 |   304.8 ns |  2.07 ns |  1.83 ns |  1.06 |    0.01 |      - |     - |     - |         - |
