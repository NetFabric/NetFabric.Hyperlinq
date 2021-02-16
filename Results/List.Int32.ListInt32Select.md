## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                     ForLoop |   100 | 136.94 ns | 0.455 ns | 0.380 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 218.44 ns | 0.600 ns | 0.532 ns |  1.60 |    0.00 |      - |     - |     - |         - |
|                        Linq |   100 | 823.77 ns | 2.374 ns | 2.221 ns |  6.01 |    0.02 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 | 407.33 ns | 1.245 ns | 1.040 ns |  2.97 |    0.01 | 0.2179 |     - |     - |     456 B |
|                      LinqAF |   100 | 743.93 ns | 1.710 ns | 1.335 ns |  5.43 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |   100 | 215.19 ns | 0.620 ns | 0.518 ns |  1.57 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 165.97 ns | 0.422 ns | 0.374 ns |  1.21 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 203.35 ns | 0.543 ns | 0.453 ns |  1.49 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |   100 | 179.71 ns | 0.500 ns | 0.443 ns |  1.31 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 218.77 ns | 0.673 ns | 0.562 ns |  1.60 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |   100 |  88.29 ns | 0.236 ns | 0.184 ns |  0.64 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |   100 | 227.28 ns | 0.722 ns | 0.640 ns |  1.66 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |   100 | 169.67 ns | 0.345 ns | 0.305 ns |  1.24 |    0.00 |      - |     - |     - |         - |
