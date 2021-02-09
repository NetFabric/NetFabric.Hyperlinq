## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  62.79 ns |  0.204 ns |  0.191 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  91.31 ns |  0.187 ns |  0.175 ns |  1.45 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 644.25 ns |  1.256 ns |  1.175 ns | 10.26 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 280.33 ns |  0.739 ns |  0.655 ns |  4.47 |    0.02 |      - |     - |     - |         - |
|               LinqAF |   100 | 567.28 ns | 11.236 ns | 15.380 ns |  9.01 |    0.23 |      - |     - |     - |         - |
|           StructLinq |   100 | 224.89 ns |  0.697 ns |  0.618 ns |  3.58 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  73.94 ns |  0.203 ns |  0.190 ns |  1.18 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 196.05 ns |  0.417 ns |  0.348 ns |  3.12 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  76.74 ns |  0.220 ns |  0.195 ns |  1.22 |    0.00 |      - |     - |     - |         - |
