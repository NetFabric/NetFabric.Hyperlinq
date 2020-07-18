## RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/RangeSelect.cs)

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
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  38.33 ns | 0.181 ns | 0.169 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 445.46 ns | 0.926 ns | 0.866 ns | 11.62 |    0.06 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 543.37 ns | 1.102 ns | 0.977 ns | 14.18 |    0.06 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 357.98 ns | 1.133 ns | 1.060 ns |  9.34 |    0.05 | 0.4053 |     - |     - |     848 B |
|           StructLinq |     0 |   100 | 270.67 ns | 0.876 ns | 0.819 ns |  7.06 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 | 168.90 ns | 0.290 ns | 0.243 ns |  4.41 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |     0 |   100 | 345.96 ns | 1.477 ns | 1.309 ns |  9.03 |    0.05 |      - |     - |     - |         - |
|        Hyperlinq_For |     0 |   100 | 336.49 ns | 1.622 ns | 1.438 ns |  8.78 |    0.05 |      - |     - |     - |         - |
