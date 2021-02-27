## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **63.74 ns** |  **0.254 ns** |  **0.225 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    90.12 ns |  0.693 ns |  0.579 ns |  1.41 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |   104.36 ns |  0.523 ns |  0.463 ns |  1.64 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   122.91 ns |  0.627 ns |  0.556 ns |  1.93 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    73.64 ns |  0.432 ns |  0.383 ns |  1.16 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    90.51 ns |  0.622 ns |  0.551 ns |  1.42 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    60.46 ns |  0.390 ns |  0.326 ns |  0.95 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,917.98 ns** | **19.313 ns** | **17.121 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 5,999.13 ns | 47.498 ns | 42.105 ns |  1.22 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 6,783.70 ns | 43.517 ns | 38.577 ns |  1.38 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 6,381.43 ns | 22.183 ns | 18.524 ns |  1.30 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 4,793.19 ns | 23.477 ns | 18.330 ns |  0.97 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 6,432.00 ns | 21.049 ns | 16.434 ns |  1.31 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 4,597.13 ns | 12.563 ns | 11.137 ns |  0.93 | 0.0153 |     - |     - |      40 B |
