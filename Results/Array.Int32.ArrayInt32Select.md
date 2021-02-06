## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
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
|                     ForLoop |   100 |  57.92 ns | 0.848 ns | 1.296 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  57.52 ns | 0.420 ns | 0.328 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 668.65 ns | 1.924 ns | 1.706 ns | 11.55 |    0.28 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 268.95 ns | 2.006 ns | 1.876 ns |  4.63 |    0.13 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 497.49 ns | 1.948 ns | 1.521 ns |  8.64 |    0.07 |      - |     - |     - |         - |
|                  StructLinq |   100 | 215.44 ns | 0.753 ns | 0.667 ns |  3.72 |    0.09 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 163.35 ns | 0.293 ns | 0.274 ns |  2.81 |    0.08 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 190.12 ns | 0.699 ns | 0.545 ns |  3.30 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 158.33 ns | 0.229 ns | 0.203 ns |  2.73 |    0.07 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 215.33 ns | 0.383 ns | 0.359 ns |  3.70 |    0.10 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  87.21 ns | 0.471 ns | 0.393 ns |  1.52 |    0.01 |      - |     - |     - |         - |
