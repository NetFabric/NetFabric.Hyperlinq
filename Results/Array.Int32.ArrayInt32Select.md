## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 |  57.69 ns | 0.838 ns | 0.700 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  57.29 ns | 0.171 ns | 0.133 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 637.51 ns | 2.182 ns | 2.041 ns | 11.05 |    0.14 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 271.55 ns | 4.001 ns | 3.742 ns |  4.71 |    0.08 | 0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD |   100 | 114.75 ns | 0.385 ns | 0.341 ns |  1.99 |    0.02 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 565.75 ns | 1.718 ns | 1.523 ns |  9.81 |    0.12 |      - |     - |     - |         - |
|                  StructLinq |   100 | 229.63 ns | 0.483 ns | 0.403 ns |  3.98 |    0.05 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 163.22 ns | 0.541 ns | 0.480 ns |  2.83 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 190.22 ns | 0.453 ns | 0.402 ns |  3.30 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 158.12 ns | 0.398 ns | 0.353 ns |  2.74 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 216.14 ns | 0.879 ns | 0.822 ns |  3.75 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  87.19 ns | 0.418 ns | 0.326 ns |  1.51 |    0.02 |      - |     - |     - |         - |
