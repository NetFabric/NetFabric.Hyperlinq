## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|          ForeachLoop |   100 | 488.8 ns | 0.83 ns | 0.74 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 946.9 ns | 3.49 ns | 3.10 ns |  1.94 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 | 879.6 ns | 1.84 ns | 1.63 ns |  1.80 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 833.6 ns | 0.99 ns | 0.82 ns |  1.71 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 | 528.3 ns | 1.74 ns | 1.54 ns |  1.08 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 836.2 ns | 1.66 ns | 1.47 ns |  1.71 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 | 517.5 ns | 1.49 ns | 1.24 ns |  1.06 | 0.0191 |     - |     - |      40 B |
