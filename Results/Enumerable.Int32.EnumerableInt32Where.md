## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 1,083.6 ns | 10.18 ns |  9.52 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 |   954.8 ns |  8.63 ns |  7.65 ns |  0.88 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   898.3 ns |  6.67 ns |  5.57 ns |  0.83 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   637.7 ns |  4.06 ns |  3.60 ns |  0.59 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   895.5 ns |  6.38 ns |  5.33 ns |  0.82 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   621.8 ns | 12.41 ns | 12.19 ns |  0.57 | 0.0191 |     - |     - |      40 B |
