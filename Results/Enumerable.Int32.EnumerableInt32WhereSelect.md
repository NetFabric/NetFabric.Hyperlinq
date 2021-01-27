## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|          ForeachLoop |   100 | 489.4 ns | 1.25 ns | 1.11 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 947.0 ns | 2.97 ns | 2.63 ns |  1.94 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 | 895.0 ns | 2.18 ns | 1.93 ns |  1.83 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 771.7 ns | 2.26 ns | 2.00 ns |  1.58 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 | 578.2 ns | 1.76 ns | 1.56 ns |  1.18 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 730.0 ns | 3.29 ns | 2.91 ns |  1.49 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 | 518.9 ns | 2.42 ns | 2.15 ns |  1.06 | 0.0191 |     - |     - |      40 B |
