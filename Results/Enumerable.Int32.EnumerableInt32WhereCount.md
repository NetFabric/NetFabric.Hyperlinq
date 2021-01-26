## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
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
|          ForeachLoop |   100 | 525.1 ns | 2.15 ns | 1.91 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 716.0 ns | 4.43 ns | 3.93 ns |  1.36 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 775.2 ns | 3.73 ns | 3.31 ns |  1.48 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 779.0 ns | 2.94 ns | 2.61 ns |  1.48 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 | 614.3 ns | 2.23 ns | 1.98 ns |  1.17 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 718.4 ns | 4.36 ns | 3.64 ns |  1.37 | 0.0191 |     - |     - |      40 B |
