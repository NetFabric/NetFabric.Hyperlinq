## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|          ForeachLoop |   100 | 1.787 μs | 0.0129 μs | 0.0121 μs |  1.00 | 2.8896 |     - |     - |    6048 B |
|                 Linq |   100 | 2.682 μs | 0.0073 μs | 0.0065 μs |  1.50 | 2.0638 |     - |     - |    4320 B |
|               LinqAF |   100 | 3.777 μs | 0.0073 μs | 0.0065 μs |  2.11 | 2.5024 |     - |     - |    5240 B |
|           StructLinq |   100 | 2.194 μs | 0.0046 μs | 0.0043 μs |  1.23 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 2.168 μs | 0.0062 μs | 0.0058 μs |  1.21 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 2.004 μs | 0.0092 μs | 0.0081 μs |  1.12 | 0.0191 |     - |     - |      40 B |
