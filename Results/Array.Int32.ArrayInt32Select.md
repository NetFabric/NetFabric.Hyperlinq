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
|                     ForLoop |   100 |  46.33 ns |  0.185 ns |  0.173 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  61.41 ns |  0.781 ns |  0.610 ns |  1.33 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 993.57 ns | 22.847 ns | 65.552 ns | 21.49 |    1.35 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 267.06 ns |  1.082 ns |  1.012 ns |  5.76 |    0.03 | 0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD |   100 | 101.76 ns |  0.667 ns |  0.624 ns |  2.20 |    0.01 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 898.48 ns | 18.228 ns | 53.172 ns | 19.95 |    1.22 |      - |     - |     - |         - |
|                  StructLinq |   100 | 350.27 ns |  7.030 ns | 17.894 ns |  7.50 |    0.34 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 163.26 ns |  0.396 ns |  0.370 ns |  3.52 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 306.78 ns |  9.207 ns | 26.565 ns |  6.72 |    0.51 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |   100 | 163.69 ns |  1.020 ns |  0.954 ns |  3.53 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 350.80 ns |  8.846 ns | 25.805 ns |  7.54 |    0.42 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |   100 |  86.62 ns |  0.257 ns |  0.201 ns |  1.87 |    0.01 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |   100 | 783.29 ns | 15.338 ns | 42.755 ns | 16.95 |    1.04 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |   100 | 631.65 ns | 13.285 ns | 38.542 ns | 13.45 |    0.75 |      - |     - |     - |         - |
