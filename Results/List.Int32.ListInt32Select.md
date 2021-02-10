## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 |   140.86 ns |  0.350 ns |  0.310 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |   580.93 ns | 12.675 ns | 37.175 ns |  4.11 |    0.25 |      - |     - |     - |         - |
|                        Linq |   100 | 1,623.77 ns | 33.400 ns | 98.480 ns | 11.30 |    0.75 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 |   527.37 ns |  9.131 ns |  8.541 ns |  3.75 |    0.06 | 0.2174 |     - |     - |     456 B |
|                      LinqAF |   100 | 1,422.84 ns | 28.435 ns | 78.318 ns | 10.08 |    0.74 |      - |     - |     - |         - |
|                  StructLinq |   100 |   430.54 ns | 10.284 ns | 30.323 ns |  3.17 |    0.22 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 |   164.88 ns |  0.307 ns |  0.287 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 |   374.10 ns |  9.834 ns | 28.996 ns |  2.72 |    0.19 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |   100 |   161.52 ns |  0.529 ns |  0.441 ns |  1.15 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 |   490.68 ns | 18.452 ns | 54.405 ns |  3.51 |    0.39 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |   100 |    86.39 ns |  0.194 ns |  0.172 ns |  0.61 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |   100 |   941.26 ns | 20.454 ns | 60.309 ns |  6.69 |    0.50 |      - |     - |     - |         - |
|    Hyperlinq_SIMD_IFunction |   100 |   785.73 ns | 15.524 ns | 35.040 ns |  5.54 |    0.23 |      - |     - |     - |         - |
