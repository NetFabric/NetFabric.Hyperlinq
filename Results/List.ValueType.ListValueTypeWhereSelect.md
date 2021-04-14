## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  9.750 μs | 0.0231 μs | 0.0180 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 12.205 μs | 0.0449 μs | 0.0398 μs |  1.25 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 19.943 μs | 0.1919 μs | 0.1602 μs |  2.04 |    0.02 |  0.1526 |       - |     - |     376 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 23.038 μs | 0.3167 μs | 0.5710 μs |  2.38 |    0.09 | 31.2195 |       - |     - |  65,504 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 28.532 μs | 0.3049 μs | 0.2703 μs |  2.92 |    0.03 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 92.409 μs | 0.6390 μs | 0.8530 μs |  9.46 |    0.06 | 68.1152 | 22.7051 |     - | 186,528 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 68.378 μs | 1.3240 μs | 1.6260 μs |  6.94 |    0.19 |  0.3662 |       - |     - |   1,000 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 12.482 μs | 0.1776 μs | 0.1575 μs |  1.28 |    0.02 |  0.0305 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 10.727 μs | 0.0421 μs | 0.0394 μs |  1.10 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 17.616 μs | 0.0334 μs | 0.0296 μs |  1.81 |    0.00 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 12.776 μs | 0.0428 μs | 0.0357 μs |  1.31 |    0.00 |       - |       - |     - |         - |
|                      |        |          |       |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 10.728 μs | 0.0353 μs | 0.0313 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 12.429 μs | 0.0527 μs | 0.0467 μs |  1.16 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 20.456 μs | 0.1302 μs | 0.1218 μs |  1.91 |    0.01 |  0.1526 |       - |     - |     376 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 23.041 μs | 0.4537 μs | 0.4244 μs |  2.15 |    0.04 | 31.2195 |       - |     - |  65,504 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 28.541 μs | 0.3288 μs | 0.3075 μs |  2.66 |    0.03 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 85.796 μs | 0.6724 μs | 0.5960 μs |  8.00 |    0.07 | 68.1152 | 22.7051 |     - | 186,080 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 67.774 μs | 0.5469 μs | 0.5116 μs |  6.32 |    0.05 |  0.3662 |       - |     - |   1,000 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 11.539 μs | 0.0218 μs | 0.0204 μs |  1.08 |    0.00 |  0.0305 |       - |     - |      72 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 10.231 μs | 0.0314 μs | 0.0262 μs |  0.95 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 18.011 μs | 0.0517 μs | 0.0432 μs |  1.68 |    0.00 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 13.123 μs | 0.0836 μs | 0.0741 μs |  1.22 |    0.01 |       - |       - |     - |         - |
