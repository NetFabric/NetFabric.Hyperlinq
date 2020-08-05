## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta22](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta22)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |-------------- |-------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 | 105.01 ns | 0.749 ns | 0.701 ns |  1.00 |    0.00 |      - |     - |     - |         - |     112 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 | 105.88 ns | 1.117 ns | 1.045 ns |  1.01 |    0.01 |      - |     - |     - |         - |     112 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 709.74 ns | 8.697 ns | 7.709 ns |  6.76 |    0.08 | 0.0153 |     - |     - |      32 B |     659 B |              0 |                       0 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 783.51 ns | 9.271 ns | 8.672 ns |  7.46 |    0.10 |      - |     - |     - |         - |     471 B |              0 |                       0 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 480.49 ns | 1.820 ns | 1.614 ns |  4.57 |    0.03 | 0.0191 |     - |     - |      40 B |     668 B |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 218.51 ns | 0.677 ns | 0.601 ns |  2.08 |    0.01 | 0.0191 |     - |     - |      40 B |     453 B |              0 |                       0 |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |   100 | 231.97 ns | 0.883 ns | 0.826 ns |  2.21 |    0.02 |      - |     - |     - |         - |     843 B |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 129.08 ns | 0.668 ns | 0.592 ns |  1.23 |    0.01 |      - |     - |     - |         - |     110 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 | 128.91 ns | 0.579 ns | 0.513 ns |  1.23 |    0.01 |      - |     - |     - |         - |     110 B |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 642.14 ns | 3.328 ns | 3.113 ns |  6.12 |    0.05 | 0.0153 |     - |     - |      32 B |     474 B |              0 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 304.78 ns | 1.447 ns | 1.354 ns |  2.90 |    0.03 |      - |     - |     - |         - |     401 B |              0 |                       0 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 450.97 ns | 2.066 ns | 1.933 ns |  4.29 |    0.03 | 0.0191 |     - |     - |      40 B |     566 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 211.88 ns | 1.171 ns | 1.038 ns |  2.02 |    0.02 | 0.0191 |     - |     - |      40 B |     362 B |              0 |                       0 |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 208.38 ns | 0.993 ns | 0.880 ns |  1.98 |    0.02 |      - |     - |     - |         - |     600 B |              0 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  93.99 ns | 0.291 ns | 0.243 ns |  0.89 |    0.01 |      - |     - |     - |         - |     108 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  91.53 ns | 0.294 ns | 0.261 ns |  0.87 |    0.01 |      - |     - |     - |         - |     108 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 606.32 ns | 2.781 ns | 2.601 ns |  5.77 |    0.05 | 0.0153 |     - |     - |      32 B |     427 B |              0 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 260.25 ns | 1.149 ns | 1.018 ns |  2.48 |    0.02 |      - |     - |     - |         - |     389 B |              0 |                       0 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 407.31 ns | 1.944 ns | 1.724 ns |  3.88 |    0.03 | 0.0191 |     - |     - |      40 B |     536 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 181.65 ns | 0.804 ns | 0.752 ns |  1.73 |    0.01 | 0.0191 |     - |     - |      40 B |     334 B |              0 |                       0 |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 200.42 ns | 1.071 ns | 0.950 ns |  1.91 |    0.02 |      - |     - |     - |         - |     584 B |              0 |                       0 |
