## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 148.6 ns | 0.27 ns | 0.24 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 208.5 ns | 0.35 ns | 0.31 ns |  1.40 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 652.3 ns | 5.06 ns | 3.95 ns |  4.39 |    0.03 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 428.3 ns | 1.13 ns | 1.06 ns |  2.88 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 735.0 ns | 1.37 ns | 1.28 ns |  4.95 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 291.7 ns | 1.04 ns | 0.86 ns |  1.96 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 169.0 ns | 0.57 ns | 0.54 ns |  1.14 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 266.1 ns | 1.31 ns | 1.22 ns |  1.79 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 183.9 ns | 0.34 ns | 0.30 ns |  1.24 |    0.00 |      - |     - |     - |         - |
