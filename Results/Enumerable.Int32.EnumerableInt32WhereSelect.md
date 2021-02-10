## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   735.1 ns | 13.65 ns |  26.62 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,776.4 ns | 35.34 ns | 101.39 ns |  2.41 |    0.15 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 |   869.0 ns |  2.51 ns |   2.10 ns |  1.19 |    0.04 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,523.8 ns | 30.47 ns |  68.78 ns |  2.07 |    0.13 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   949.7 ns | 18.98 ns |  34.70 ns |  1.29 |    0.07 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,568.1 ns | 32.16 ns |  94.84 ns |  2.13 |    0.16 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   942.4 ns | 18.74 ns |  43.82 ns |  1.28 |    0.08 | 0.0191 |     - |     - |      40 B |
