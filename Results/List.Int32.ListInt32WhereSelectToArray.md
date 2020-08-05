## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|               Method | Count |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 259.8 ns |  1.80 ns |  1.68 ns | 259.4 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 478.3 ns |  4.01 ns |  3.75 ns | 478.9 ns |  1.84 |    0.02 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 608.2 ns | 11.49 ns | 30.26 ns | 594.3 ns |  2.44 |    0.14 | 0.3939 |     - |     - |     824 B |
|           LinqFaster |   100 | 501.7 ns |  6.69 ns |  5.93 ns | 500.7 ns |  1.93 |    0.03 | 0.4168 |     - |     - |     872 B |
|           StructLinq |   100 | 677.3 ns |  8.24 ns |  7.71 ns | 673.1 ns |  2.61 |    0.04 | 0.1297 |     - |     - |     272 B |
| StructLinq_IFunction |   100 | 348.5 ns |  5.72 ns |  5.35 ns | 345.5 ns |  1.34 |    0.02 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq |   100 | 606.4 ns |  4.92 ns |  4.60 ns | 605.3 ns |  2.33 |    0.02 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 689.8 ns |  6.53 ns |  6.11 ns | 687.5 ns |  2.65 |    0.03 | 0.0267 |     - |     - |      56 B |
