## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |      Error |    StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   701.572 μs |  1.1407 μs | 0.9526 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   709.618 μs |  1.4688 μs | 1.3020 μs | 1.012 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   771.935 μs |  2.7825 μs | 2.6028 μs | 1.100 |    0.00 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.543 μs |  0.0015 μs | 0.0012 μs | 0.004 |    0.00 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 3,028.072 μs | 11.1680 μs | 9.3258 μs | 4.316 |    0.02 | 2187.5000 |     - |     - | 4575074 B |
|           StructLinq |          4 |   100 |   820.698 μs |  2.6957 μs | 2.5215 μs | 1.170 |    0.00 | 1086.9141 |     - |     - | 2273600 B |
| StructLinq_IFunction |          4 |   100 |    24.655 μs |  0.0170 μs | 0.0142 μs | 0.035 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   668.187 μs |  2.5318 μs | 2.3683 μs | 0.953 |    0.00 | 1045.8984 |     - |     - | 2187584 B |
