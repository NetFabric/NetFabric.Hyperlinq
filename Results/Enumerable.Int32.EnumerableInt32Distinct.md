## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 2.007 μs | 0.0267 μs | 0.0223 μs |  1.00 |    0.00 | 2.8877 |     - |     - |    6048 B |
|                 Linq |   100 | 2.955 μs | 0.0239 μs | 0.0199 μs |  1.47 |    0.02 | 2.0638 |     - |     - |    4320 B |
|               LinqAF |   100 | 3.803 μs | 0.0111 μs | 0.0104 μs |  1.90 |    0.02 | 2.5024 |     - |     - |    5240 B |
|           StructLinq |   100 | 2.982 μs | 0.0597 μs | 0.0755 μs |  1.49 |    0.06 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 2.949 μs | 0.0589 μs | 0.0917 μs |  1.47 |    0.04 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 3.184 μs | 0.0627 μs | 0.1146 μs |  1.57 |    0.05 | 0.0191 |     - |     - |      40 B |
