## Int32ListWhereSelect

### Source
[Int32ListWhereSelect.cs](../LinqBenchmarks/Int32/List/Int32ListWhereSelect.cs)

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
|              ForLoop |   100 | 124.0 ns | 0.76 ns | 0.71 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 208.8 ns | 1.42 ns | 1.26 ns |  1.68 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 772.6 ns | 4.39 ns | 3.89 ns |  6.23 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 479.8 ns | 2.66 ns | 2.49 ns |  3.87 |    0.03 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 | 448.0 ns | 1.61 ns | 1.43 ns |  3.61 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 184.4 ns | 1.96 ns | 1.83 ns |  1.49 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 477.7 ns | 6.55 ns | 5.81 ns |  3.85 |    0.05 |      - |     - |     - |         - |
