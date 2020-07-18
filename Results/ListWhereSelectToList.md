## ListWhereSelectToList

### Source
[ListWhereSelectToList.cs](../LinqBenchmarks/ListWhereSelectToList.cs)

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
|               Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 235.3 ns |  1.03 ns |  0.96 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 | 388.6 ns |  2.74 ns |  2.29 ns |  1.65 |    0.01 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 | 540.9 ns |  7.62 ns |  6.37 ns |  2.30 |    0.02 | 0.3824 |     - |     - |     800 B |
|           LinqFaster |   100 | 532.7 ns | 10.54 ns | 18.46 ns |  2.31 |    0.08 | 0.4320 |     - |     - |     904 B |
|           StructLinq |   100 | 619.7 ns |  3.32 ns |  2.94 ns |  2.63 |    0.02 | 0.3328 |     - |     - |     696 B |
| StructLinq_IFunction |   100 | 301.8 ns |  1.08 ns |  1.01 ns |  1.28 |    0.01 | 0.3328 |     - |     - |     696 B |
|            Hyperlinq |   100 | 640.4 ns |  2.20 ns |  2.06 ns |  2.72 |    0.01 | 0.1564 |     - |     - |     328 B |
