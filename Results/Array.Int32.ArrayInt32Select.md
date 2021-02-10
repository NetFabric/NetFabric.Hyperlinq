## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                      Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 |  61.06 ns |  1.056 ns |  0.936 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  59.62 ns |  0.454 ns |  0.425 ns |  0.98 |    0.02 |      - |     - |     - |         - |
|                        Linq |   100 | 957.29 ns | 19.032 ns | 49.468 ns | 15.30 |    0.71 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 267.78 ns |  1.345 ns |  1.258 ns |  4.39 |    0.06 | 0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD |   100 | 111.55 ns |  1.631 ns |  1.362 ns |  1.83 |    0.04 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 702.43 ns | 13.926 ns | 34.159 ns | 11.49 |    0.63 |      - |     - |     - |         - |
|                  StructLinq |   100 | 339.12 ns |  6.782 ns | 19.351 ns |  5.35 |    0.29 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 162.94 ns |  0.204 ns |  0.170 ns |  2.67 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 288.56 ns |  9.367 ns | 27.323 ns |  4.46 |    0.50 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |   100 | 161.45 ns |  1.877 ns |  1.567 ns |  2.65 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 311.55 ns |  8.915 ns | 26.006 ns |  5.18 |    0.30 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |   100 |  87.42 ns |  0.164 ns |  0.153 ns |  1.43 |    0.02 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |   100 | 657.69 ns | 13.798 ns | 40.249 ns | 10.94 |    0.70 |      - |     - |     - |         - |
|    Hyperlinq_IFunction_SIMD |   100 | 575.28 ns | 11.518 ns | 32.106 ns |  9.33 |    0.49 |      - |     - |     - |         - |
