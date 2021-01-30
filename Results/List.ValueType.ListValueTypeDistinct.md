## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   532.281 μs | 2.5676 μs | 2.2761 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   523.720 μs | 1.4657 μs | 1.2239 μs | 0.984 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   539.408 μs | 2.6471 μs | 2.3466 μs | 1.013 |    0.01 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.318 μs | 0.0063 μs | 0.0059 μs | 0.004 |    0.00 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,724.418 μs | 5.4804 μs | 4.8582 μs | 3.240 |    0.02 | 2187.5000 |     - |     - | 4575099 B |
|           StructLinq |          4 |   100 |   579.486 μs | 1.7675 μs | 1.5668 μs | 1.089 |    0.01 | 1086.9141 |     - |     - | 2273665 B |
| StructLinq_IFunction |          4 |   100 |     4.476 μs | 0.0191 μs | 0.0169 μs | 0.008 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   487.405 μs | 4.9797 μs | 4.6580 μs | 0.916 |    0.01 | 1045.8984 |     - |     - | 2187584 B |
