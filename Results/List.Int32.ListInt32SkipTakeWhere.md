## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method |    Job |  Runtime | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  1.345 μs | 0.0082 μs | 0.0077 μs |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  7.774 μs | 0.0522 μs | 0.0488 μs |  5.78 |    0.04 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 16.183 μs | 0.0664 μs | 0.0588 μs | 12.02 |    0.10 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  8.263 μs | 0.0691 μs | 0.0539 μs |  6.14 |    0.04 |  5.9204 |     - |     - |  12,416 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 18.566 μs | 0.0615 μs | 0.0545 μs | 13.80 |    0.07 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 78.200 μs | 0.2970 μs | 0.2633 μs | 58.11 |    0.37 | 16.7236 |     - |     - |  35,120 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 24.993 μs | 0.1691 μs | 0.1412 μs | 18.57 |    0.13 |  0.4272 |     - |     - |     936 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  5.541 μs | 0.0283 μs | 0.0251 μs |  4.12 |    0.03 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1.597 μs | 0.0085 μs | 0.0080 μs |  1.19 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  4.344 μs | 0.0286 μs | 0.0254 μs |  3.23 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  2.115 μs | 0.0135 μs | 0.0113 μs |  1.57 |    0.01 |       - |     - |     - |         - |
|                      |        |          |      |       |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  1.215 μs | 0.0096 μs | 0.0085 μs |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  6.326 μs | 0.0254 μs | 0.0238 μs |  5.21 |    0.04 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  7.992 μs | 0.0546 μs | 0.0484 μs |  6.58 |    0.06 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  8.968 μs | 0.0679 μs | 0.0601 μs |  7.38 |    0.06 |  5.9204 |     - |     - |  12,416 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 20.373 μs | 0.0854 μs | 0.0799 μs | 16.76 |    0.14 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 70.281 μs | 0.4102 μs | 0.3837 μs | 57.86 |    0.58 | 16.4795 |     - |     - |  34,678 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 22.447 μs | 0.1117 μs | 0.0932 μs | 18.46 |    0.17 |  0.4272 |     - |     - |     936 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  3.849 μs | 0.0274 μs | 0.0229 μs |  3.17 |    0.03 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1.539 μs | 0.0136 μs | 0.0128 μs |  1.27 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  6.733 μs | 0.0149 μs | 0.0132 μs |  5.54 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  5.124 μs | 0.0167 μs | 0.0148 μs |  4.22 |    0.04 |       - |     - |     - |         - |
