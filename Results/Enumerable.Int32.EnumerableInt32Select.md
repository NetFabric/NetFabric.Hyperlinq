## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                      Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                 ForeachLoop |   100 |   438.3 ns | 0.60 ns | 0.47 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                        Linq |   100 | 1,017.6 ns | 2.36 ns | 2.21 ns |  2.32 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |   100 |   792.3 ns | 2.05 ns | 1.92 ns |  1.81 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |   100 |   576.6 ns | 1.11 ns | 0.98 ns |  1.32 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |   100 |   445.5 ns | 0.96 ns | 0.85 ns |  1.02 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |   100 |   572.8 ns | 1.69 ns | 1.50 ns |  1.31 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |   100 |   442.2 ns | 1.13 ns | 1.00 ns |  1.01 | 0.0191 |     - |     - |      40 B |
