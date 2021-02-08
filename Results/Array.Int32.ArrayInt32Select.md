## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|                     ForLoop |   100 |  59.23 ns |  0.349 ns |  0.291 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  46.64 ns |  0.222 ns |  0.196 ns |  0.79 |    0.00 |      - |     - |     - |         - |
|                        Linq |   100 | 707.12 ns | 13.901 ns | 13.652 ns | 11.94 |    0.22 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 261.83 ns |  2.222 ns |  1.969 ns |  4.42 |    0.04 | 0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD |   100 | 116.33 ns |  1.131 ns |  1.058 ns |  1.97 |    0.02 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 723.55 ns |  9.740 ns |  8.634 ns | 12.20 |    0.14 |      - |     - |     - |         - |
|                  StructLinq |   100 | 274.21 ns |  2.991 ns |  2.335 ns |  4.63 |    0.04 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 168.75 ns |  1.039 ns |  0.921 ns |  2.85 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 204.52 ns |  2.650 ns |  2.213 ns |  3.45 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |   100 | 163.55 ns |  0.927 ns |  0.867 ns |  2.76 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 232.49 ns |  2.439 ns |  2.162 ns |  3.92 |    0.04 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |   100 |  89.35 ns |  0.819 ns |  0.726 ns |  1.51 |    0.01 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |   100 | 588.01 ns | 11.236 ns | 10.511 ns |  9.94 |    0.20 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |   100 | 526.38 ns |  5.188 ns |  4.332 ns |  8.89 |    0.09 |      - |     - |     - |         - |
