## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   691.501 μs | 0.8569 μs | 0.6690 μs | 1.000 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   696.857 μs | 1.2291 μs | 1.0264 μs | 1.008 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   765.611 μs | 0.5019 μs | 0.3918 μs | 1.107 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.560 μs | 0.0040 μs | 0.0033 μs | 0.004 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 3,085.903 μs | 7.1299 μs | 6.3205 μs | 4.463 | 2187.5000 |     - |     - | 4575109 B |
|           StructLinq |          4 |   100 |   794.114 μs | 1.4812 μs | 1.3131 μs | 1.149 | 1086.9141 |     - |     - | 2273600 B |
| StructLinq_IFunction |          4 |   100 |    24.295 μs | 0.0224 μs | 0.0199 μs | 0.035 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   662.358 μs | 1.3561 μs | 1.2021 μs | 0.958 | 1045.8984 |     - |     - | 2187584 B |
