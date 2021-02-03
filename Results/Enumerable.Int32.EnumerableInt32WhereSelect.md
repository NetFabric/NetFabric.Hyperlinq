## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|          ForeachLoop |   100 |   759.5 ns | 14.99 ns | 28.52 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,732.6 ns | 34.69 ns | 75.41 ns |  2.29 |    0.14 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 | 1,634.4 ns | 32.24 ns | 76.63 ns |  2.16 |    0.14 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,507.9 ns | 30.16 ns | 82.04 ns |  1.98 |    0.14 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   893.4 ns | 17.71 ns | 37.35 ns |  1.18 |    0.07 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,517.8 ns | 30.25 ns | 68.90 ns |  2.00 |    0.13 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   920.4 ns | 18.30 ns | 40.56 ns |  1.21 |    0.06 | 0.0191 |     - |     - |      40 B |
