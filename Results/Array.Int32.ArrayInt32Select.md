## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 |  43.79 ns | 0.120 ns | 0.106 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  57.26 ns | 0.156 ns | 0.145 ns |  1.31 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 663.04 ns | 2.060 ns | 1.927 ns | 15.14 |    0.05 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 265.58 ns | 1.464 ns | 1.369 ns |  6.06 |    0.03 | 0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD |   100 | 105.40 ns | 0.402 ns | 0.314 ns |  2.41 |    0.01 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 550.42 ns | 1.079 ns | 1.010 ns | 12.57 |    0.03 |      - |     - |     - |         - |
|                  StructLinq |   100 | 215.29 ns | 0.409 ns | 0.363 ns |  4.92 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 163.54 ns | 0.558 ns | 0.466 ns |  3.73 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 189.11 ns | 0.752 ns | 0.666 ns |  4.32 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |   100 | 168.84 ns | 1.044 ns | 0.871 ns |  3.86 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 213.78 ns | 0.585 ns | 0.518 ns |  4.88 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |   100 |  86.50 ns | 0.118 ns | 0.098 ns |  1.98 |    0.01 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |   100 | 227.26 ns | 0.794 ns | 0.620 ns |  5.19 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_IFunction_SIMD |   100 | 165.07 ns | 0.209 ns | 0.163 ns |  3.77 |    0.01 |      - |     - |     - |         - |
