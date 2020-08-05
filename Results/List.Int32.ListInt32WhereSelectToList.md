## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 231.7 ns |  4.48 ns |  3.50 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|          ForeachLoop |   100 | 383.0 ns |  3.32 ns |  2.94 ns |  1.65 |    0.03 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 | 564.8 ns |  5.39 ns |  5.05 ns |  2.45 |    0.04 | 0.3824 |     - |     - |     800 B |
|           LinqFaster |   100 | 517.7 ns |  5.81 ns |  5.43 ns |  2.23 |    0.02 | 0.4320 |     - |     - |     904 B |
|           StructLinq |   100 | 663.8 ns |  7.45 ns |  6.97 ns |  2.87 |    0.06 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 | 352.2 ns |  5.31 ns |  4.71 ns |  1.52 |    0.03 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 | 660.7 ns | 10.71 ns | 10.02 ns |  2.86 |    0.06 | 0.1564 |     - |     - |     328 B |
