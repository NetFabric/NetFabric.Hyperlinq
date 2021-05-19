## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|                     Linq | 1000 |   100 |  3.139 μs | 0.0100 μs | 0.0083 μs |  1.00 |    0.00 |  0.0992 |     - |     - |     208 B |
|                   LinqAF | 1000 |   100 |  3.418 μs | 0.0230 μs | 0.0203 μs |  1.09 |    0.01 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer | 1000 |   100 | 54.703 μs | 0.4066 μs | 0.4519 μs | 17.45 |    0.17 | 15.8691 |     - |     - |  33,421 B |
|                  Streams | 1000 |   100 |  8.178 μs | 0.0548 μs | 0.0513 μs |  2.60 |    0.02 |  0.4272 |     - |     - |     920 B |
|               StructLinq | 1000 |   100 |  2.914 μs | 0.0153 μs | 0.0135 μs |  0.93 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  2.908 μs | 0.0147 μs | 0.0130 μs |  0.93 |    0.00 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq | 1000 |   100 |  2.709 μs | 0.0111 μs | 0.0093 μs |  0.86 |    0.00 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  3.445 μs | 0.0415 μs | 0.0346 μs |  1.10 |    0.01 |  0.0153 |     - |     - |      40 B |
