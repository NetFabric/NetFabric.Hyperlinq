## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **64.34 ns** |  **0.407 ns** |  **0.361 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    64.58 ns |  0.241 ns |  0.214 ns |  1.00 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    70.96 ns |  0.212 ns |  0.177 ns |  1.10 |    0.01 | 0.0688 |     - |     - |     144 B |
|               LinqFaster |    10 |    54.05 ns |  0.168 ns |  0.140 ns |  0.84 |    0.01 | 0.0764 |     - |     - |     160 B |
|          LinqFaster_SIMD |    10 |    46.07 ns |  0.152 ns |  0.118 ns |  0.72 |    0.01 | 0.0764 |     - |     - |     160 B |
|                   LinqAF |    10 |   161.03 ns |  0.866 ns |  0.768 ns |  2.50 |    0.01 | 0.1030 |     - |     - |     216 B |
|               StructLinq |    10 |    58.67 ns |  0.237 ns |  0.198 ns |  0.91 |    0.00 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    41.03 ns |  0.106 ns |  0.099 ns |  0.64 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    39.85 ns |  0.095 ns |  0.079 ns |  0.62 |    0.00 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    27.24 ns |  0.072 ns |  0.067 ns |  0.42 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    43.84 ns |  0.128 ns |  0.114 ns |  0.68 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    27.92 ns |  0.112 ns |  0.099 ns |  0.43 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |       |             |           |           |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,179.09 ns** | **15.532 ns** | **13.769 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |    **8424 B** |
|              ForeachLoop |  1000 | 2,167.68 ns | 10.112 ns |  8.444 ns |  1.00 |    0.01 | 4.0207 |     - |     - |    8424 B |
|                     Linq |  1000 | 2,835.84 ns | 11.528 ns | 10.220 ns |  1.30 |    0.01 | 1.9608 |     - |     - |    4104 B |
|               LinqFaster |  1000 | 2,295.12 ns |  7.791 ns |  6.506 ns |  1.05 |    0.01 | 3.8605 |     - |     - |    8080 B |
|          LinqFaster_SIMD |  1000 |   739.02 ns |  8.120 ns |  7.595 ns |  0.34 |    0.00 | 3.8605 |     - |     - |    8080 B |
|                   LinqAF |  1000 | 7,056.92 ns | 22.590 ns | 21.131 ns |  3.24 |    0.02 | 4.0207 |     - |     - |    8424 B |
|               StructLinq |  1000 | 2,047.25 ns |  7.853 ns |  6.558 ns |  0.94 |    0.01 | 1.9684 |     - |     - |    4120 B |
|     StructLinq_IFunction |  1000 |   935.54 ns |  4.730 ns |  3.950 ns |  0.43 |    0.00 | 1.9569 |     - |     - |    4096 B |
|                Hyperlinq |  1000 | 1,772.50 ns |  3.663 ns |  3.247 ns |  0.81 |    0.00 | 1.9341 |     - |     - |    4056 B |
|      Hyperlinq_IFunction |  1000 | 1,236.30 ns |  2.196 ns |  1.715 ns |  0.57 |    0.00 | 1.9341 |     - |     - |    4056 B |
|           Hyperlinq_SIMD |  1000 |   537.30 ns |  1.926 ns |  1.802 ns |  0.25 |    0.00 | 1.9341 |     - |     - |    4056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   308.76 ns |  1.198 ns |  1.062 ns |  0.14 |    0.00 | 1.9341 |     - |     - |    4056 B |
