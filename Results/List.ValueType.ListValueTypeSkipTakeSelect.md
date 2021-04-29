## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                          Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|-------------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                         ForLoop | 1000 |   100 |  1.770 μs | 0.0073 μs | 0.0068 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                     ForeachLoop | 1000 |   100 |  7.243 μs | 0.0259 μs | 0.0229 μs |  4.09 |    0.02 |  0.0458 |       - |     - |      96 B |
|                            Linq | 1000 |   100 |  2.399 μs | 0.0096 μs | 0.0080 μs |  1.36 |    0.01 |  0.1526 |       - |     - |     320 B |
|                      LinqFaster | 1000 |   100 |  4.703 μs | 0.0717 μs | 0.0670 μs |  2.66 |    0.03 |  9.2545 |       - |     - |  19,368 B |
|                          LinqAF | 1000 |   100 | 12.844 μs | 0.1997 μs | 0.1868 μs |  7.26 |    0.11 |       - |       - |     - |         - |
|                   LinqOptimizer | 1000 |   100 | 66.970 μs | 0.8140 μs | 0.7614 μs | 37.83 |    0.46 | 72.6318 | 18.0664 |     - | 161,833 B |
|                         Streams | 1000 |   100 | 19.090 μs | 0.1220 μs | 0.1019 μs | 10.79 |    0.06 |  0.5493 |       - |     - |   1,176 B |
|                      StructLinq | 1000 |   100 |  1.938 μs | 0.0082 μs | 0.0076 μs |  1.09 |    0.01 |  0.0572 |       - |     - |     120 B |
|        StructLinq_ValueDelegate | 1000 |   100 |  1.863 μs | 0.0097 μs | 0.0081 μs |  1.05 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_Foreach | 1000 |   100 |  1.990 μs | 0.0048 μs | 0.0040 μs |  1.12 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_ValueDelegate | 1000 |   100 |  1.759 μs | 0.0058 μs | 0.0054 μs |  0.99 |    0.00 |       - |       - |     - |         - |
|                   Hyperlinq_For | 1000 |   100 |  1.980 μs | 0.0049 μs | 0.0041 μs |  1.12 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_ValueDelegate | 1000 |   100 |  1.740 μs | 0.0031 μs | 0.0027 μs |  0.98 |    0.00 |       - |       - |     - |         - |
