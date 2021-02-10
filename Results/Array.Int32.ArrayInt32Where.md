## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|              ForLoop |   100 |  65.66 ns | 0.162 ns | 0.151 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.63 ns | 0.274 ns | 0.256 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 484.32 ns | 6.210 ns | 5.185 ns |  7.38 |    0.09 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 282.52 ns | 1.097 ns | 1.026 ns |  4.30 |    0.02 | 0.3171 |     - |     - |     664 B |
|               LinqAF |   100 | 367.14 ns | 2.016 ns | 1.886 ns |  5.59 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 286.41 ns | 2.493 ns | 2.332 ns |  4.36 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 187.70 ns | 0.507 ns | 0.423 ns |  2.86 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 257.27 ns | 0.642 ns | 0.569 ns |  3.92 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 181.07 ns | 0.356 ns | 0.297 ns |  2.76 |    0.01 |      - |     - |     - |         - |
