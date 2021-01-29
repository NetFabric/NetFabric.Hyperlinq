## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              ForLoop |   100 | 133.3 ns | 0.43 ns | 0.40 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 231.1 ns | 0.82 ns | 0.72 ns |  1.73 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 883.8 ns | 2.82 ns | 2.50 ns |  6.63 |    0.03 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 558.0 ns | 2.72 ns | 2.41 ns |  4.19 |    0.02 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 852.8 ns | 3.04 ns | 2.54 ns |  6.40 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 410.2 ns | 1.60 ns | 1.34 ns |  3.08 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 203.3 ns | 1.08 ns | 0.96 ns |  1.52 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 403.5 ns | 1.63 ns | 1.52 ns |  3.03 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 210.1 ns | 0.45 ns | 0.43 ns |  1.58 |    0.01 |      - |     - |     - |         - |
