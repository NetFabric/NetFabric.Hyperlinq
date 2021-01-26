## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   313.9 ns | 2.26 ns | 1.88 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 |   502.2 ns | 2.19 ns | 1.94 ns |  1.60 |    0.01 | 0.3090 |     - |     - |     648 B |
|                 Linq |   100 |   633.7 ns | 2.32 ns | 2.06 ns |  2.02 |    0.01 | 0.3824 |     - |     - |     800 B |
|           LinqFaster |   100 |   604.8 ns | 2.80 ns | 2.48 ns |  1.93 |    0.01 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 1,143.8 ns | 5.04 ns | 4.46 ns |  3.64 |    0.03 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 |   626.3 ns | 5.57 ns | 4.65 ns |  2.00 |    0.02 | 0.1717 |     - |     - |     360 B |
| StructLinq_IFunction |   100 |   403.4 ns | 1.85 ns | 1.64 ns |  1.28 |    0.01 | 0.1221 |     - |     - |     256 B |
|            Hyperlinq |   100 |   683.3 ns | 3.96 ns | 3.51 ns |  2.18 |    0.02 | 0.1564 |     - |     - |     328 B |
