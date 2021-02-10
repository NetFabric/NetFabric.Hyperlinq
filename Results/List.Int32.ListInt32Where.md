## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  97.45 ns | 0.433 ns | 0.405 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 210.42 ns | 0.792 ns | 0.661 ns |  2.16 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 774.41 ns | 5.877 ns | 5.210 ns |  7.95 |    0.07 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 402.93 ns | 1.734 ns | 1.537 ns |  4.14 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 942.92 ns | 3.678 ns | 3.440 ns |  9.68 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 | 292.07 ns | 2.475 ns | 2.194 ns |  3.00 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 166.97 ns | 0.918 ns | 0.814 ns |  1.71 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 237.53 ns | 0.913 ns | 0.809 ns |  2.44 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 181.90 ns | 0.427 ns | 0.378 ns |  1.87 |    0.01 |      - |     - |     - |         - |
