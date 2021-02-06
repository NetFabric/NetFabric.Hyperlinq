## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  38.81 ns | 0.694 ns | 0.743 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 470.32 ns | 1.090 ns | 0.910 ns | 12.15 |    0.21 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 566.56 ns | 2.896 ns | 2.418 ns | 14.64 |    0.23 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 308.99 ns | 1.609 ns | 1.505 ns |  7.96 |    0.16 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD |     0 |   100 | 140.95 ns | 0.800 ns | 0.668 ns |  3.64 |    0.07 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 419.93 ns | 1.245 ns | 1.103 ns | 10.86 |    0.18 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 181.23 ns | 0.214 ns | 0.167 ns |  4.68 |    0.08 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 162.22 ns | 0.316 ns | 0.295 ns |  4.18 |    0.09 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 204.63 ns | 0.731 ns | 0.648 ns |  5.29 |    0.09 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 166.15 ns | 0.177 ns | 0.165 ns |  4.28 |    0.09 |      - |     - |     - |         - |
