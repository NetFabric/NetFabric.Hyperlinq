## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                 Linq |   100 | 1,042.6 ns | 8.99 ns | 8.41 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 |   870.7 ns | 4.36 ns | 3.64 ns |  0.84 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   808.1 ns | 3.83 ns | 3.39 ns |  0.78 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   572.2 ns | 3.80 ns | 3.18 ns |  0.55 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 |   796.1 ns | 3.78 ns | 3.35 ns |  0.76 | 0.0191 |     - |     - |      40 B |
