## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 275.5 ns | 2.26 ns | 2.11 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 | 264.5 ns | 0.98 ns | 0.87 ns |  0.96 |    0.01 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 | 578.6 ns | 2.53 ns | 2.37 ns |  2.10 |    0.02 | 0.3595 |     - |     - |     752 B |
|           LinqFaster |   100 | 451.5 ns | 1.76 ns | 1.56 ns |  1.64 |    0.02 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 723.0 ns | 7.21 ns | 6.39 ns |  2.63 |    0.03 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 | 616.2 ns | 3.22 ns | 2.86 ns |  2.24 |    0.02 | 0.1678 |     - |     - |     352 B |
| StructLinq_IFunction |   100 | 430.9 ns | 2.44 ns | 2.17 ns |  1.56 |    0.01 | 0.1221 |     - |     - |     256 B |
|            Hyperlinq |   100 | 737.4 ns | 2.71 ns | 2.26 ns |  2.68 |    0.03 | 0.1564 |     - |     - |     328 B |
|  Hyperlinq_IFunction |   100 | 414.0 ns | 2.04 ns | 1.81 ns |  1.50 |    0.01 | 0.1564 |     - |     - |     328 B |
