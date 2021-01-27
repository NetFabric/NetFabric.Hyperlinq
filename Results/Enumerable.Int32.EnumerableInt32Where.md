## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 877.9 ns | 2.39 ns | 2.12 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 | 812.2 ns | 2.55 ns | 2.13 ns |  0.93 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 701.4 ns | 1.45 ns | 1.29 ns |  0.80 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 560.5 ns | 3.10 ns | 2.42 ns |  0.64 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 702.6 ns | 3.28 ns | 2.91 ns |  0.80 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 | 521.7 ns | 2.04 ns | 1.81 ns |  0.59 | 0.0191 |     - |     - |      40 B |
