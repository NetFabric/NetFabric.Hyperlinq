## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop |   100 | 133.7 ns | 0.67 ns | 0.63 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 275.8 ns | 1.49 ns | 1.32 ns |  2.06 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 743.6 ns | 4.03 ns | 3.57 ns |  5.56 |    0.02 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 487.4 ns | 3.16 ns | 2.80 ns |  3.64 |    0.03 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 800.7 ns | 2.84 ns | 2.37 ns |  5.99 |    0.04 |      - |     - |     - |         - |
|           StructLinq |   100 | 313.2 ns | 1.50 ns | 1.33 ns |  2.34 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 187.4 ns | 0.72 ns | 0.64 ns |  1.40 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 283.0 ns | 1.71 ns | 1.51 ns |  2.12 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 201.5 ns | 0.94 ns | 0.83 ns |  1.51 |    0.01 |      - |     - |     - |         - |
