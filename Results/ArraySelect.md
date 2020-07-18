## ArraySelect

### Source
[ArraySelect.cs](../LinqBenchmarks/ArraySelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  58.82 ns | 0.220 ns | 0.206 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  43.01 ns | 0.106 ns | 0.099 ns |  0.73 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 625.25 ns | 4.185 ns | 3.495 ns | 10.63 |    0.08 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 242.65 ns | 1.700 ns | 1.420 ns |  4.12 |    0.03 | 0.2027 |     - |     - |     424 B |
|           StructLinq |   100 | 268.84 ns | 0.644 ns | 0.602 ns |  4.57 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 156.58 ns | 0.326 ns | 0.305 ns |  2.66 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 276.70 ns | 1.046 ns | 0.978 ns |  4.70 |    0.02 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 448.42 ns | 0.973 ns | 0.759 ns |  7.63 |    0.02 |      - |     - |     - |         - |
