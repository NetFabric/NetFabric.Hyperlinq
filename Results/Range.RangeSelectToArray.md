## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 |   358.00 ns |  5.590 ns |  4.955 ns |  4.38 |    0.06 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 |   701.26 ns | 13.958 ns | 13.709 ns |  8.58 |    0.18 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 |   731.49 ns | 11.001 ns |  9.186 ns |  8.94 |    0.13 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 |   795.54 ns | 11.519 ns | 10.775 ns |  9.73 |    0.13 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 |   253.40 ns |  0.729 ns |  0.609 ns |  3.10 |    0.01 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 |   416.30 ns |  2.072 ns |  1.837 ns |  5.09 |    0.02 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 |   424.51 ns |  0.683 ns |  0.605 ns |  5.19 |    0.02 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 |   504.25 ns |  2.544 ns |  2.255 ns |  6.17 |    0.03 | 0.2022 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |    81.79 ns |  0.256 ns |  0.227 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 |   345.19 ns |  4.415 ns |  4.130 ns |  4.22 |    0.06 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 |   351.07 ns |  2.275 ns |  2.017 ns |  4.29 |    0.03 | 0.4053 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 1,113.93 ns | 20.471 ns | 19.149 ns | 13.62 |    0.24 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 |   314.25 ns |  4.820 ns |  4.273 ns |  3.84 |    0.05 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |    92.02 ns |  0.386 ns |  0.342 ns |  1.13 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 |   303.23 ns |  3.302 ns |  2.927 ns |  3.71 |    0.04 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 |   111.24 ns |  0.498 ns |  0.442 ns |  1.36 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 |   512.04 ns | 10.238 ns | 26.245 ns |  6.40 |    0.32 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 |   195.84 ns |  1.249 ns |  1.108 ns |  2.39 |    0.02 | 0.0267 |     - |     - |      56 B |
