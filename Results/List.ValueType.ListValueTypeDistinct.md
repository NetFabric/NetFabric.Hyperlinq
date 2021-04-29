## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 15.724 μs | 0.1008 μs | 0.0894 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,976 B |
|              ForeachLoop |          4 |   100 | 14.471 μs | 0.0799 μs | 0.0747 μs |  0.92 |    0.01 | 12.8174 |     - |     - |  26,976 B |
|                     Linq |          4 |   100 | 16.134 μs | 0.1282 μs | 0.1199 μs |  1.03 |    0.01 | 12.8174 |     - |     - |  26,912 B |
|               LinqFaster |          4 |   100 |  2.905 μs | 0.0093 μs | 0.0073 μs |  0.18 |    0.00 |  0.0114 |     - |     - |      24 B |
|                   LinqAF |          4 |   100 | 62.477 μs | 0.3080 μs | 0.2730 μs |  3.97 |    0.03 | 20.2637 |     - |     - |  42,632 B |
|               StructLinq |          4 |   100 | 14.479 μs | 0.0553 μs | 0.0491 μs |  0.92 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.034 μs | 0.0279 μs | 0.0247 μs |  0.32 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 19.601 μs | 0.0987 μs | 0.0875 μs |  1.25 |    0.01 |       - |     - |     - |         - |
