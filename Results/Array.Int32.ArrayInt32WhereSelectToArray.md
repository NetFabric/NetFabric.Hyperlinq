## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

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
|              ForLoop |   100 | 239.0 ns | 3.42 ns | 3.20 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 237.8 ns | 2.33 ns | 2.18 ns |  1.00 |    0.02 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 597.9 ns | 4.08 ns | 3.82 ns |  2.50 |    0.03 | 0.3710 |     - |     - |     776 B |
|           LinqFaster |   100 | 333.1 ns | 1.38 ns | 1.29 ns |  1.39 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 829.1 ns | 6.13 ns | 5.73 ns |  3.47 |    0.05 | 0.4015 |     - |     - |     840 B |
|           StructLinq |   100 | 642.9 ns | 5.31 ns | 4.43 ns |  2.69 |    0.04 | 0.1526 |     - |     - |     320 B |
| StructLinq_IFunction |   100 | 363.8 ns | 2.93 ns | 2.60 ns |  1.52 |    0.02 | 0.1068 |     - |     - |     224 B |
|            Hyperlinq |   100 | 588.2 ns | 2.82 ns | 2.64 ns |  2.46 |    0.04 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 663.7 ns | 5.17 ns | 4.58 ns |  2.78 |    0.03 | 0.0267 |     - |     - |      56 B |
