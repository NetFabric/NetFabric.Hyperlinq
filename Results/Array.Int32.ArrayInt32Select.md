## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|              ForLoop |      .NET 4.8 |      .NET 4.8 |   100 |  43.69 ns | 0.166 ns | 0.147 ns |  1.00 |    0.00 |      - |     - |     - |         - |      37 B |              0 |                       0 |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |   100 |  43.68 ns | 0.256 ns | 0.214 ns |  1.00 |    0.01 |      - |     - |     - |         - |      37 B |              0 |                       0 |
|                 Linq |      .NET 4.8 |      .NET 4.8 |   100 | 659.75 ns | 2.635 ns | 2.465 ns | 15.09 |    0.08 | 0.0267 |     - |     - |      56 B |     900 B |              1 |                       0 |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |   100 | 245.96 ns | 1.843 ns | 1.539 ns |  5.63 |    0.03 | 0.2027 |     - |     - |     425 B |     518 B |              1 |                       1 |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |   100 | 257.90 ns | 1.948 ns | 1.822 ns |  5.90 |    0.04 |      - |     - |     - |         - |     608 B |              0 |                       0 |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |   100 | 166.55 ns | 0.760 ns | 0.711 ns |  3.81 |    0.02 |      - |     - |     - |         - |     581 B |              0 |                       0 |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |   100 | 297.67 ns | 1.478 ns | 1.235 ns |  6.81 |    0.05 |      - |     - |     - |         - |     789 B |              0 |                       0 |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |   100 | 346.53 ns | 1.128 ns | 0.942 ns |  7.93 |    0.03 |      - |     - |     - |         - |     646 B |              0 |                       0 |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |  44.62 ns | 0.223 ns | 0.197 ns |  1.02 |    0.00 |      - |     - |     - |         - |      37 B |              0 |                       0 |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |   100 |  44.57 ns | 0.109 ns | 0.097 ns |  1.02 |    0.00 |      - |     - |     - |         - |      37 B |              0 |                       0 |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |   100 | 658.49 ns | 3.515 ns | 3.116 ns | 15.07 |    0.09 | 0.0229 |     - |     - |      48 B |    1073 B |              1 |                       1 |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |   100 | 245.23 ns | 1.660 ns | 1.472 ns |  5.61 |    0.04 | 0.2027 |     - |     - |     424 B |     470 B |              1 |                       1 |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |   100 | 261.84 ns | 0.992 ns | 0.828 ns |  5.99 |    0.03 |      - |     - |     - |         - |     524 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |   100 | 168.47 ns | 0.565 ns | 0.501 ns |  3.86 |    0.02 |      - |     - |     - |         - |     522 B |              0 |                       0 |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |   100 | 310.55 ns | 0.949 ns | 0.841 ns |  7.11 |    0.03 |      - |     - |     - |         - |     466 B |              0 |                       0 |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |   100 | 262.06 ns | 1.069 ns | 1.000 ns |  6.00 |    0.03 |      - |     - |     - |         - |     445 B |              0 |                       0 |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  44.73 ns | 0.244 ns | 0.204 ns |  1.02 |    0.01 |      - |     - |     - |         - |      37 B |              0 |                       0 |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |   100 |  57.55 ns | 0.344 ns | 0.322 ns |  1.32 |    0.01 |      - |     - |     - |         - |      37 B |              0 |                       0 |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |   100 | 660.50 ns | 2.025 ns | 1.795 ns | 15.12 |    0.08 | 0.0229 |     - |     - |      48 B |    1057 B |              1 |                       1 |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |   100 | 274.97 ns | 1.763 ns | 1.650 ns |  6.29 |    0.05 | 0.2027 |     - |     - |     424 B |     478 B |              1 |                       1 |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |   100 | 274.12 ns | 1.003 ns | 0.938 ns |  6.27 |    0.03 |      - |     - |     - |         - |     492 B |              0 |                       0 |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |   100 | 159.63 ns | 0.677 ns | 0.600 ns |  3.65 |    0.02 |      - |     - |     - |         - |     495 B |              0 |                       0 |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |   100 | 299.32 ns | 3.207 ns | 3.000 ns |  6.85 |    0.08 |      - |     - |     - |         - |     452 B |              0 |                       0 |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |   100 | 275.47 ns | 2.838 ns | 2.654 ns |  6.30 |    0.06 |      - |     - |     - |         - |     428 B |              0 |                       0 |
