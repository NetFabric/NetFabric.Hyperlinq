## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              ForLoop |   100 | 121.8 ns | 0.29 ns | 0.28 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 208.8 ns | 0.28 ns | 0.22 ns |  1.72 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 755.9 ns | 1.68 ns | 1.40 ns |  6.21 |    0.02 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 509.2 ns | 2.67 ns | 2.36 ns |  4.18 |    0.02 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 795.8 ns | 2.40 ns | 2.13 ns |  6.54 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 385.6 ns | 0.81 ns | 0.76 ns |  3.17 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 185.9 ns | 0.41 ns | 0.35 ns |  1.53 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 349.1 ns | 0.91 ns | 0.80 ns |  2.87 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 191.3 ns | 0.27 ns | 0.23 ns |  1.57 |    0.00 |      - |     - |     - |         - |
