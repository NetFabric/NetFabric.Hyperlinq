## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|              ForLoop |   100 | 194.71 ns |  1.737 ns |  1.451 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 385.30 ns |  1.354 ns |  1.266 ns |  1.98 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 978.45 ns |  4.542 ns |  4.249 ns |  5.03 |    0.04 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 293.82 ns |  0.462 ns |  0.385 ns |  1.51 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 891.25 ns | 17.770 ns | 23.106 ns |  4.61 |    0.15 |      - |     - |     - |         - |
|           StructLinq |   100 | 237.01 ns |  1.423 ns |  1.261 ns |  1.22 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |  85.03 ns |  0.311 ns |  0.291 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 200.79 ns |  0.857 ns |  0.759 ns |  1.03 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  70.50 ns |  0.189 ns |  0.176 ns |  0.36 |    0.00 |      - |     - |     - |         - |
