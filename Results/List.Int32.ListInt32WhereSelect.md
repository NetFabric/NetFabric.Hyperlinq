## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              **ForLoop** |    **10** |     **10.41 ns** |  **0.010 ns** |  **0.009 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     27.05 ns |  0.098 ns |  0.087 ns |  2.60 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    116.35 ns |  0.295 ns |  0.261 ns | 11.18 |    0.03 | 0.0726 |     - |     - |     152 B |
|           LinqFaster |    10 |     50.80 ns |  0.268 ns |  0.237 ns |  4.88 |    0.02 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |    111.09 ns |  0.231 ns |  0.193 ns | 10.67 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |     57.34 ns |  0.513 ns |  0.429 ns |  5.51 |    0.04 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     51.37 ns |  0.128 ns |  0.107 ns |  4.93 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     45.99 ns |  0.151 ns |  0.134 ns |  4.42 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     40.81 ns |  0.076 ns |  0.071 ns |  3.92 |    0.01 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,338.27 ns** |  **6.417 ns** |  **5.688 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,684.10 ns | 14.035 ns | 12.441 ns |  2.75 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,543.36 ns | 23.721 ns | 21.028 ns |  8.63 |    0.04 | 0.0610 |     - |     - |     152 B |
|           LinqFaster |  1000 |  6,011.59 ns | 21.939 ns | 20.522 ns |  4.49 |    0.03 | 2.0523 |     - |     - |    4304 B |
|               LinqAF |  1000 | 11,992.55 ns | 34.541 ns | 30.619 ns |  8.96 |    0.05 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,115.20 ns | 34.393 ns | 30.488 ns |  3.82 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,473.90 ns |  4.701 ns |  4.168 ns |  1.10 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,414.32 ns | 18.262 ns | 15.250 ns |  4.05 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  1,904.28 ns |  6.947 ns |  6.159 ns |  1.42 |    0.01 |      - |     - |     - |         - |
