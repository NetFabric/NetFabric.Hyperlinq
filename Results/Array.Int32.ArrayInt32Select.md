## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  48.05 ns | 0.057 ns | 0.051 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  48.34 ns | 0.094 ns | 0.083 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 674.58 ns | 0.586 ns | 0.458 ns | 14.04 |    0.02 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 266.64 ns | 0.764 ns | 0.638 ns |  5.55 |    0.02 | 0.2027 |     - |     - |     424 B |
|               LinqAF |   100 | 540.46 ns | 0.502 ns | 0.419 ns | 11.25 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 271.78 ns | 0.199 ns | 0.166 ns |  5.66 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 172.19 ns | 0.116 ns | 0.102 ns |  3.58 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 376.18 ns | 0.674 ns | 0.631 ns |  7.83 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 325.08 ns | 1.671 ns | 1.641 ns |  6.76 |    0.03 |      - |     - |     - |         - |
