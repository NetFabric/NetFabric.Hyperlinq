## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 1,017.4 ns | 4.02 ns | 3.76 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 |   900.6 ns | 3.26 ns | 2.72 ns |  0.89 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   756.1 ns | 4.25 ns | 3.55 ns |  0.74 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   576.5 ns | 2.54 ns | 2.25 ns |  0.57 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   737.2 ns | 6.12 ns | 5.73 ns |  0.72 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   635.4 ns | 2.74 ns | 2.43 ns |  0.62 | 0.0191 |     - |     - |      40 B |
