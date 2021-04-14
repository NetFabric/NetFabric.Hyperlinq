## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  8.906 μs | 0.0317 μs | 0.0281 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  9.861 μs | 0.0344 μs | 0.0288 μs |  1.11 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 16.392 μs | 0.0782 μs | 0.0653 μs |  1.84 |    0.01 |  0.0916 |       - |     - |     216 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 18.106 μs | 0.2924 μs | 0.2872 μs |  2.04 |    0.04 | 45.4407 |       - |     - |  96,240 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 23.445 μs | 0.2387 μs | 0.2232 μs |  2.63 |    0.02 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 97.922 μs | 1.4994 μs | 1.3291 μs | 10.99 |    0.16 | 68.1152 | 22.7051 |     - | 185,369 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 65.554 μs | 0.4547 μs | 0.3797 μs |  7.36 |    0.05 |  0.3662 |       - |     - |     976 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 12.826 μs | 0.1049 μs | 0.0930 μs |  1.44 |    0.01 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11.631 μs | 0.1513 μs | 0.1415 μs |  1.31 |    0.02 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 17.200 μs | 0.0588 μs | 0.0521 μs |  1.93 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 12.808 μs | 0.0389 μs | 0.0344 μs |  1.44 |    0.01 |       - |       - |     - |         - |
|                      |        |          |       |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  8.815 μs | 0.0256 μs | 0.0214 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 10.135 μs | 0.0454 μs | 0.0403 μs |  1.15 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 16.083 μs | 0.0716 μs | 0.0669 μs |  1.82 |    0.01 |  0.0916 |       - |     - |     216 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 18.371 μs | 0.1842 μs | 0.1723 μs |  2.09 |    0.02 | 45.4407 |       - |     - |  96,240 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 23.856 μs | 0.1846 μs | 0.1637 μs |  2.71 |    0.02 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 76.059 μs | 0.7757 μs | 0.6876 μs |  8.62 |    0.07 | 68.1152 | 22.7051 |     - | 185,113 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 64.475 μs | 0.2466 μs | 0.2186 μs |  7.31 |    0.02 |  0.3662 |       - |     - |     976 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 11.783 μs | 0.0906 μs | 0.0757 μs |  1.34 |    0.01 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 10.198 μs | 0.0298 μs | 0.0264 μs |  1.16 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 17.732 μs | 0.1022 μs | 0.0853 μs |  2.01 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 12.764 μs | 0.1856 μs | 0.1550 μs |  1.45 |    0.02 |       - |       - |     - |         - |
