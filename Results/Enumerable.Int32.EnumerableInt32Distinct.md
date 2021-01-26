## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 2.099 μs | 0.0174 μs | 0.0154 μs |  1.00 | 2.8877 |     - |     - |    6048 B |
|                 Linq |   100 | 3.040 μs | 0.0122 μs | 0.0108 μs |  1.45 | 2.0638 |     - |     - |    4320 B |
|               LinqAF |   100 | 4.110 μs | 0.0219 μs | 0.0194 μs |  1.96 | 2.5024 |     - |     - |    5240 B |
|           StructLinq |   100 | 2.633 μs | 0.0098 μs | 0.0092 μs |  1.25 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 2.409 μs | 0.0151 μs | 0.0126 μs |  1.15 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 2.252 μs | 0.0097 μs | 0.0086 μs |  1.07 | 0.0191 |     - |     - |      40 B |
