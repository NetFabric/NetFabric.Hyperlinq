## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  68.77 ns | 0.304 ns | 0.269 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  93.46 ns | 0.518 ns | 0.459 ns |  1.36 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 746.68 ns | 2.742 ns | 2.431 ns | 10.86 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 233.71 ns | 1.425 ns | 1.263 ns |  3.40 |    0.03 |      - |     - |     - |         - |
|               LinqAF |   100 | 964.58 ns | 8.943 ns | 8.366 ns | 14.04 |    0.14 |      - |     - |     - |         - |
|           StructLinq |   100 | 292.18 ns | 1.401 ns | 1.242 ns |  4.25 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 172.41 ns | 0.530 ns | 0.470 ns |  2.51 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 192.38 ns | 1.022 ns | 0.906 ns |  2.80 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 138.28 ns | 0.722 ns | 0.640 ns |  2.01 |    0.01 |      - |     - |     - |         - |
