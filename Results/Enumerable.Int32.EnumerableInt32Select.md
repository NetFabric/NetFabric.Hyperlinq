## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                      Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                 ForeachLoop |   100 |   437.2 ns | 0.80 ns | 0.67 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                        Linq |   100 | 1,014.8 ns | 2.80 ns | 2.48 ns |  2.32 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |   100 |   793.9 ns | 2.76 ns | 2.45 ns |  1.82 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |   100 |   573.5 ns | 1.03 ns | 0.86 ns |  1.31 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |   100 |   468.8 ns | 1.68 ns | 1.49 ns |  1.07 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |   100 |   643.5 ns | 2.09 ns | 1.64 ns |  1.47 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |   100 |   491.2 ns | 1.36 ns | 1.21 ns |  1.12 | 0.0191 |     - |     - |      40 B |
