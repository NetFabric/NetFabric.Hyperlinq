## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|                     ForLoop |   100 |  43.83 ns | 0.096 ns | 0.090 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  44.01 ns | 0.544 ns | 0.509 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 661.96 ns | 1.416 ns | 1.325 ns | 15.10 |    0.04 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 272.02 ns | 3.012 ns | 2.352 ns |  6.21 |    0.06 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 504.07 ns | 2.541 ns | 2.252 ns | 11.50 |    0.05 |      - |     - |     - |         - |
|                  StructLinq |   100 | 230.51 ns | 0.678 ns | 0.601 ns |  5.26 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 163.36 ns | 0.406 ns | 0.339 ns |  3.73 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 191.73 ns | 0.583 ns | 0.487 ns |  4.38 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 157.62 ns | 0.507 ns | 0.450 ns |  3.60 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 216.10 ns | 0.572 ns | 0.478 ns |  4.93 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  86.55 ns | 0.239 ns | 0.212 ns |  1.97 |    0.01 |      - |     - |     - |         - |
