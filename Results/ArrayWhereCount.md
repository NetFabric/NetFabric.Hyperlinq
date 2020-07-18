## ArrayWhereCount

### Source
[ArrayWhereCount.cs](../LinqBenchmarks/ArrayWhereCount.cs)

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
|              ForLoop |   100 |  78.76 ns | 0.189 ns | 0.167 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  78.44 ns | 0.152 ns | 0.119 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 596.96 ns | 1.612 ns | 1.429 ns |  7.58 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 222.49 ns | 0.567 ns | 0.503 ns |  2.83 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 307.14 ns | 1.070 ns | 0.948 ns |  3.90 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 162.61 ns | 0.730 ns | 0.647 ns |  2.06 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 169.20 ns | 0.360 ns | 0.301 ns |  2.15 |    0.01 |      - |     - |     - |         - |
