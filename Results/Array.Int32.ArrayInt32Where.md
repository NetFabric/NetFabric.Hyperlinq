## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
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
|              ForLoop |   100 |  74.00 ns |  0.145 ns |  0.121 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  74.04 ns |  0.316 ns |  0.264 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 792.72 ns | 25.013 ns | 72.963 ns |  9.83 |    0.53 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 280.98 ns |  0.812 ns |  0.760 ns |  3.80 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 695.22 ns | 13.888 ns | 31.630 ns |  9.43 |    0.46 |      - |     - |     - |         - |
|           StructLinq |   100 | 552.28 ns | 11.011 ns | 28.619 ns |  7.55 |    0.35 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 167.32 ns |  0.418 ns |  0.391 ns |  2.26 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 528.04 ns | 12.226 ns | 36.047 ns |  7.08 |    0.53 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 184.42 ns |  0.679 ns |  0.602 ns |  2.49 |    0.01 |      - |     - |     - |         - |
