## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                    Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **71.069 ns** |  **0.1759 ns** |  **0.1559 ns** |  **5.27** |    **0.03** | **0.0305** |     **-** |     **-** |      **64 B** |
|           ValueLinq_Stack |     0 |    10 |    40.938 ns |  0.1114 ns |  0.1042 ns |  3.04 |    0.02 | 0.0306 |     - |     - |      64 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   162.571 ns |  0.4223 ns |  0.3743 ns | 12.06 |    0.07 | 0.0305 |     - |     - |      64 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   162.350 ns |  0.5565 ns |  0.4647 ns | 12.05 |    0.07 | 0.0305 |     - |     - |      64 B |
|                   ForLoop |     0 |    10 |    13.484 ns |  0.0755 ns |  0.0706 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                      Linq |     0 |    10 |    24.350 ns |  0.0698 ns |  0.0618 ns |  1.81 |    0.01 | 0.0497 |     - |     - |     104 B |
|                LinqFaster |     0 |    10 |     9.011 ns |  0.0196 ns |  0.0163 ns |  0.67 |    0.00 | 0.0306 |     - |     - |      64 B |
|           LinqFaster_SIMD |     0 |    10 |    14.231 ns |  0.0497 ns |  0.0465 ns |  1.06 |    0.01 | 0.0306 |     - |     - |      64 B |
|                    LinqAF |     0 |    10 |    49.630 ns |  0.1038 ns |  0.0971 ns |  3.68 |    0.02 | 0.0305 |     - |     - |      64 B |
|                StructLinq |     0 |    10 |    12.737 ns |  0.0628 ns |  0.0556 ns |  0.94 |    0.01 | 0.0306 |     - |     - |      64 B |
|                 Hyperlinq |     0 |    10 |    15.528 ns |  0.1043 ns |  0.0871 ns |  1.15 |    0.01 | 0.0306 |     - |     - |      64 B |
|                           |       |       |              |            |            |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **1,734.927 ns** | **11.0628 ns** | **10.3481 ns** |  **1.42** |    **0.01** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,241.276 ns |  9.7074 ns |  8.6054 ns |  1.83 |    0.01 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,349.354 ns | 10.7667 ns | 10.0712 ns |  1.92 |    0.01 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,145.535 ns |  8.6041 ns |  7.6274 ns |  1.75 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                   ForLoop |     0 |  1000 | 1,223.837 ns |  5.1519 ns |  4.8191 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                      Linq |     0 |  1000 |   588.536 ns |  6.1097 ns |  5.4161 ns |  0.48 |    0.00 | 1.9417 |     - |     - |   4,064 B |
|                LinqFaster |     0 |  1000 |   589.684 ns |  2.0965 ns |  1.6368 ns |  0.48 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|           LinqFaster_SIMD |     0 |  1000 |   262.011 ns |  5.1570 ns |  4.8238 ns |  0.21 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                    LinqAF |     0 |  1000 | 2,330.599 ns |  9.0445 ns |  8.4603 ns |  1.90 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                StructLinq |     0 |  1000 |   962.970 ns |  5.3528 ns |  5.0070 ns |  0.79 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                 Hyperlinq |     0 |  1000 |   260.709 ns |  5.1419 ns |  5.2803 ns |  0.21 |    0.00 | 1.9226 |     - |     - |   4,024 B |
