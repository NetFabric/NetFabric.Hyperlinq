## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  6.010 μs | 0.0226 μs | 0.0200 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  9.273 μs | 0.0348 μs | 0.0309 μs |  1.54 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 17.023 μs | 0.2026 μs | 0.1895 μs |  2.83 |    0.03 |  0.0610 |       - |     - |     184 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 17.276 μs | 0.2604 μs | 0.2308 μs |  2.87 |    0.04 | 31.2195 |       - |     - |  65,504 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 21.761 μs | 0.2512 μs | 0.2350 μs |  3.62 |    0.04 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 77.791 μs | 0.4105 μs | 0.3428 μs | 12.94 |    0.06 | 79.8340 | 19.8975 |     - | 184,191 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 22.734 μs | 0.1584 μs | 0.1404 μs |  3.78 |    0.03 |  0.3967 |       - |     - |     848 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  8.209 μs | 0.0298 μs | 0.0232 μs |  1.37 |    0.01 |  0.0153 |       - |     - |      40 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  6.764 μs | 0.0200 μs | 0.0167 μs |  1.13 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 14.014 μs | 0.0432 μs | 0.0383 μs |  2.33 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  8.458 μs | 0.0588 μs | 0.0491 μs |  1.41 |    0.01 |       - |       - |     - |         - |
|                      |        |          |       |           |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  7.502 μs | 0.0330 μs | 0.0293 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 11.794 μs | 0.0517 μs | 0.0484 μs |  1.57 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 15.825 μs | 0.1931 μs | 0.1712 μs |  2.11 |    0.02 |  0.0610 |       - |     - |     184 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 15.044 μs | 0.2936 μs | 0.2746 μs |  2.01 |    0.04 | 31.2195 |       - |     - |  65,504 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 20.995 μs | 0.1760 μs | 0.1646 μs |  2.80 |    0.03 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 76.209 μs | 0.5723 μs | 0.5353 μs | 10.16 |    0.09 | 86.9141 |  0.1221 |     - | 183,759 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 21.153 μs | 0.1178 μs | 0.1044 μs |  2.82 |    0.01 |  0.3967 |       - |     - |     848 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  7.633 μs | 0.0291 μs | 0.0272 μs |  1.02 |    0.01 |  0.0153 |       - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  5.625 μs | 0.0283 μs | 0.0265 μs |  0.75 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 12.112 μs | 0.1260 μs | 0.1179 μs |  1.61 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  8.345 μs | 0.0882 μs | 0.0782 μs |  1.11 |    0.01 |       - |       - |     - |         - |
