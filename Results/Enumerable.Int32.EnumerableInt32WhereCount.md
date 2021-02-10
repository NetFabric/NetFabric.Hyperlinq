## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   777.2 ns | 15.40 ns | 26.56 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,521.6 ns | 29.71 ns | 40.67 ns |  1.96 |    0.09 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 1,224.3 ns | 24.25 ns | 65.14 ns |  1.58 |    0.09 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,143.8 ns | 22.07 ns | 49.36 ns |  1.47 |    0.08 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   817.4 ns | 16.35 ns | 28.21 ns |  1.05 |    0.05 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,166.2 ns | 25.24 ns | 74.41 ns |  1.51 |    0.11 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   719.7 ns | 14.24 ns | 32.72 ns |  0.93 |    0.05 | 0.0191 |     - |     - |      40 B |
