## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|              ForLoop |          4 |   100 |   528.480 μs | 4.0398 μs | 3.5812 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   524.432 μs | 1.7165 μs | 1.5216 μs | 0.992 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   535.411 μs | 2.6999 μs | 2.3934 μs | 1.013 |    0.01 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.353 μs | 0.0064 μs | 0.0060 μs | 0.004 |    0.00 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,670.216 μs | 5.1795 μs | 4.3251 μs | 3.162 |    0.02 | 2187.5000 |     - |     - | 4575072 B |
|           StructLinq |          4 |   100 |   579.422 μs | 3.6310 μs | 3.2188 μs | 1.096 |    0.01 | 1086.9141 |     - |     - | 2273665 B |
| StructLinq_IFunction |          4 |   100 |     4.534 μs | 0.0124 μs | 0.0116 μs | 0.009 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   486.095 μs | 4.7285 μs | 3.9485 μs | 0.920 |    0.01 | 1045.8984 |     - |     - | 2187584 B |
