## ArrayWhereSelectToList

### Source
[ArrayWhereSelectToList.cs](../LinqBenchmarks/ArrayWhereSelectToList.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 208.6 ns | 0.90 ns | 0.80 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|          ForeachLoop |   100 | 212.5 ns | 1.64 ns | 1.45 ns |  1.02 |    0.01 | 0.3097 |     - |     - |     648 B |
|                 Linq |   100 | 486.4 ns | 2.49 ns | 2.08 ns |  2.33 |    0.01 | 0.3595 |     - |     - |     752 B |
|           LinqFaster |   100 | 359.6 ns | 1.68 ns | 1.49 ns |  1.72 |    0.01 | 0.4320 |     - |     - |     904 B |
|           StructLinq |   100 | 644.2 ns | 0.87 ns | 0.72 ns |  3.09 |    0.01 | 0.3328 |     - |     - |     696 B |
| StructLinq_IFunction |   100 | 303.6 ns | 2.16 ns | 1.92 ns |  1.46 |    0.01 | 0.3328 |     - |     - |     696 B |
|            Hyperlinq |   100 | 643.2 ns | 2.86 ns | 2.39 ns |  3.08 |    0.02 | 0.1564 |     - |     - |     328 B |
