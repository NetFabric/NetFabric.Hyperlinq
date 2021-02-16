## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                      Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                 ForeachLoop |   100 |   440.0 ns | 1.49 ns | 1.39 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                        Linq |   100 | 1,074.2 ns | 2.74 ns | 2.56 ns |  2.44 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |   100 |   786.6 ns | 3.27 ns | 2.90 ns |  1.79 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |   100 |   605.9 ns | 1.58 ns | 1.40 ns |  1.38 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |   100 |   468.8 ns | 1.16 ns | 1.02 ns |  1.07 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |   100 |   576.1 ns | 2.19 ns | 2.05 ns |  1.31 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |   100 |   492.7 ns | 2.10 ns | 1.86 ns |  1.12 | 0.0191 |     - |     - |      40 B |
