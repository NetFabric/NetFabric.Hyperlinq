## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

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
|          **ForeachLoop** |    **10** |    **61.16 ns** |  **0.196 ns** |  **0.174 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |   178.83 ns |  0.396 ns |  0.351 ns |  2.92 | 0.0763 |     - |     - |     160 B |
|               LinqAF |    10 |   141.33 ns |  0.320 ns |  0.284 ns |  2.31 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   129.59 ns |  0.304 ns |  0.254 ns |  2.12 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    82.38 ns |  0.345 ns |  0.322 ns |  1.35 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |   103.49 ns |  0.213 ns |  0.167 ns |  1.69 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    79.13 ns |  0.275 ns |  0.230 ns |  1.29 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,770.45 ns** | **27.876 ns** | **21.764 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 9,289.17 ns | 18.487 ns | 15.438 ns |  1.95 | 0.0763 |     - |     - |     160 B |
|               LinqAF |  1000 | 8,140.69 ns | 28.900 ns | 25.619 ns |  1.71 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 8,315.59 ns | 23.890 ns | 19.949 ns |  1.74 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 5,511.96 ns | 30.004 ns | 28.066 ns |  1.16 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 7,015.70 ns | 11.953 ns | 10.596 ns |  1.47 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 5,123.09 ns |  8.757 ns |  8.191 ns |  1.07 | 0.0153 |     - |     - |      40 B |
