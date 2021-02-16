## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   534.874 μs | 1.8651 μs | 1.5575 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   529.017 μs | 2.9576 μs | 2.7665 μs | 0.989 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   536.438 μs | 1.5857 μs | 1.3241 μs | 1.003 |    0.00 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.501 μs | 0.0041 μs | 0.0034 μs | 0.005 |    0.00 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,748.076 μs | 8.4523 μs | 7.0581 μs | 3.268 |    0.02 | 2187.5000 |     - |     - | 4575072 B |
|           StructLinq |          4 |   100 |   593.342 μs | 3.7442 μs | 3.3191 μs | 1.110 |    0.01 | 1086.9141 |     - |     - | 2273665 B |
| StructLinq_IFunction |          4 |   100 |     4.456 μs | 0.0112 μs | 0.0094 μs | 0.008 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   488.075 μs | 2.7476 μs | 2.5701 μs | 0.912 |    0.01 | 1045.8984 |     - |     - | 2187584 B |
