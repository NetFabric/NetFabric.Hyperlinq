## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                   Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 317.96 ns | 2.419 ns | 2.263 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|              ForeachLoop |   100 | 317.23 ns | 3.639 ns | 3.226 ns |  1.00 |    0.01 | 0.5660 |     - |     - |    1184 B |
|                     Linq |   100 | 332.73 ns | 3.443 ns | 3.220 ns |  1.05 |    0.02 | 0.2408 |     - |     - |     504 B |
|               LinqFaster |   100 | 262.60 ns | 0.720 ns | 0.602 ns |  0.83 |    0.01 | 0.4206 |     - |     - |     880 B |
|          LinqFaster_SIMD |   100 | 110.90 ns | 0.669 ns | 0.626 ns |  0.35 |    0.00 | 0.4207 |     - |     - |     880 B |
|                   LinqAF |   100 | 900.51 ns | 3.982 ns | 3.530 ns |  2.83 |    0.03 | 0.5655 |     - |     - |    1184 B |
|               StructLinq |   100 | 247.43 ns | 1.315 ns | 1.230 ns |  0.78 |    0.01 | 0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction |   100 | 134.87 ns | 0.910 ns | 0.851 ns |  0.42 |    0.00 | 0.2370 |     - |     - |     496 B |
|                Hyperlinq |   100 | 233.43 ns | 0.686 ns | 0.536 ns |  0.73 |    0.01 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction |   100 | 146.24 ns | 1.146 ns | 1.072 ns |  0.46 |    0.00 | 0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD |   100 |  89.16 ns | 0.704 ns | 0.659 ns |  0.28 |    0.00 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD |   100 |  61.00 ns | 0.548 ns | 0.513 ns |  0.19 |    0.00 | 0.2180 |     - |     - |     456 B |
