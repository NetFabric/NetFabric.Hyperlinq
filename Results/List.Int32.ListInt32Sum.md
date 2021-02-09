## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|              ForLoop |   100 |   104.28 ns |  0.261 ns |  0.218 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   523.62 ns | 10.624 ns | 31.159 ns |  5.08 |    0.34 |      - |     - |     - |         - |
|                 Linq |   100 | 1,459.79 ns | 29.058 ns | 79.545 ns | 14.21 |    0.58 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |   100 | 1,463.78 ns | 29.276 ns | 77.636 ns | 13.93 |    0.79 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 1,193.35 ns | 29.408 ns | 86.709 ns | 11.61 |    1.06 |      - |     - |     - |         - |
|           StructLinq |   100 |    92.70 ns |  0.385 ns |  0.341 ns |  0.89 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |    67.00 ns |  0.354 ns |  0.295 ns |  0.64 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |    28.69 ns |  0.588 ns |  0.577 ns |  0.28 |    0.01 |      - |     - |     - |         - |
