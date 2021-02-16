## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 498.3 ns | 2.14 ns | 1.90 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 623.1 ns | 2.79 ns | 2.33 ns |  1.25 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 633.1 ns | 2.49 ns | 2.21 ns |  1.27 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 674.7 ns | 3.40 ns | 3.18 ns |  1.35 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 | 507.6 ns | 3.50 ns | 2.93 ns |  1.02 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 624.8 ns | 2.62 ns | 2.18 ns |  1.25 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 | 441.5 ns | 1.63 ns | 1.44 ns |  0.89 | 0.0191 |     - |     - |      40 B |
