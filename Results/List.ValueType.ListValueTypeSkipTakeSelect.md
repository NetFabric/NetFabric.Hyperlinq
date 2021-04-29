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
|                   Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop | 1000 |   100 |  1.788 μs | 0.0069 μs | 0.0058 μs |  1.00 |    0.00 |       - |      - |     - |         - |
|                     Linq | 1000 |   100 |  2.426 μs | 0.0098 μs | 0.0092 μs |  1.36 |    0.01 |  0.1526 |      - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  4.986 μs | 0.0619 μs | 0.0579 μs |  2.79 |    0.04 |  9.2545 |      - |     - |  19,368 B |
|             LinqFasterer | 1000 |   100 |  7.933 μs | 0.1497 μs | 0.1470 μs |  4.43 |    0.09 | 38.4521 |      - |     - |  83,304 B |
|                   LinqAF | 1000 |   100 | 12.982 μs | 0.2593 μs | 0.3372 μs |  7.28 |    0.18 |       - |      - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 67.403 μs | 0.5680 μs | 0.5313 μs | 37.70 |    0.34 | 76.6602 | 0.4883 |     - | 161,837 B |
|                  Streams | 1000 |   100 | 19.601 μs | 0.0949 μs | 0.0741 μs | 10.96 |    0.05 |  0.5493 |      - |     - |   1,176 B |
|               StructLinq | 1000 |   100 |  1.930 μs | 0.0088 μs | 0.0082 μs |  1.08 |    0.00 |  0.0572 |      - |     - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.889 μs | 0.0071 μs | 0.0067 μs |  1.06 |    0.00 |       - |      - |     - |         - |
|                Hyperlinq | 1000 |   100 |  2.030 μs | 0.0097 μs | 0.0091 μs |  1.14 |    0.00 |       - |      - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.774 μs | 0.0066 μs | 0.0059 μs |  0.99 |    0.00 |       - |      - |     - |         - |
