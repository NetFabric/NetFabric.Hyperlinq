## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  42.24 ns |  0.052 ns |  0.046 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  43.59 ns |  0.125 ns |  0.104 ns |  1.03 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 733.96 ns | 17.291 ns | 50.713 ns | 17.03 |    1.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |  63.18 ns |  0.472 ns |  0.442 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |   100 |  14.60 ns |  0.251 ns |  0.308 ns |  0.34 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 218.19 ns |  0.950 ns |  0.889 ns |  5.17 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |  83.19 ns |  0.346 ns |  0.270 ns |  1.97 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  63.25 ns |  0.243 ns |  0.227 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |  57.62 ns |  0.389 ns |  0.324 ns |  1.36 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  56.32 ns |  0.372 ns |  0.310 ns |  1.33 |    0.01 |      - |     - |     - |         - |
