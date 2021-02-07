## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   517.713 μs | 1.8564 μs | 1.6457 μs | 1.000 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   530.518 μs | 1.6264 μs | 1.3582 μs | 1.024 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   524.852 μs | 2.0532 μs | 1.7145 μs | 1.013 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.915 μs | 0.0065 μs | 0.0058 μs | 0.006 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,694.543 μs | 6.9414 μs | 5.7964 μs | 3.272 | 2187.5000 |     - |     - | 4575072 B |
|           StructLinq |          4 |   100 |   576.348 μs | 2.7916 μs | 2.3311 μs | 1.113 | 1086.9141 |     - |     - | 2273665 B |
| StructLinq_IFunction |          4 |   100 |     4.721 μs | 0.0136 μs | 0.0121 μs | 0.009 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   477.337 μs | 2.9721 μs | 2.6347 μs | 0.922 | 1045.8984 |     - |     - | 2187584 B |
