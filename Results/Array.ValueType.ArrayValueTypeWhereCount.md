## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|              ForLoop |   100 |    75.00 ns |  0.327 ns |  0.306 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   119.21 ns |  0.144 ns |  0.113 ns |  1.59 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,443.42 ns | 32.765 ns | 96.609 ns | 19.43 |    1.17 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   584.85 ns | 12.094 ns | 35.658 ns |  7.71 |    0.40 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,712.26 ns | 31.917 ns | 43.689 ns | 22.72 |    0.61 |      - |     - |     - |         - |
|           StructLinq |   100 |   557.33 ns | 11.147 ns | 31.257 ns |  7.38 |    0.52 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   179.44 ns |  0.574 ns |  0.479 ns |  2.39 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   448.77 ns | 11.671 ns | 34.228 ns |  6.08 |    0.47 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   116.00 ns |  0.410 ns |  0.363 ns |  1.55 |    0.01 |      - |     - |     - |         - |
