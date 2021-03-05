## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **34.22 ns** |   **0.088 ns** |   **0.083 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     66.82 ns |   0.287 ns |   0.254 ns |  1.95 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    134.16 ns |   1.085 ns |   0.962 ns |  3.92 |    0.03 |  0.0880 |     - |     - |     184 B |
|           LinqFaster |    10 |     76.02 ns |   0.282 ns |   0.264 ns |  2.22 |    0.01 |  0.1491 |     - |     - |     312 B |
|               LinqAF |    10 |    220.42 ns |   3.553 ns |   3.324 ns |  6.44 |    0.10 |       - |     - |     - |         - |
|           StructLinq |    10 |     59.41 ns |   0.193 ns |   0.171 ns |  1.74 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     58.21 ns |   0.152 ns |   0.135 ns |  1.70 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    103.50 ns |   0.343 ns |   0.304 ns |  3.02 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     79.18 ns |   0.196 ns |   0.174 ns |  2.31 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **5,857.78 ns** |  **13.197 ns** |  **11.020 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  8,611.00 ns |  46.049 ns |  40.821 ns |  1.47 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 15,960.65 ns |  61.875 ns |  51.669 ns |  2.72 |    0.01 |  0.0610 |     - |     - |     184 B |
|           LinqFaster |  1000 | 14,005.06 ns |  51.592 ns |  45.735 ns |  2.39 |    0.01 | 31.2347 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 20,096.44 ns | 185.315 ns | 164.277 ns |  3.43 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 |  7,581.60 ns |  17.114 ns |  14.291 ns |  1.29 |    0.00 |  0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |  5,841.50 ns |  19.142 ns |  14.944 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 13,246.53 ns |  34.544 ns |  30.622 ns |  2.26 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  8,490.92 ns |  21.096 ns |  18.701 ns |  1.45 |    0.00 |       - |     - |     - |         - |
