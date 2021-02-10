## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   514.406 μs | 3.5080 μs | 2.9293 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   523.295 μs | 1.8450 μs | 1.7258 μs | 1.018 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   545.174 μs | 3.1539 μs | 2.7959 μs | 1.059 |    0.01 | 1092.7734 |     - |     - | 2286672 B |
|               LinqAF |          4 |   100 | 1,690.737 μs | 7.5863 μs | 6.7250 μs | 3.287 |    0.02 | 2187.5000 |     - |     - | 4575073 B |
|           StructLinq |          4 |   100 |   585.079 μs | 2.5750 μs | 2.1503 μs | 1.137 |    0.01 | 1086.9141 |     - |     - | 2273657 B |
| StructLinq_IFunction |          4 |   100 |     4.448 μs | 0.0068 μs | 0.0053 μs | 0.009 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   485.408 μs | 4.1866 μs | 3.7113 μs | 0.943 |    0.01 | 1045.8984 |     - |     - | 2187585 B |
