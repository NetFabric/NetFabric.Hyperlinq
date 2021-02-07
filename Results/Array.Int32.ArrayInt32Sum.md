## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|              ForLoop |   100 |  43.21 ns | 0.074 ns | 0.066 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  43.38 ns | 0.112 ns | 0.093 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 430.98 ns | 1.228 ns | 1.089 ns |  9.97 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |  57.27 ns | 0.168 ns | 0.131 ns |  1.33 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |   100 |  11.63 ns | 0.078 ns | 0.065 ns |  0.27 |    0.00 |      - |     - |     - |         - |
|               LinqAF |   100 | 202.38 ns | 0.432 ns | 0.404 ns |  4.68 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 |  80.51 ns | 0.171 ns | 0.151 ns |  1.86 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  60.88 ns | 0.094 ns | 0.088 ns |  1.41 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |  26.13 ns | 0.131 ns | 0.116 ns |  0.60 |    0.00 |      - |     - |     - |         - |
