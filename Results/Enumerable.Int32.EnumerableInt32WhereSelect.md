## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|          ForeachLoop |   100 |   698.4 ns | 13.35 ns | 13.71 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,751.7 ns | 34.62 ns | 63.30 ns |  2.53 |    0.12 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 |   878.2 ns |  2.46 ns |  2.05 ns |  1.26 |    0.03 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,470.4 ns | 29.07 ns | 66.21 ns |  2.10 |    0.10 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   918.0 ns | 18.12 ns | 35.76 ns |  1.31 |    0.04 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,470.9 ns | 29.16 ns | 68.16 ns |  2.07 |    0.11 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   897.9 ns | 17.93 ns | 41.55 ns |  1.29 |    0.06 | 0.0191 |     - |     - |      40 B |
