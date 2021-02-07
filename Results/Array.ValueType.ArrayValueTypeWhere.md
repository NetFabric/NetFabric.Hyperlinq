## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   396.3 ns |  0.79 ns |  0.74 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   448.6 ns |  1.14 ns |  1.07 ns |  1.13 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 |   856.1 ns |  2.89 ns |  2.56 ns |  2.16 |    0.01 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 |   926.2 ns |  1.90 ns |  1.59 ns |  2.34 |    0.01 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,027.9 ns | 19.82 ns | 18.54 ns |  2.59 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 |   575.0 ns |  0.95 ns |  0.89 ns |  1.45 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   487.9 ns |  1.44 ns |  1.35 ns |  1.23 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   511.6 ns |  1.02 ns |  0.95 ns |  1.29 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   466.7 ns |  0.53 ns |  0.50 ns |  1.18 |    0.00 |      - |     - |     - |         - |
