## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|                 Linq |   100 | 933.1 ns | 2.90 ns | 2.26 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 | 800.2 ns | 1.48 ns | 1.39 ns |  0.86 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 736.3 ns | 1.60 ns | 1.33 ns |  0.79 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 560.5 ns | 1.63 ns | 1.36 ns |  0.60 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 707.8 ns | 1.32 ns | 1.11 ns |  0.76 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 | 524.2 ns | 2.30 ns | 1.92 ns |  0.56 | 0.0191 |     - |     - |      40 B |
