## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|          ForeachLoop |   100 |   556.3 ns |  7.45 ns |  6.97 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,285.8 ns | 16.73 ns | 14.83 ns |  2.31 |    0.03 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 |   954.2 ns |  6.53 ns |  5.79 ns |  1.71 |    0.02 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   975.4 ns | 14.75 ns | 13.08 ns |  1.75 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   640.1 ns |  3.56 ns |  3.16 ns |  1.15 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   980.7 ns | 18.72 ns | 17.51 ns |  1.76 |    0.04 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   648.5 ns |  5.25 ns |  4.65 ns |  1.16 |    0.02 | 0.0191 |     - |     - |      40 B |
