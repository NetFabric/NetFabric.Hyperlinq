## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|               Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 | 529.18 ns |  6.682 ns |  5.217 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 532.97 ns |  9.329 ns |  9.982 ns |  1.01 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 407.00 ns |  3.556 ns |  3.152 ns |  0.77 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 407.01 ns |  7.754 ns |  7.616 ns |  0.77 |    0.02 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5 | .NET 5.0 |  1000 | 109.34 ns |  1.816 ns |  1.699 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 408.43 ns |  6.792 ns |  6.353 ns |  0.77 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 584.08 ns | 10.661 ns | 14.945 ns |  1.10 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 567.06 ns | 11.370 ns | 14.784 ns |  1.07 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 406.15 ns |  4.967 ns |  4.646 ns |  0.77 |    0.02 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 | 115.80 ns |  2.382 ns |  3.491 ns |  0.22 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |           |           |           |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 360.37 ns |  5.030 ns |  4.201 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 356.94 ns |  2.706 ns |  2.260 ns |  0.99 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 283.83 ns |  5.707 ns |  8.001 ns |  0.79 |    0.02 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 180.65 ns |  0.973 ns |  0.760 ns |  0.50 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6 | .NET 6.0 |  1000 |  85.58 ns |  0.505 ns |  0.422 ns |  0.24 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 180.29 ns |  3.095 ns |  2.744 ns |  0.50 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 539.34 ns |  2.089 ns |  1.954 ns |  1.50 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 525.27 ns |  2.847 ns |  2.223 ns |  1.46 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 272.87 ns |  0.885 ns |  0.739 ns |  0.76 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 | 113.99 ns |  0.261 ns |  0.204 ns |  0.32 |    0.00 |      - |     - |     - |         - |
