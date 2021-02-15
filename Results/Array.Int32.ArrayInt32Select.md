## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                      Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 |  61.21 ns | 0.326 ns | 0.305 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  45.93 ns | 0.309 ns | 0.289 ns |  0.75 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 770.43 ns | 7.332 ns | 6.500 ns | 12.58 |    0.15 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 277.26 ns | 1.687 ns | 1.496 ns |  4.53 |    0.04 | 0.2027 |     - |     - |     424 B |
|             LinqFaster_SIMD |   100 | 113.89 ns | 0.644 ns | 0.603 ns |  1.86 |    0.01 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 574.19 ns | 6.677 ns | 6.246 ns |  9.38 |    0.13 |      - |     - |     - |         - |
|                  StructLinq |   100 | 284.02 ns | 3.658 ns | 3.422 ns |  4.64 |    0.06 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 167.64 ns | 0.710 ns | 0.664 ns |  2.74 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 216.10 ns | 1.798 ns | 1.594 ns |  3.53 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |   100 | 162.89 ns | 0.820 ns | 0.684 ns |  2.66 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 248.93 ns | 3.826 ns | 3.195 ns |  4.06 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |   100 |  88.64 ns | 0.377 ns | 0.314 ns |  1.45 |    0.01 |      - |     - |     - |         - |
|              Hyperlinq_SIMD |   100 | 263.97 ns | 4.679 ns | 4.147 ns |  4.31 |    0.08 |      - |     - |     - |         - |
|    Hyperlinq_IFunction_SIMD |   100 | 169.00 ns | 0.639 ns | 0.598 ns |  2.76 |    0.02 |      - |     - |     - |         - |
