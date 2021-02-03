## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|                     ForLoop |   100 |  57.14 ns | 0.217 ns | 0.192 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  57.28 ns | 0.344 ns | 0.288 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 671.37 ns | 2.655 ns | 2.217 ns | 11.75 |    0.06 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 267.31 ns | 1.411 ns | 1.251 ns |  4.68 |    0.02 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 494.65 ns | 1.637 ns | 1.531 ns |  8.66 |    0.04 |      - |     - |     - |         - |
|                  StructLinq |   100 | 214.35 ns | 1.455 ns | 1.215 ns |  3.75 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 163.21 ns | 0.407 ns | 0.340 ns |  2.86 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 191.54 ns | 0.503 ns | 0.470 ns |  3.35 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 157.91 ns | 0.398 ns | 0.311 ns |  2.76 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 216.00 ns | 0.537 ns | 0.476 ns |  3.78 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  86.56 ns | 0.171 ns | 0.160 ns |  1.52 |    0.01 |      - |     - |     - |         - |
