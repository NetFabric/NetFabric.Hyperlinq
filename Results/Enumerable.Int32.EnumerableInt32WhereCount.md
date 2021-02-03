## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|          ForeachLoop |   100 |   761.2 ns | 14.97 ns | 24.60 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,503.9 ns | 29.95 ns | 53.24 ns |  1.97 |    0.10 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 1,209.6 ns | 24.90 ns | 73.03 ns |  1.59 |    0.11 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,136.7 ns | 22.60 ns | 65.58 ns |  1.47 |    0.09 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   786.4 ns | 15.14 ns | 19.14 ns |  1.04 |    0.05 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,138.9 ns | 22.58 ns | 64.78 ns |  1.49 |    0.10 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   717.2 ns | 14.23 ns | 32.41 ns |  0.95 |    0.06 | 0.0191 |     - |     - |      40 B |
