## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 457.0 ns | 4.49 ns | 4.20 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 454.9 ns | 0.99 ns | 0.88 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 878.6 ns | 5.41 ns | 5.06 ns |  1.92 |    0.02 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 945.8 ns | 8.90 ns | 8.33 ns |  2.07 |    0.03 | 2.8896 |     - |     - |    6048 B |
|           StructLinq |   100 | 730.3 ns | 2.50 ns | 2.34 ns |  1.60 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 488.0 ns | 2.35 ns | 2.20 ns |  1.07 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 672.6 ns | 6.36 ns | 5.95 ns |  1.47 |    0.01 |      - |     - |     - |         - |
