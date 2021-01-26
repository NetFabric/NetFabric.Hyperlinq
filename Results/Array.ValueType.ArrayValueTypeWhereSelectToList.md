## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   904.1 ns |  8.00 ns |  7.10 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 |   981.2 ns |  5.42 ns |  5.07 ns |  1.09 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,413.4 ns |  9.56 ns |  8.94 ns |  1.56 |    0.01 | 2.5234 |     - |     - |   5.16 KB |
|           LinqFaster |   100 | 1,313.6 ns | 10.57 ns |  9.37 ns |  1.45 |    0.02 | 3.8700 |     - |     - |   7.91 KB |
|               LinqAF |   100 | 2,307.5 ns | 20.96 ns | 17.50 ns |  2.55 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|           StructLinq |   100 | 1,321.3 ns |  8.39 ns |  7.44 ns |  1.46 |    0.01 | 1.0281 |     - |     - |    2.1 KB |
| StructLinq_IFunction |   100 |   970.5 ns |  6.60 ns |  5.85 ns |  1.07 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|            Hyperlinq |   100 | 1,544.0 ns | 11.71 ns | 10.38 ns |  1.71 |    0.02 | 1.0166 |     - |     - |   2.08 KB |
|  Hyperlinq_IFunction |   100 | 1,164.0 ns |  5.09 ns |  4.76 ns |  1.29 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
