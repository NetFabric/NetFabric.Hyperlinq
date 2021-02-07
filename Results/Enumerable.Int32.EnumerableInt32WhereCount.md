## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|          ForeachLoop |   100 | 493.0 ns | 1.36 ns | 1.21 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 621.8 ns | 1.61 ns | 1.50 ns |  1.26 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 630.0 ns | 1.93 ns | 1.71 ns |  1.28 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 663.0 ns | 2.35 ns | 2.08 ns |  1.34 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 | 504.6 ns | 2.10 ns | 1.96 ns |  1.02 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 610.4 ns | 2.24 ns | 1.87 ns |  1.24 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 | 439.6 ns | 0.97 ns | 0.86 ns |  0.89 | 0.0191 |     - |     - |      40 B |
