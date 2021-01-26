## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   497.9 ns | 2.79 ns | 2.47 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,137.3 ns | 7.39 ns | 6.55 ns |  2.28 |    0.02 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 |   932.9 ns | 5.36 ns | 4.75 ns |  1.87 |    0.02 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   843.8 ns | 4.08 ns | 3.41 ns |  1.70 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 |   591.2 ns | 3.10 ns | 2.90 ns |  1.19 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   923.9 ns | 3.67 ns | 3.26 ns |  1.86 |    0.01 | 0.0191 |     - |     - |      40 B |
