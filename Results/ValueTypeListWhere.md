## ValueTypeListWhere

### Source
[ValueTypeListWhere.cs](../LinqBenchmarks/ValueType/Array/ValueTypeListWhere.cs)

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
|              ForLoop |   100 | 107.2 ns | 1.01 ns | 0.90 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 211.6 ns | 1.17 ns | 1.04 ns |  1.97 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 624.7 ns | 3.31 ns | 2.94 ns |  5.83 |    0.06 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 409.4 ns | 2.34 ns | 1.95 ns |  3.82 |    0.03 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 305.3 ns | 1.42 ns | 1.26 ns |  2.85 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 167.9 ns | 1.17 ns | 1.04 ns |  1.57 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 339.4 ns | 1.16 ns | 1.03 ns |  3.17 |    0.03 |      - |     - |     - |         - |
