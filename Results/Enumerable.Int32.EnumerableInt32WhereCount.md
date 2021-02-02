## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|          ForeachLoop |   100 | 451.9 ns | 1.03 ns | 0.96 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 620.8 ns | 1.95 ns | 1.73 ns |  1.37 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 629.9 ns | 2.20 ns | 1.95 ns |  1.39 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 672.6 ns | 2.44 ns | 2.17 ns |  1.49 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 | 482.3 ns | 1.43 ns | 1.20 ns |  1.07 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 694.6 ns | 1.41 ns | 1.10 ns |  1.54 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 | 466.8 ns | 0.90 ns | 0.84 ns |  1.03 | 0.0191 |     - |     - |      40 B |
