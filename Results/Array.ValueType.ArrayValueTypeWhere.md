## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|              ForLoop |   100 |   405.1 ns |  3.79 ns |  3.36 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   458.8 ns |  3.47 ns |  3.07 ns |  1.13 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 |   877.7 ns |  3.92 ns |  3.66 ns |  2.17 |    0.02 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 |   970.9 ns |  8.24 ns |  7.71 ns |  2.40 |    0.02 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,068.2 ns | 20.31 ns | 21.73 ns |  2.64 |    0.06 |      - |     - |     - |         - |
|           StructLinq |   100 |   650.9 ns |  3.06 ns |  2.71 ns |  1.61 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   494.8 ns |  1.61 ns |  1.51 ns |  1.22 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   666.6 ns |  4.14 ns |  3.87 ns |  1.65 |    0.01 |      - |     - |     - |         - |
