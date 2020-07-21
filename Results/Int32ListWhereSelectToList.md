## Int32ListWhereSelectToList

### Source
[Int32ListWhereSelectToList.cs](../LinqBenchmarks/Int32/List/Int32ListWhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 235.8 ns | 1.66 ns | 1.38 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 | 380.6 ns | 2.44 ns | 2.28 ns |  1.61 |    0.01 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 | 565.8 ns | 6.42 ns | 5.36 ns |  2.40 |    0.02 | 0.3824 |     - |     - |     800 B |
|           LinqFaster |   100 | 465.8 ns | 3.53 ns | 3.13 ns |  1.97 |    0.02 | 0.4320 |     - |     - |     904 B |
|           StructLinq |   100 | 624.5 ns | 3.40 ns | 3.18 ns |  2.65 |    0.02 | 0.3328 |     - |     - |     696 B |
| StructLinq_IFunction |   100 | 312.8 ns | 2.45 ns | 2.05 ns |  1.33 |    0.01 | 0.3328 |     - |     - |     696 B |
|            Hyperlinq |   100 | 691.4 ns | 5.09 ns | 4.76 ns |  2.93 |    0.03 | 0.1564 |     - |     - |     328 B |
