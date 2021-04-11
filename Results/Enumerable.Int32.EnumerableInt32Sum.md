## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **56.55 ns** |  **0.165 ns** |  **0.138 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    58.94 ns |  0.692 ns |  0.540 ns |  1.04 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    81.46 ns |  0.406 ns |  0.380 ns |  1.44 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    74.38 ns |  0.249 ns |  0.208 ns |  1.32 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    59.46 ns |  0.320 ns |  0.284 ns |  1.05 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    59.51 ns |  0.348 ns |  0.308 ns |  1.05 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    57.07 ns |  0.536 ns |  0.447 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    54.84 ns |  0.223 ns |  0.198 ns |  0.96 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    74.01 ns |  0.508 ns |  0.475 ns |  1.30 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    69.05 ns |  0.270 ns |  0.226 ns |  1.21 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    56.14 ns |  0.178 ns |  0.158 ns |  0.98 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    57.12 ns |  1.107 ns |  0.981 ns |  1.00 |    0.02 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **4,224.50 ns** | **24.625 ns** | **19.226 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 4,223.50 ns | 21.078 ns | 19.716 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 4,777.95 ns | 19.450 ns | 18.194 ns |  1.13 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 4,745.64 ns | 17.505 ns | 14.618 ns |  1.12 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,761.39 ns | 24.985 ns | 22.149 ns |  1.13 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 4,492.30 ns | 18.825 ns | 17.609 ns |  1.06 |    0.01 | 0.0153 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 4,218.53 ns | 13.660 ns | 12.778 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 4,214.03 ns | 19.112 ns | 17.878 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 4,369.42 ns | 28.930 ns | 25.645 ns |  1.04 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 4,267.58 ns | 40.754 ns | 34.032 ns |  1.01 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 4,234.20 ns | 27.904 ns | 24.736 ns |  1.00 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 4,208.39 ns | 20.359 ns | 17.001 ns |  1.00 |    0.01 | 0.0153 |     - |     - |      40 B |
