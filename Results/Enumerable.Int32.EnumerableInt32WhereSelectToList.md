## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   757.2 ns |  4.41 ns |  3.91 ns |  1.00 |    0.00 | 0.3281 |     - |     - |     688 B |
|                 Linq |   100 | 1,132.0 ns |  5.79 ns |  4.84 ns |  1.49 |    0.01 | 0.3853 |     - |     - |     808 B |
|               LinqAF |   100 | 1,210.0 ns | 15.11 ns | 13.40 ns |  1.60 |    0.02 | 0.3281 |     - |     - |     688 B |
|           StructLinq |   100 | 1,167.8 ns |  5.61 ns |  4.98 ns |  1.54 |    0.01 | 0.1831 |     - |     - |     384 B |
| StructLinq_IFunction |   100 |   817.7 ns |  6.20 ns |  5.50 ns |  1.08 |    0.01 | 0.1411 |     - |     - |     296 B |
|            Hyperlinq |   100 | 1,164.4 ns |  7.16 ns |  6.70 ns |  1.54 |    0.01 | 0.1755 |     - |     - |     368 B |
