## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  64.30 ns |  0.213 ns |  0.189 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  94.82 ns |  0.312 ns |  0.261 ns |  1.47 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 609.87 ns |  2.450 ns |  2.171 ns |  9.49 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 264.75 ns |  0.817 ns |  0.724 ns |  4.12 |    0.02 |      - |     - |     - |         - |
|               LinqAF |   100 | 567.10 ns | 11.080 ns | 14.407 ns |  8.90 |    0.21 |      - |     - |     - |         - |
|           StructLinq |   100 | 231.48 ns |  1.041 ns |  0.869 ns |  3.60 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  76.24 ns |  0.209 ns |  0.174 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 200.44 ns |  0.690 ns |  0.646 ns |  3.12 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  69.66 ns |  0.208 ns |  0.195 ns |  1.08 |    0.00 |      - |     - |     - |         - |
