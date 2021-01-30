## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|                     ForLoop |   100 |  57.24 ns | 0.234 ns | 0.207 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 |  57.13 ns | 0.152 ns | 0.142 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                        Linq |   100 | 668.99 ns | 4.429 ns | 3.698 ns | 11.69 |    0.07 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |   100 | 267.29 ns | 1.353 ns | 1.266 ns |  4.67 |    0.02 | 0.2027 |     - |     - |     424 B |
|                      LinqAF |   100 | 496.32 ns | 2.849 ns | 2.525 ns |  8.67 |    0.06 |      - |     - |     - |         - |
|                  StructLinq |   100 | 212.72 ns | 0.282 ns | 0.236 ns |  3.72 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 163.15 ns | 0.333 ns | 0.312 ns |  2.85 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 216.83 ns | 1.004 ns | 0.838 ns |  3.79 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 157.25 ns | 0.288 ns | 0.256 ns |  2.75 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 195.63 ns | 2.255 ns | 2.109 ns |  3.42 |    0.04 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  87.43 ns | 0.145 ns | 0.129 ns |  1.53 |    0.01 |      - |     - |     - |         - |
