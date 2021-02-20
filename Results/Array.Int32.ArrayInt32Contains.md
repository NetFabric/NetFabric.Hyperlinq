## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **3.178 ns** | **0.0191 ns** | **0.0169 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.123 ns | 0.0274 ns | 0.0229 ns |  1.61 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    15.128 ns | 0.0352 ns | 0.0312 ns |  4.76 |    0.03 |      - |     - |     - |         - |
|           LinqFaster |    10 |     9.192 ns | 0.0260 ns | 0.0244 ns |  2.89 |    0.02 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     3.467 ns | 0.0137 ns | 0.0128 ns |  1.09 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    10.529 ns | 0.0571 ns | 0.0446 ns |  3.31 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |    14.993 ns | 0.0649 ns | 0.0607 ns |  4.72 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    11.765 ns | 0.0273 ns | 0.0228 ns |  3.70 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     9.564 ns | 0.0405 ns | 0.0338 ns |  3.01 |    0.02 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |     7.228 ns | 0.0311 ns | 0.0276 ns |  2.27 |    0.01 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **346.178 ns** | **0.8430 ns** | **0.7885 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   346.232 ns | 0.6514 ns | 0.6094 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 |   233.871 ns | 0.6181 ns | 0.4826 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   234.780 ns | 0.6273 ns | 0.4897 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    79.901 ns | 0.1632 ns | 0.1447 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 |   237.289 ns | 0.6544 ns | 0.6121 ns |  0.69 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 |   536.793 ns | 1.1515 ns | 1.0771 ns |  1.55 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,025.233 ns | 1.8505 ns | 1.7310 ns |  2.96 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   235.190 ns | 0.6432 ns | 0.6016 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   105.131 ns | 0.4501 ns | 0.4210 ns |  0.30 |    0.00 |      - |     - |     - |         - |
