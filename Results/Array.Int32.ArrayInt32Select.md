## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
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
|                      Method | Count |      Mean |     Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 |  61.98 ns |  0.584 ns | 0.573 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  62.47 ns |  1.232 ns | 1.152 ns |  1.01 |    0.02 |      - |     - |     - |         - |
|                        Linq |   100 | 732.43 ns |  8.159 ns | 7.632 ns | 11.82 |    0.20 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 290.17 ns |  3.758 ns | 3.515 ns |  4.68 |    0.08 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 542.98 ns | 10.216 ns | 9.556 ns |  8.76 |    0.19 |      - |     - |     - |         - |
|                  StructLinq |   100 | 224.28 ns |  2.978 ns | 2.487 ns |  3.61 |    0.06 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 168.15 ns |  1.795 ns | 1.679 ns |  2.71 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 236.07 ns |  1.804 ns | 1.688 ns |  3.81 |    0.05 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 173.96 ns |  1.970 ns | 1.842 ns |  2.81 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 235.83 ns |  3.874 ns | 3.624 ns |  3.80 |    0.06 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  95.15 ns |  1.309 ns | 1.160 ns |  1.53 |    0.02 |      - |     - |     - |         - |
