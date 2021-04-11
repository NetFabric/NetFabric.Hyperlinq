## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **57.73 ns** |  **0.568 ns** |  **0.504 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    66.56 ns |  0.256 ns |  0.239 ns |  1.15 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    98.44 ns |  0.343 ns |  0.304 ns |  1.71 |    0.02 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    71.19 ns |  0.395 ns |  0.308 ns |  1.23 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    63.56 ns |  0.424 ns |  0.376 ns |  1.10 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    86.06 ns |  0.193 ns |  0.181 ns |  1.49 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    54.45 ns |  0.271 ns |  0.227 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    65.26 ns |  1.108 ns |  2.477 ns |  1.22 |    0.08 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    79.30 ns |  0.357 ns |  0.334 ns |  1.46 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    71.47 ns |  0.379 ns |  0.336 ns |  1.31 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    58.21 ns |  0.348 ns |  0.325 ns |  1.07 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    71.70 ns |  0.439 ns |  0.410 ns |  1.32 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **4,481.82 ns** | **29.073 ns** | **28.554 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 4,233.29 ns | 17.679 ns | 15.672 ns |  0.95 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 5,550.69 ns | 15.801 ns | 13.195 ns |  1.24 |    0.00 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 4,233.66 ns | 35.492 ns | 27.710 ns |  0.95 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,257.58 ns | 22.975 ns | 21.491 ns |  0.95 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 5,768.32 ns | 19.954 ns | 17.688 ns |  1.29 |    0.01 | 0.0153 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 4,223.02 ns | 25.138 ns | 22.284 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 4,521.35 ns | 25.761 ns | 22.837 ns |  1.07 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 4,900.32 ns | 21.916 ns | 20.500 ns |  1.16 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 4,495.21 ns | 15.849 ns | 14.826 ns |  1.06 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 4,475.29 ns | 17.642 ns | 16.502 ns |  1.06 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 5,264.90 ns | 31.382 ns | 29.355 ns |  1.25 |    0.01 | 0.0153 |     - |     - |      40 B |
