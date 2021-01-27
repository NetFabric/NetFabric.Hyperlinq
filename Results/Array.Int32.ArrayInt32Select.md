## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 |  61.64 ns |  0.991 ns |  0.927 ns |  61.61 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  62.12 ns |  1.216 ns |  1.078 ns |  62.33 ns |  1.01 |    0.02 |      - |     - |     - |         - |
|                        Linq |   100 | 724.55 ns | 14.476 ns | 22.106 ns | 720.93 ns | 11.69 |    0.40 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 300.28 ns |  5.525 ns | 10.645 ns | 298.76 ns |  4.82 |    0.18 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 646.44 ns |  7.068 ns |  6.265 ns | 647.99 ns | 10.49 |    0.18 |      - |     - |     - |         - |
|                  StructLinq |   100 | 359.13 ns | 14.333 ns | 42.261 ns | 376.13 ns |  4.45 |    0.38 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 180.16 ns |  5.206 ns | 15.350 ns | 172.48 ns |  3.24 |    0.14 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 221.92 ns |  4.453 ns |  6.527 ns | 221.14 ns |  3.61 |    0.14 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 169.66 ns |  2.386 ns |  2.115 ns | 170.18 ns |  2.75 |    0.06 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 247.61 ns |  4.859 ns |  6.318 ns | 245.21 ns |  4.02 |    0.13 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  98.00 ns |  1.878 ns |  1.757 ns |  97.76 ns |  1.59 |    0.03 |      - |     - |     - |         - |
