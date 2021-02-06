## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|          ForeachLoop |   100 |   752.5 ns | 14.83 ns | 25.57 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,570.1 ns | 31.32 ns | 44.92 ns |  2.09 |    0.09 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 1,212.3 ns | 24.24 ns | 69.56 ns |  1.61 |    0.12 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,128.5 ns | 22.48 ns | 48.87 ns |  1.51 |    0.09 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   783.0 ns | 15.58 ns | 34.84 ns |  1.05 |    0.06 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,129.5 ns | 23.47 ns | 68.83 ns |  1.48 |    0.10 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |   100 |   715.9 ns | 14.33 ns | 31.74 ns |  0.95 |    0.05 | 0.0191 |     - |     - |      40 B |
