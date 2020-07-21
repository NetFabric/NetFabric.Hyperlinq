## Int32ArraySelect

### Source
[Int32ArraySelect.cs](../LinqBenchmarks/Int32/Array/Int32ArraySelect.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  59.92 ns |  0.840 ns |  0.744 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  44.96 ns |  0.552 ns |  0.516 ns |  0.75 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 662.76 ns | 12.434 ns | 11.023 ns | 11.06 |    0.22 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 275.11 ns |  2.335 ns |  2.185 ns |  4.59 |    0.08 | 0.2027 |     - |     - |     424 B |
|           StructLinq |   100 | 272.89 ns |  2.618 ns |  2.186 ns |  4.55 |    0.07 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 159.31 ns |  1.789 ns |  1.674 ns |  2.66 |    0.05 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 306.07 ns |  3.639 ns |  3.404 ns |  5.11 |    0.10 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 460.88 ns |  4.565 ns |  5.936 ns |  7.67 |    0.14 |      - |     - |     - |         - |
