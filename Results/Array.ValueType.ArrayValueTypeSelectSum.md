## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
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
|              ForLoop |   100 |    61.65 ns |  0.098 ns |  0.087 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    91.72 ns |  0.273 ns |  0.256 ns |  1.49 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,237.72 ns | 33.832 ns | 99.225 ns | 19.11 |    1.33 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   442.06 ns | 11.723 ns | 34.196 ns |  7.05 |    0.44 |      - |     - |     - |         - |
|               LinqAF |   100 |   944.46 ns | 18.887 ns | 52.021 ns | 15.71 |    0.70 |      - |     - |     - |         - |
|           StructLinq |   100 |   380.95 ns |  7.627 ns | 20.750 ns |  6.09 |    0.33 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |    77.35 ns |  0.399 ns |  0.373 ns |  1.25 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   353.96 ns |  8.711 ns | 24.853 ns |  5.67 |    0.39 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |    78.16 ns |  0.345 ns |  0.323 ns |  1.27 |    0.01 |      - |     - |     - |         - |
