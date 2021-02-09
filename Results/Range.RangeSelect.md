## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |        Mean |     Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |------------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |    39.63 ns |  0.108 ns |   0.096 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 |   761.48 ns | 14.622 ns |  35.033 ns | 19.15 |    0.84 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 1,275.62 ns | 29.853 ns |  87.553 ns | 32.68 |    2.32 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 |   411.52 ns |  2.693 ns |   2.103 ns | 10.38 |    0.06 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD |     0 |   100 |   153.05 ns |  1.780 ns |   1.665 ns |  3.87 |    0.04 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 1,505.56 ns | 34.347 ns | 101.273 ns | 38.96 |    2.03 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 |   414.50 ns |  8.314 ns |  22.047 ns | 10.59 |    0.73 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 |   162.75 ns |  0.313 ns |   0.292 ns |  4.11 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 |   539.84 ns | 14.551 ns |  42.447 ns | 13.60 |    1.21 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 |   171.70 ns |  0.384 ns |   0.359 ns |  4.33 |    0.01 |      - |     - |     - |         - |
