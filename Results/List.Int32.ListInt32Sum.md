## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
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
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   102.88 ns |  0.164 ns |  0.145 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   414.30 ns | 10.349 ns | 30.351 ns |  4.20 |    0.18 |      - |     - |     - |         - |
|                 Linq |   100 | 1,115.08 ns | 23.361 ns | 67.773 ns | 11.10 |    0.56 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |   100 | 1,087.13 ns | 22.992 ns | 67.069 ns | 10.68 |    0.63 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 |   969.87 ns | 22.738 ns | 66.687 ns |  9.68 |    0.52 |      - |     - |     - |         - |
|           StructLinq |   100 |    83.71 ns |  0.311 ns |  0.276 ns |  0.81 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |    65.98 ns |  0.247 ns |  0.231 ns |  0.64 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |    57.05 ns |  0.147 ns |  0.130 ns |  0.55 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |    56.92 ns |  0.161 ns |  0.151 ns |  0.55 |    0.00 |      - |     - |     - |         - |
