## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|          ForeachLoop |   100 |   744.8 ns | 14.86 ns | 31.98 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,488.3 ns | 28.99 ns | 43.40 ns |  2.00 |    0.10 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 1,171.4 ns | 23.38 ns | 67.83 ns |  1.57 |    0.11 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,118.7 ns | 22.12 ns | 48.08 ns |  1.50 |    0.09 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   767.3 ns | 15.12 ns | 21.20 ns |  1.03 |    0.06 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,111.0 ns | 23.44 ns | 69.11 ns |  1.49 |    0.11 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   815.7 ns | 16.05 ns | 29.75 ns |  1.10 |    0.06 | 0.0191 |     - |     - |      40 B |
