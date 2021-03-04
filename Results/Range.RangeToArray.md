## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                    Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **74.255 ns** |  **0.4222 ns** |  **0.3743 ns** |  **5.38** |    **0.04** | **0.0305** |     **-** |     **-** |      **64 B** |
|           ValueLinq_Stack |     0 |    10 |    43.067 ns |  0.2975 ns |  0.2637 ns |  3.13 |    0.02 | 0.0306 |     - |     - |      64 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   164.827 ns |  0.4561 ns |  0.4266 ns | 11.96 |    0.06 | 0.0305 |     - |     - |      64 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   169.323 ns |  0.7070 ns |  0.6267 ns | 12.28 |    0.08 | 0.0305 |     - |     - |      64 B |
|                   ForLoop |     0 |    10 |    13.786 ns |  0.0700 ns |  0.0546 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                      Linq |     0 |    10 |    25.123 ns |  0.1026 ns |  0.0857 ns |  1.82 |    0.01 | 0.0497 |     - |     - |     104 B |
|                LinqFaster |     0 |    10 |     9.387 ns |  0.0584 ns |  0.0518 ns |  0.68 |    0.01 | 0.0306 |     - |     - |      64 B |
|           LinqFaster_SIMD |     0 |    10 |    14.770 ns |  0.1457 ns |  0.1292 ns |  1.07 |    0.01 | 0.0306 |     - |     - |      64 B |
|                    LinqAF |     0 |    10 |    51.277 ns |  0.2393 ns |  0.2121 ns |  3.72 |    0.02 | 0.0306 |     - |     - |      64 B |
|                StructLinq |     0 |    10 |    13.269 ns |  0.0661 ns |  0.0586 ns |  0.96 |    0.00 | 0.0306 |     - |     - |      64 B |
|                 Hyperlinq |     0 |    10 |    15.955 ns |  0.0607 ns |  0.0538 ns |  1.16 |    0.01 | 0.0306 |     - |     - |      64 B |
|                           |       |       |              |            |            |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **1,781.708 ns** |  **7.6224 ns** |  **6.3650 ns** |  **1.41** |    **0.00** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,327.652 ns | 13.4176 ns | 11.8944 ns |  1.85 |    0.01 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,435.487 ns | 11.4901 ns | 10.1857 ns |  1.93 |    0.01 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,205.880 ns | 12.2166 ns | 10.8297 ns |  1.75 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                   ForLoop |     0 |  1000 | 1,259.558 ns |  4.4139 ns |  3.9128 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                      Linq |     0 |  1000 |   616.744 ns |  7.2753 ns |  6.8053 ns |  0.49 |    0.01 | 1.9417 |     - |     - |   4,064 B |
|                LinqFaster |     0 |  1000 |   607.483 ns |  3.6216 ns |  3.2105 ns |  0.48 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|           LinqFaster_SIMD |     0 |  1000 |   271.022 ns |  4.8583 ns |  4.5445 ns |  0.21 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                    LinqAF |     0 |  1000 | 2,402.283 ns | 13.0938 ns | 11.6073 ns |  1.91 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                StructLinq |     0 |  1000 |   985.572 ns |  5.0145 ns |  4.1873 ns |  0.78 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                 Hyperlinq |     0 |  1000 |   272.264 ns |  5.4956 ns |  5.3974 ns |  0.22 |    0.00 | 1.9226 |     - |     - |   4,024 B |
