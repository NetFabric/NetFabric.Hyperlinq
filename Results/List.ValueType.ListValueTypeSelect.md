## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop |   100 |  1.797 μs | 0.0053 μs | 0.0044 μs |  1.00 |    0.00 |       - |      - |     - |         - |
|              ForeachLoop |   100 |  1.934 μs | 0.0065 μs | 0.0061 μs |  1.08 |    0.00 |       - |      - |     - |         - |
|                     Linq |   100 |  2.610 μs | 0.0091 μs | 0.0085 μs |  1.45 |    0.01 |  0.0877 |      - |     - |     184 B |
|               LinqFaster |   100 |  2.786 μs | 0.0371 μs | 0.0290 μs |  1.55 |    0.02 |  3.0861 |      - |     - |   6,456 B |
|                   LinqAF |   100 |  3.498 μs | 0.0485 μs | 0.0454 μs |  1.95 |    0.03 |       - |      - |     - |         - |
|            LinqOptimizer |   100 | 48.271 μs | 0.6463 μs | 0.6045 μs | 26.82 |    0.35 | 74.0356 | 0.0610 |     - | 157,635 B |
|                  Streams |   100 | 10.852 μs | 0.1802 μs | 0.1597 μs |  6.04 |    0.09 |  0.3967 |      - |     - |     848 B |
|               StructLinq |   100 |  1.865 μs | 0.0042 μs | 0.0035 μs |  1.04 |    0.00 |  0.0191 |      - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |  1.845 μs | 0.0049 μs | 0.0043 μs |  1.03 |    0.00 |       - |      - |     - |         - |
|                Hyperlinq |   100 |  1.979 μs | 0.0053 μs | 0.0047 μs |  1.10 |    0.00 |       - |      - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.743 μs | 0.0049 μs | 0.0046 μs |  0.97 |    0.00 |       - |      - |     - |         - |
