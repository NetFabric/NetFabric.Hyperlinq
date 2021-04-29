## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                       Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    349.91 ns |   4.396 ns |   4.112 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    323.51 ns |   2.195 ns |   2.053 ns |   0.92 |    0.01 |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    329.32 ns |   1.407 ns |   1.175 ns |   0.94 |    0.01 |  0.2522 |     - |     - |     528 B |
|                   LinqFaster |   100 |    352.52 ns |   1.768 ns |   1.653 ns |   1.01 |    0.01 |  0.4358 |     - |     - |     912 B |
|                 LinqFasterer |   100 |    319.97 ns |   1.568 ns |   1.390 ns |   0.91 |    0.01 |  0.6232 |     - |     - |   1,304 B |
|                       LinqAF |   100 |  1,116.35 ns |   5.874 ns |   5.494 ns |   3.19 |    0.04 |  0.5646 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 38,540.77 ns | 183.807 ns | 153.487 ns | 110.36 |    1.39 | 13.9771 |     - |     - |  29,360 B |
|                      Streams |   100 |  1,460.51 ns |   7.911 ns |   7.400 ns |   4.17 |    0.05 |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    253.26 ns |   1.738 ns |   1.541 ns |   0.72 |    0.01 |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    136.13 ns |   1.215 ns |   1.137 ns |   0.39 |    0.01 |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    239.69 ns |   2.636 ns |   2.466 ns |   0.69 |    0.01 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    113.54 ns |   1.029 ns |   0.962 ns |   0.32 |    0.00 |  0.2180 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |     96.93 ns |   0.667 ns |   0.557 ns |   0.28 |    0.00 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     63.19 ns |   0.417 ns |   0.370 ns |   0.18 |    0.00 |  0.2180 |     - |     - |     456 B |
