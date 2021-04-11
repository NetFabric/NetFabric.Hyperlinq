## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                 **Linq** | **.NET 5.0** | **.NET 5.0** |    **10** |   **149.10 ns** |  **0.615 ns** |  **0.513 ns** |  **1.00** |    **0.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |   129.10 ns |  2.379 ns |  2.109 ns |  0.86 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |   102.37 ns |  1.896 ns |  2.329 ns |  0.69 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    77.49 ns |  1.561 ns |  1.917 ns |  0.51 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    93.87 ns |  0.484 ns |  0.378 ns |  0.63 |    0.00 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    77.39 ns |  0.247 ns |  0.231 ns |  0.52 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |       |         |        |       |       |           |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |   148.57 ns |  0.797 ns |  0.706 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |   117.64 ns |  0.403 ns |  0.377 ns |  0.79 |    0.00 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    96.21 ns |  0.794 ns |  0.704 ns |  0.65 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    69.93 ns |  0.479 ns |  0.400 ns |  0.47 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    98.36 ns |  1.823 ns |  1.706 ns |  0.66 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    71.75 ns |  1.419 ns |  1.743 ns |  0.49 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |       |         |        |       |       |           |
|                 **Linq** | **.NET 5.0** | **.NET 5.0** |  **1000** | **8,262.11 ns** | **20.730 ns** | **17.310 ns** |  **1.00** |    **0.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 7,824.11 ns | 33.391 ns | 29.600 ns |  0.95 |    0.00 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 6,930.16 ns | 33.210 ns | 29.440 ns |  0.84 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,914.86 ns | 24.775 ns | 20.689 ns |  0.59 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 6,574.26 ns | 29.075 ns | 25.774 ns |  0.80 |    0.00 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 5,578.57 ns | 43.251 ns | 38.341 ns |  0.68 |    0.00 | 0.0153 |     - |     - |      40 B |
|                      |          |          |       |             |           |           |       |         |        |       |       |           |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 8,824.54 ns | 28.457 ns | 23.763 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 7,394.38 ns | 40.459 ns | 33.785 ns |  0.84 |    0.00 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 6,583.38 ns | 30.538 ns | 27.072 ns |  0.75 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 5,432.49 ns | 29.708 ns | 26.335 ns |  0.62 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 7,182.87 ns | 23.538 ns | 20.866 ns |  0.81 |    0.00 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 5,432.73 ns | 38.736 ns | 32.346 ns |  0.62 |    0.00 | 0.0153 |     - |     - |      40 B |
