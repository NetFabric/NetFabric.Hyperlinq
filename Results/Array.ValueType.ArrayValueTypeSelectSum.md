## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  62.73 ns |  0.112 ns |  0.094 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  92.75 ns |  0.222 ns |  0.208 ns |  1.48 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 643.66 ns |  1.297 ns |  1.083 ns | 10.26 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 241.18 ns |  0.565 ns |  0.472 ns |  3.84 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 587.28 ns | 11.560 ns | 17.654 ns |  9.25 |    0.34 |      - |     - |     - |         - |
|           StructLinq |   100 | 202.22 ns |  0.459 ns |  0.407 ns |  3.22 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  74.37 ns |  0.189 ns |  0.167 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 195.67 ns |  0.621 ns |  0.550 ns |  3.12 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  68.08 ns |  0.100 ns |  0.078 ns |  1.09 |    0.00 |      - |     - |     - |         - |
