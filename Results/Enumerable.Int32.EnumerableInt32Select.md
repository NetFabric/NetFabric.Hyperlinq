## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|                 ForeachLoop |   100 |   688.7 ns | 13.24 ns |  34.17 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                        Linq |   100 | 1,882.0 ns | 37.56 ns | 102.19 ns |  2.74 |    0.18 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |   100 | 1,533.6 ns | 30.66 ns |  86.48 ns |  2.23 |    0.16 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |   100 | 1,113.2 ns | 22.28 ns |  54.65 ns |  1.62 |    0.11 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |   100 |   750.4 ns | 14.95 ns |  29.15 ns |  1.09 |    0.07 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |   100 | 1,109.6 ns | 22.04 ns |  61.43 ns |  1.62 |    0.12 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |   100 |   735.9 ns | 14.61 ns |  20.95 ns |  1.07 |    0.07 | 0.0191 |     - |     - |      40 B |
