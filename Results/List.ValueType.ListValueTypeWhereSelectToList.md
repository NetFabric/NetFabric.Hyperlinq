## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   923.2 ns |  7.10 ns |  6.64 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 | 1,127.6 ns |  8.57 ns |  7.59 ns |  1.22 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,351.3 ns | 17.55 ns | 14.66 ns |  1.46 |    0.02 | 2.5768 |     - |     - |   5.27 KB |
|           LinqFaster |   100 | 1,470.0 ns | 17.80 ns | 15.78 ns |  1.59 |    0.02 | 3.4237 |     - |     - |      7 KB |
|               LinqAF |   100 | 2,274.9 ns | 24.75 ns | 19.32 ns |  2.47 |    0.02 | 2.4414 |     - |     - |   4.99 KB |
|           StructLinq |   100 | 1,276.1 ns |  9.58 ns |  8.96 ns |  1.38 |    0.01 | 1.0281 |     - |     - |    2.1 KB |
| StructLinq_IFunction |   100 |   870.6 ns |  6.53 ns |  6.11 ns |  0.94 |    0.01 | 0.9823 |     - |     - |   2.01 KB |
|            Hyperlinq |   100 | 1,297.1 ns | 13.38 ns | 12.52 ns |  1.41 |    0.01 | 1.0166 |     - |     - |   2.08 KB |
