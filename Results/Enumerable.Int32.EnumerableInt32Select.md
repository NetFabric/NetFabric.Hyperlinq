## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|               Method |      Job |  Runtime | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **56.51 ns** |  **0.393 ns** |  **0.307 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    162.99 ns |  0.412 ns |  0.365 ns |  2.88 |    0.02 | 0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    126.32 ns |  0.397 ns |  0.372 ns |  2.24 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |     95.82 ns |  0.525 ns |  0.491 ns |  1.70 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     66.75 ns |  0.344 ns |  0.305 ns |  1.18 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |     89.14 ns |  0.315 ns |  0.279 ns |  1.58 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     64.92 ns |  1.251 ns |  1.285 ns |  1.14 |    0.02 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |              |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     53.52 ns |  0.243 ns |  0.190 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    153.37 ns |  0.607 ns |  0.538 ns |  2.87 |    0.01 | 0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    126.42 ns |  0.671 ns |  0.595 ns |  2.36 |    0.02 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |     88.38 ns |  0.320 ns |  0.284 ns |  1.65 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     58.48 ns |  0.299 ns |  0.279 ns |  1.09 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |     81.58 ns |  0.826 ns |  0.645 ns |  1.52 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     65.54 ns |  0.350 ns |  0.310 ns |  1.22 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |              |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **4,222.47 ns** | **17.690 ns** | **16.547 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 10,235.25 ns | 31.874 ns | 28.255 ns |  2.42 |    0.01 | 0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 |  7,420.28 ns | 21.237 ns | 18.826 ns |  1.76 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  5,525.06 ns | 20.196 ns | 17.903 ns |  1.31 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  4,481.61 ns | 14.676 ns | 12.255 ns |  1.06 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |  5,850.57 ns | 17.260 ns | 15.301 ns |  1.39 |    0.00 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  4,479.28 ns | 18.442 ns | 16.349 ns |  1.06 |    0.00 | 0.0153 |     - |     - |      40 B |
|                      |          |          |       |              |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |  4,214.36 ns | 20.334 ns | 18.026 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 10,602.85 ns | 38.967 ns | 32.539 ns |  2.52 |    0.01 | 0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 |  7,862.81 ns | 19.656 ns | 18.386 ns |  1.87 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  6,030.26 ns | 16.724 ns | 14.825 ns |  1.43 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  4,216.54 ns | 12.294 ns |  9.598 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |  5,808.50 ns | 33.590 ns | 26.225 ns |  1.38 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  4,760.65 ns | 35.413 ns | 31.392 ns |  1.13 |    0.01 | 0.0153 |     - |     - |      40 B |
