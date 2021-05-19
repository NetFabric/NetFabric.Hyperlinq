## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |  1.761 μs | 0.0058 μs | 0.0048 μs |  1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  2.447 μs | 0.0119 μs | 0.0100 μs |  1.39 |    0.01 |  0.1526 |     - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  4.852 μs | 0.0919 μs | 0.0860 μs |  2.75 |    0.05 |  9.2545 |     - |     - |  19,368 B |
|             LinqFasterer | 1000 |   100 |  8.602 μs | 0.1687 μs | 0.2134 μs |  4.85 |    0.12 | 38.4521 |     - |     - |  83,304 B |
|                   LinqAF | 1000 |   100 | 13.472 μs | 0.1281 μs | 0.1069 μs |  7.65 |    0.05 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 67.262 μs | 0.6874 μs | 0.6094 μs | 38.19 |    0.32 | 76.5381 |     - |     - | 161,837 B |
|                  Streams | 1000 |   100 | 19.065 μs | 0.1068 μs | 0.0947 μs | 10.83 |    0.07 |  0.5493 |     - |     - |   1,176 B |
|               StructLinq | 1000 |   100 |  1.972 μs | 0.0125 μs | 0.0117 μs |  1.12 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.824 μs | 0.0037 μs | 0.0031 μs |  1.04 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1.993 μs | 0.0088 μs | 0.0078 μs |  1.13 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.763 μs | 0.0092 μs | 0.0077 μs |  1.00 |    0.01 |       - |     - |     - |         - |
