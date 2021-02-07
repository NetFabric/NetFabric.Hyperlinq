## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|              ForLoop |   100 | 188.84 ns |  0.628 ns |  0.525 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 375.86 ns |  0.969 ns |  0.859 ns |  1.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 878.37 ns |  1.399 ns |  1.241 ns |  4.65 |    0.01 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 286.38 ns |  0.846 ns |  0.660 ns |  1.52 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 894.00 ns | 16.830 ns | 15.743 ns |  4.72 |    0.07 |      - |     - |     - |         - |
|           StructLinq |   100 | 229.16 ns |  0.714 ns |  0.596 ns |  1.21 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |  82.92 ns |  0.177 ns |  0.157 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 220.42 ns |  0.496 ns |  0.440 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  76.34 ns |  0.122 ns |  0.114 ns |  0.40 |    0.00 |      - |     - |     - |         - |
