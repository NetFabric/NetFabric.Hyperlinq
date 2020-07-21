## Int32ListWhere

### Source
[Int32ListWhere.cs](../LinqBenchmarks/Int32/List/Int32ListWhere.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 107.5 ns | 1.11 ns | 0.98 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 207.4 ns | 1.29 ns | 1.07 ns |  1.93 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 619.0 ns | 3.05 ns | 2.85 ns |  5.76 |    0.05 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 410.4 ns | 2.72 ns | 2.41 ns |  3.82 |    0.04 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 301.2 ns | 1.06 ns | 0.94 ns |  2.80 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 169.5 ns | 0.36 ns | 0.32 ns |  1.58 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 352.7 ns | 2.63 ns | 2.46 ns |  3.29 |    0.03 |      - |     - |     - |         - |
