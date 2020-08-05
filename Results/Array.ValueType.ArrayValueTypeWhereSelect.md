## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   856.7 ns |  2.69 ns |  2.52 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   844.5 ns |  2.44 ns |  2.04 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,354.3 ns | 12.64 ns | 12.42 ns |  1.58 |    0.02 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,424.5 ns | 12.53 ns | 11.72 ns |  1.66 |    0.02 | 2.8896 |     - |     - |    6048 B |
|           StructLinq |   100 | 1,210.3 ns |  5.23 ns |  4.64 ns |  1.41 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   908.9 ns |  6.93 ns |  6.48 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,210.4 ns | 10.43 ns |  9.76 ns |  1.41 |    0.01 |      - |     - |     - |         - |
