## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 440.0 ns | 1.28 ns | 1.07 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 440.9 ns | 1.23 ns | 1.03 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 508.1 ns | 1.33 ns | 1.18 ns |  1.15 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 454.2 ns | 1.00 ns | 0.88 ns |  1.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 442.5 ns | 1.39 ns | 1.16 ns |  1.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 440.7 ns | 1.41 ns | 1.25 ns |  1.00 | 0.0191 |     - |     - |      40 B |
