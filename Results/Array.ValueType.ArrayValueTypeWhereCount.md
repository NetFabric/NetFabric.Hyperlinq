## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    74.20 ns |  0.124 ns |  0.110 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   119.51 ns |  0.358 ns |  0.279 ns |  1.61 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,361.08 ns | 33.405 ns | 97.443 ns | 18.44 |    1.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   496.24 ns | 10.238 ns | 29.864 ns |  6.74 |    0.43 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,705.88 ns | 33.320 ns | 38.371 ns | 22.90 |    0.57 |      - |     - |     - |         - |
|           StructLinq |   100 |   525.02 ns | 11.352 ns | 33.293 ns |  7.07 |    0.59 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   179.53 ns |  0.400 ns |  0.374 ns |  2.42 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   470.37 ns |  9.383 ns | 25.207 ns |  6.34 |    0.30 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   121.10 ns |  0.354 ns |  0.331 ns |  1.63 |    0.01 |      - |     - |     - |         - |
