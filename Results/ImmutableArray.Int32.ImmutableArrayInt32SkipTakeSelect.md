## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                      Method |    Job |  Runtime | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |    787.0 ns |   5.55 ns |   4.92 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  5,589.2 ns |  30.13 ns |  25.16 ns |  7.11 |    0.04 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 14,890.8 ns |  99.62 ns |  88.31 ns | 18.92 |    0.19 |  0.0763 |     - |     - |     176 B |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 70,289.3 ns | 494.95 ns | 462.97 ns | 89.34 |    0.59 | 17.3340 |     - |     - |  36,862 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 30,729.5 ns | 262.12 ns | 245.18 ns | 39.04 |    0.42 |  0.4272 |     - |     - |     936 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  3,232.4 ns |  13.05 ns |  11.57 ns |  4.11 |    0.03 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,869.9 ns |   6.00 ns |   5.32 ns |  2.38 |    0.02 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,154.2 ns |  13.16 ns |  11.67 ns |  2.74 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,678.1 ns |   4.59 ns |   4.07 ns |  2.13 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,499.6 ns |  11.48 ns |  10.74 ns |  3.18 |    0.03 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,594.7 ns |   5.83 ns |   4.87 ns |  2.03 |    0.01 |       - |     - |     - |         - |
|                             |        |          |      |       |             |           |           |       |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |    790.9 ns |   5.59 ns |   5.23 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  4,210.4 ns |   6.60 ns |   6.18 ns |  5.32 |    0.04 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  9,814.9 ns |  68.01 ns |  56.79 ns | 12.40 |    0.12 |  0.0763 |     - |     - |     176 B |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 60,731.1 ns | 478.78 ns | 447.85 ns | 76.79 |    0.78 | 17.3340 |     - |     - |  36,422 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 23,446.3 ns |  84.54 ns |  79.08 ns | 29.65 |    0.23 |  0.4272 |     - |     - |     936 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,654.8 ns |   7.74 ns |   6.86 ns |  2.09 |    0.02 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,556.6 ns |   4.25 ns |   3.77 ns |  1.97 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,151.1 ns |   8.88 ns |   7.41 ns |  2.72 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,670.5 ns |   6.94 ns |   6.50 ns |  2.11 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,868.4 ns |   3.63 ns |   3.03 ns |  2.36 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,595.7 ns |   6.44 ns |   5.38 ns |  2.02 |    0.02 |       - |     - |     - |         - |
