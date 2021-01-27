## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    74.30 ns | 0.196 ns | 0.164 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   119.24 ns | 0.470 ns | 0.440 ns |  1.61 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 |   643.55 ns | 0.998 ns | 0.833 ns |  8.66 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   281.83 ns | 0.697 ns | 0.618 ns |  3.79 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,110.34 ns | 9.709 ns | 9.081 ns | 14.93 |    0.14 |      - |     - |     - |         - |
|           StructLinq |   100 |   325.66 ns | 0.872 ns | 0.773 ns |  4.38 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   181.32 ns | 0.603 ns | 0.534 ns |  2.44 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   363.30 ns | 1.240 ns | 1.035 ns |  4.89 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   206.10 ns | 0.336 ns | 0.262 ns |  2.77 |    0.01 |      - |     - |     - |         - |
