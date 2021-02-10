## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                      Method | Count |       Mean |    Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-----------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 ForeachLoop |   100 |   701.2 ns | 13.31 ns |  29.50 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                        Linq |   100 | 1,962.6 ns | 51.86 ns | 152.90 ns |  2.78 |    0.22 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |   100 | 1,759.8 ns | 34.80 ns |  78.54 ns |  2.52 |    0.16 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |   100 | 1,116.9 ns | 22.33 ns |  55.20 ns |  1.60 |    0.11 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |   100 |   712.8 ns | 14.11 ns |  26.16 ns |  1.02 |    0.06 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |   100 | 1,125.4 ns | 22.72 ns |  66.64 ns |  1.61 |    0.12 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |   100 |   731.2 ns | 14.51 ns |  29.31 ns |  1.05 |    0.06 | 0.0191 |     - |     - |      40 B |
