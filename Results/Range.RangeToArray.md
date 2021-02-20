## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                    Method | Start | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **77.50 ns** | **0.256 ns** | **0.240 ns** |  **6.12** |    **0.05** | **0.0305** |     **-** |     **-** |      **64 B** |
|           ValueLinq_Stack |     0 |    10 |    47.36 ns | 0.328 ns | 0.274 ns |  3.74 |    0.04 | 0.0306 |     - |     - |      64 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   161.76 ns | 0.429 ns | 0.380 ns | 12.76 |    0.11 | 0.0305 |     - |     - |      64 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   166.82 ns | 0.545 ns | 0.510 ns | 13.16 |    0.12 | 0.0305 |     - |     - |      64 B |
|                   ForLoop |     0 |    10 |    12.67 ns | 0.114 ns | 0.101 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                      Linq |     0 |    10 |    31.24 ns | 0.202 ns | 0.189 ns |  2.47 |    0.03 | 0.0497 |     - |     - |     104 B |
|                LinqFaster |     0 |    10 |    10.83 ns | 0.041 ns | 0.036 ns |  0.85 |    0.01 | 0.0306 |     - |     - |      64 B |
|           LinqFaster_SIMD |     0 |    10 |    14.01 ns | 0.058 ns | 0.049 ns |  1.11 |    0.01 | 0.0306 |     - |     - |      64 B |
|                    LinqAF |     0 |    10 |    51.81 ns | 0.155 ns | 0.130 ns |  4.09 |    0.03 | 0.0305 |     - |     - |      64 B |
|                StructLinq |     0 |    10 |    13.32 ns | 0.054 ns | 0.045 ns |  1.05 |    0.01 | 0.0306 |     - |     - |      64 B |
|                 Hyperlinq |     0 |    10 |    18.12 ns | 0.078 ns | 0.073 ns |  1.43 |    0.01 | 0.0306 |     - |     - |      64 B |
|                           |       |       |             |          |          |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **1,719.13 ns** | **9.985 ns** | **9.340 ns** |  **1.41** |    **0.01** | **1.9226** |     **-** |     **-** |    **4024 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,271.19 ns | 7.591 ns | 6.729 ns |  1.87 |    0.01 | 3.9177 |     - |     - |    8200 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,316.25 ns | 8.327 ns | 6.953 ns |  1.90 |    0.01 | 1.9226 |     - |     - |    4024 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,182.81 ns | 8.496 ns | 7.948 ns |  1.79 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                   ForLoop |     0 |  1000 | 1,217.30 ns | 5.625 ns | 5.262 ns |  1.00 |    0.00 | 1.9226 |     - |     - |    4024 B |
|                      Linq |     0 |  1000 |   592.39 ns | 3.028 ns | 2.684 ns |  0.49 |    0.00 | 1.9417 |     - |     - |    4064 B |
|                LinqFaster |     0 |  1000 |   582.63 ns | 5.637 ns | 5.273 ns |  0.48 |    0.01 | 1.9226 |     - |     - |    4024 B |
|           LinqFaster_SIMD |     0 |  1000 |   263.26 ns | 0.849 ns | 0.753 ns |  0.22 |    0.00 | 1.9226 |     - |     - |    4024 B |
|                    LinqAF |     0 |  1000 | 2,575.59 ns | 8.877 ns | 7.870 ns |  2.12 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                StructLinq |     0 |  1000 |   959.11 ns | 5.894 ns | 4.921 ns |  0.79 |    0.00 | 1.9226 |     - |     - |    4024 B |
|                 Hyperlinq |     0 |  1000 |   285.91 ns | 4.636 ns | 4.337 ns |  0.23 |    0.00 | 1.9226 |     - |     - |    4024 B |
