## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                           Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          ForLoop |   100 |  43.89 ns | 0.125 ns | 0.105 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                      ForeachLoop |   100 |  43.74 ns | 0.088 ns | 0.078 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                             Linq |   100 | 667.80 ns | 2.539 ns | 1.982 ns | 15.22 |    0.07 | 0.0229 |     - |     - |      48 B |
|                       LinqFaster |   100 | 263.88 ns | 1.163 ns | 1.031 ns |  6.01 |    0.03 | 0.2027 |     - |     - |     424 B |
|                  LinqFaster_SIMD |   100 |  97.75 ns | 0.928 ns | 0.868 ns |  2.23 |    0.02 | 0.2027 |     - |     - |     424 B |
|                           LinqAF |   100 | 495.32 ns | 2.747 ns | 2.294 ns | 11.29 |    0.05 |      - |     - |     - |         - |
|                       StructLinq |   100 | 228.91 ns | 0.299 ns | 0.265 ns |  5.22 |    0.01 | 0.0153 |     - |     - |      32 B |
|             StructLinq_IFunction |   100 | 162.64 ns | 0.190 ns | 0.148 ns |  3.71 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq_Foreach |   100 | 190.59 ns | 0.667 ns | 0.557 ns |  4.34 |    0.02 |      - |     - |     - |         - |
|      Hyperlinq_Foreach_IFunction |   100 | 157.35 ns | 0.274 ns | 0.214 ns |  3.59 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_SIMD_Foreach |   100 | 141.74 ns | 1.892 ns | 1.677 ns |  3.22 |    0.03 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_SIMD_IFunction_Foreach |   100 |  89.38 ns | 0.627 ns | 0.586 ns |  2.04 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_For |   100 | 189.02 ns | 0.610 ns | 0.509 ns |  4.31 |    0.02 |      - |     - |     - |         - |
|          Hyperlinq_For_IFunction |   100 |  86.50 ns | 0.145 ns | 0.121 ns |  1.97 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_SIMD_For |   100 | 135.12 ns | 0.470 ns | 0.393 ns |  3.08 |    0.01 | 0.2027 |     - |     - |     424 B |
|     Hyperlinq_SIMD_IFunction_For |   100 | 100.07 ns | 0.711 ns | 0.594 ns |  2.28 |    0.02 | 0.2027 |     - |     - |     424 B |
