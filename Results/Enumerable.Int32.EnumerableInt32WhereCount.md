## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|          **ForeachLoop** |    **10** |     **66.48 ns** |  **0.317 ns** |  **0.281 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    100.95 ns |  0.517 ns |  0.483 ns |  1.52 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    117.56 ns |  0.564 ns |  0.500 ns |  1.77 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    130.18 ns |  0.882 ns |  0.825 ns |  1.96 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |     80.24 ns |  0.423 ns |  0.375 ns |  1.21 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    106.17 ns |  0.614 ns |  0.545 ns |  1.60 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |     66.50 ns |  0.504 ns |  0.447 ns |  1.00 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |              |           |           |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** |  **4,816.84 ns** | **12.093 ns** | **10.721 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 10,451.91 ns | 44.450 ns | 39.404 ns |  2.17 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 |  7,073.17 ns | 20.573 ns | 18.237 ns |  1.47 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 |  6,699.75 ns | 23.875 ns | 19.937 ns |  1.39 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 |  4,851.30 ns | 17.507 ns | 16.376 ns |  1.01 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 |  7,014.99 ns | 19.062 ns | 15.918 ns |  1.46 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 |  4,454.23 ns | 10.224 ns |  9.063 ns |  0.92 |    0.00 | 0.0153 |     - |     - |      40 B |
