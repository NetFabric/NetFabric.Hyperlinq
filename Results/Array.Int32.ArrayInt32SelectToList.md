## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                   Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 305.64 ns | 2.573 ns | 2.407 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|              ForeachLoop |   100 | 310.77 ns | 1.770 ns | 1.656 ns |  1.02 |    0.01 | 0.5660 |     - |     - |    1184 B |
|                     Linq |   100 | 321.48 ns | 1.330 ns | 1.244 ns |  1.05 |    0.01 | 0.2408 |     - |     - |     504 B |
|               LinqFaster |   100 | 258.73 ns | 2.756 ns | 2.443 ns |  0.85 |    0.01 | 0.4206 |     - |     - |     880 B |
|          LinqFaster_SIMD |   100 | 112.79 ns | 1.361 ns | 1.273 ns |  0.37 |    0.00 | 0.4207 |     - |     - |     880 B |
|                   LinqAF |   100 | 886.06 ns | 6.783 ns | 6.345 ns |  2.90 |    0.03 | 0.5655 |     - |     - |    1184 B |
|               StructLinq |   100 | 243.05 ns | 1.077 ns | 1.007 ns |  0.80 |    0.01 | 0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction |   100 | 132.76 ns | 0.647 ns | 0.605 ns |  0.43 |    0.00 | 0.2370 |     - |     - |     496 B |
|                Hyperlinq |   100 | 228.59 ns | 0.553 ns | 0.517 ns |  0.75 |    0.01 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction |   100 | 142.51 ns | 0.923 ns | 0.770 ns |  0.47 |    0.00 | 0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD |   100 |  98.33 ns | 0.495 ns | 0.463 ns |  0.32 |    0.00 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD |   100 |  69.35 ns | 0.481 ns | 0.450 ns |  0.23 |    0.00 | 0.2180 |     - |     - |     456 B |
