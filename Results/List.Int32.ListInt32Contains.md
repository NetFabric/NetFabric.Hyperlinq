## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|               Method |    Job |  Runtime | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 | 1,044.3 ns |  2.20 ns |  1.84 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 2,389.5 ns | 11.95 ns | 11.18 ns |  2.29 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |   401.5 ns |  1.71 ns |  1.60 ns |  0.38 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |   398.3 ns |  1.21 ns |  1.07 ns |  0.38 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |   398.5 ns |  1.43 ns |  1.12 ns |  0.38 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |   550.0 ns |  2.43 ns |  2.03 ns |  0.53 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 1,047.0 ns |  2.86 ns |  2.67 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |   397.7 ns |  1.68 ns |  1.40 ns |  0.38 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 |   114.9 ns |  0.74 ns |  0.65 ns |  0.11 |      - |     - |     - |         - |
|                      |        |          |       |            |          |          |       |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 1,049.3 ns |  4.08 ns |  3.40 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 1,564.1 ns |  5.94 ns |  4.96 ns |  1.49 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |   177.0 ns |  0.58 ns |  0.54 ns |  0.17 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |   272.3 ns |  1.17 ns |  0.98 ns |  0.26 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |   175.8 ns |  0.63 ns |  0.59 ns |  0.17 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |   569.9 ns |  1.37 ns |  1.14 ns |  0.54 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |   536.4 ns |  2.96 ns |  2.47 ns |  0.51 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |   183.9 ns |  0.85 ns |  0.76 ns |  0.18 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 |   118.3 ns |  0.69 ns |  0.61 ns |  0.11 |      - |     - |     - |         - |
