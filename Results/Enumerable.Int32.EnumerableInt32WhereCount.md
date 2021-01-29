## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 501.5 ns | 4.31 ns | 3.60 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 690.7 ns | 3.18 ns | 2.65 ns |  1.38 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 703.0 ns | 4.24 ns | 3.97 ns |  1.40 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 741.5 ns | 2.40 ns | 2.25 ns |  1.48 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 | 560.1 ns | 1.83 ns | 1.62 ns |  1.12 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 689.8 ns | 3.95 ns | 3.30 ns |  1.38 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 | 464.1 ns | 2.53 ns | 2.24 ns |  0.92 | 0.0191 |     - |     - |      40 B |
