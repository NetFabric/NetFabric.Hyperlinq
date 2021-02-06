## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|          ForeachLoop |   100 |   723.7 ns | 14.37 ns | 35.26 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,725.1 ns | 34.45 ns | 68.00 ns |  2.39 |    0.15 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 |   908.1 ns |  6.19 ns |  5.48 ns |  1.25 |    0.06 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,442.7 ns | 28.83 ns | 81.78 ns |  1.99 |    0.15 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   942.8 ns | 18.30 ns | 35.68 ns |  1.31 |    0.08 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,474.7 ns | 29.47 ns | 78.67 ns |  2.05 |    0.15 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   906.6 ns | 18.01 ns | 36.39 ns |  1.26 |    0.08 | 0.0191 |     - |     - |      40 B |
