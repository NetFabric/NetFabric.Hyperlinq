## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   517.456 μs | 1.6931 μs | 1.3218 μs | 1.000 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   519.676 μs | 2.2140 μs | 1.9627 μs | 1.004 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   551.088 μs | 1.8239 μs | 1.6169 μs | 1.065 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.345 μs | 0.0043 μs | 0.0041 μs | 0.005 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,682.654 μs | 4.7971 μs | 4.2525 μs | 3.251 | 2187.5000 |     - |     - | 4575075 B |
|           StructLinq |          4 |   100 |   577.774 μs | 2.8671 μs | 2.5416 μs | 1.116 | 1086.9141 |     - |     - | 2273665 B |
| StructLinq_IFunction |          4 |   100 |     4.506 μs | 0.0129 μs | 0.0108 μs | 0.009 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   482.036 μs | 4.7111 μs | 4.4068 μs | 0.934 | 1045.8984 |     - |     - | 2187584 B |
