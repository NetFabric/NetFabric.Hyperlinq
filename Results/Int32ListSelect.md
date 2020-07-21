## Int32ListSelect

### Source
[Int32ListSelect.cs](../LinqBenchmarks/Int32/List/Int32ListSelect.cs)

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
|              ForLoop |   100 | 106.1 ns | 0.75 ns | 0.70 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 200.5 ns | 1.78 ns | 1.58 ns |  1.89 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 787.9 ns | 5.24 ns | 4.64 ns |  7.42 |    0.06 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 325.9 ns | 2.32 ns | 2.06 ns |  3.07 |    0.03 | 0.2179 |     - |     - |     456 B |
|           StructLinq |   100 | 251.0 ns | 2.28 ns | 2.02 ns |  2.36 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 162.8 ns | 0.89 ns | 0.84 ns |  1.53 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 257.1 ns | 2.42 ns | 2.26 ns |  2.42 |    0.03 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 483.4 ns | 3.05 ns | 2.54 ns |  4.55 |    0.04 |      - |     - |     - |         - |
