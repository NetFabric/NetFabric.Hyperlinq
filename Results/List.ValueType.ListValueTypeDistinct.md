## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop |          4 |   100 |   584.337 μs |  4.2335 μs |  3.7529 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   593.824 μs |  3.5617 μs |  3.1574 μs | 1.016 |    0.01 | 1095.7031 |     - |     - | 2292185 B |
|                 Linq |          4 |   100 |   637.725 μs |  3.4987 μs |  3.2727 μs | 1.091 |    0.01 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     3.489 μs |  0.0098 μs |  0.0092 μs | 0.006 |    0.00 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,977.428 μs | 18.6047 μs | 17.4029 μs | 3.387 |    0.03 | 2187.5000 |     - |     - | 4575073 B |
|           StructLinq |          4 |   100 |   672.911 μs |  3.0489 μs |  2.5460 μs | 1.151 |    0.01 | 1086.9141 |     - |     - | 2273665 B |
| StructLinq_IFunction |          4 |   100 |     5.190 μs |  0.0220 μs |  0.0195 μs | 0.009 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   567.301 μs |  4.7087 μs |  4.1742 μs | 0.971 |    0.01 | 1045.8984 |     - |     - | 2187585 B |
