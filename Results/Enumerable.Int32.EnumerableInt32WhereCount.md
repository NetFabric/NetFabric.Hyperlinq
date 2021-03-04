## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **60.09 ns** |  **0.112 ns** |  **0.087 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    89.54 ns |  0.741 ns |  0.619 ns |  1.49 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |   102.80 ns |  0.758 ns |  0.633 ns |  1.71 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   117.80 ns |  0.512 ns |  0.454 ns |  1.96 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    71.50 ns |  0.364 ns |  0.340 ns |  1.19 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    91.92 ns |  0.256 ns |  0.239 ns |  1.53 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    63.47 ns |  0.384 ns |  0.321 ns |  1.06 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,597.91 ns** | **12.415 ns** | **11.005 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 5,974.08 ns | 38.646 ns | 34.259 ns |  1.30 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 6,718.74 ns | 20.866 ns | 17.424 ns |  1.46 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 6,322.37 ns | 19.931 ns | 18.643 ns |  1.38 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 4,735.79 ns | 13.258 ns | 11.753 ns |  1.03 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 6,144.77 ns | 40.602 ns | 35.993 ns |  1.34 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 4,057.15 ns | 14.346 ns | 11.979 ns |  0.88 | 0.0153 |     - |     - |      40 B |
