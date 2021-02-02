## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   518.889 μs |  2.6115 μs |  2.4428 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   519.857 μs |  2.3106 μs |  2.1613 μs | 1.002 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   537.335 μs |  2.3770 μs |  2.2235 μs | 1.036 |    0.01 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.407 μs |  0.0070 μs |  0.0066 μs | 0.005 |    0.00 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,714.285 μs | 14.9487 μs | 13.9830 μs | 3.304 |    0.03 | 2187.5000 |     - |     - | 4575072 B |
|           StructLinq |          4 |   100 |   593.693 μs |  1.5010 μs |  1.3306 μs | 1.144 |    0.01 | 1086.9141 |     - |     - | 2273665 B |
| StructLinq_IFunction |          4 |   100 |     4.685 μs |  0.0085 μs |  0.0075 μs | 0.009 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   482.800 μs |  2.8974 μs |  2.5685 μs | 0.931 |    0.01 | 1045.8984 |     - |     - | 2187584 B |
