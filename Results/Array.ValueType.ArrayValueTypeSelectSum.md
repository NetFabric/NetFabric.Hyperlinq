## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  62.28 ns |  0.165 ns |  0.154 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  91.64 ns |  0.152 ns |  0.127 ns |  1.47 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 594.83 ns |  1.577 ns |  1.398 ns |  9.55 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 240.21 ns |  0.483 ns |  0.377 ns |  3.86 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 566.36 ns | 11.219 ns | 25.324 ns |  9.52 |    0.29 |      - |     - |     - |         - |
|           StructLinq |   100 | 222.85 ns |  0.353 ns |  0.313 ns |  3.58 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  73.66 ns |  0.132 ns |  0.110 ns |  1.18 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 195.56 ns |  0.799 ns |  0.624 ns |  3.14 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  76.26 ns |  0.288 ns |  0.240 ns |  1.22 |    0.01 |      - |     - |     - |         - |
