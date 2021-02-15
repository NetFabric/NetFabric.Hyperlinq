## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   554.2 ns |  5.49 ns |  5.14 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,258.7 ns | 11.77 ns | 11.01 ns |  2.27 |    0.02 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 |   802.7 ns | 13.18 ns | 11.01 ns |  1.45 |    0.02 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   809.9 ns | 11.77 ns | 11.01 ns |  1.46 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   579.1 ns |  4.14 ns |  3.67 ns |  1.05 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   755.5 ns |  9.22 ns |  8.62 ns |  1.36 |    0.02 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   519.8 ns |  6.55 ns |  6.12 ns |  0.94 |    0.01 | 0.0191 |     - |     - |      40 B |
