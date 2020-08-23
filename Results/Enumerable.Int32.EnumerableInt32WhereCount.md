## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 480.3 ns | 4.00 ns | 3.55 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 639.8 ns | 4.81 ns | 4.50 ns |  1.33 |    0.02 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 695.7 ns | 9.80 ns | 8.18 ns |  1.45 |    0.02 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 831.2 ns | 4.19 ns | 3.71 ns |  1.73 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |   100 | 491.5 ns | 3.44 ns | 3.22 ns |  1.02 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 613.2 ns | 2.64 ns | 2.34 ns |  1.28 |    0.01 | 0.0191 |     - |     - |      40 B |
