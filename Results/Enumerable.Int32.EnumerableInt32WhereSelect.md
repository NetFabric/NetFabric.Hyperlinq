## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|          **ForeachLoop** |    **10** |     **62.06 ns** |  **0.198 ns** |  **0.175 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    215.96 ns |  1.128 ns |  1.055 ns |  3.48 |    0.02 | 0.0763 |     - |     - |     160 B |
|               LinqAF |    10 |    180.35 ns |  1.588 ns |  1.485 ns |  2.91 |    0.03 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    135.14 ns |  0.577 ns |  0.511 ns |  2.18 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |     83.30 ns |  0.263 ns |  0.233 ns |  1.34 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    122.24 ns |  0.583 ns |  0.487 ns |  1.97 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |     81.30 ns |  0.336 ns |  0.298 ns |  1.31 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |              |           |           |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** |  **4,568.06 ns** | **15.735 ns** | **13.949 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 10,291.11 ns | 20.496 ns | 18.170 ns |  2.25 |    0.01 | 0.0763 |     - |     - |     160 B |
|               LinqAF |  1000 |  8,854.59 ns | 29.596 ns | 26.236 ns |  1.94 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 |  8,688.32 ns | 24.668 ns | 20.599 ns |  1.90 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 |  5,367.45 ns | 19.007 ns | 16.849 ns |  1.18 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 |  8,453.26 ns | 15.295 ns | 12.772 ns |  1.85 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 |  5,501.88 ns | 28.029 ns | 24.847 ns |  1.20 |    0.01 | 0.0153 |     - |     - |      40 B |
