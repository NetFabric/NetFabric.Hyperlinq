## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |      Error |    StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   536.773 μs |  3.1065 μs | 2.7538 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   555.185 μs |  3.7449 μs | 3.5030 μs | 1.035 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   558.885 μs |  6.9142 μs | 6.4676 μs | 1.041 |    0.01 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.372 μs |  0.0078 μs | 0.0069 μs | 0.004 |    0.00 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,926.123 μs | 10.5802 μs | 9.8967 μs | 3.588 |    0.02 | 2187.5000 |     - |     - | 4575073 B |
|           StructLinq |          4 |   100 |   595.447 μs |  5.9458 μs | 5.5617 μs | 1.109 |    0.01 | 1086.9141 |     - |     - | 2273633 B |
| StructLinq_IFunction |          4 |   100 |     4.734 μs |  0.0390 μs | 0.0365 μs | 0.009 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   508.453 μs |  4.4865 μs | 3.9772 μs | 0.947 |    0.01 | 1045.8984 |     - |     - | 2187585 B |
