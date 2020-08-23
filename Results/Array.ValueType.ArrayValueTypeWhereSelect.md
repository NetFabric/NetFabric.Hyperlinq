## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   785.4 ns |  5.16 ns |  4.82 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   841.4 ns |  3.59 ns |  3.18 ns |  1.07 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,349.4 ns |  6.78 ns |  6.34 ns |  1.72 |    0.01 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,412.9 ns | 10.64 ns |  9.95 ns |  1.80 |    0.01 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,731.6 ns | 12.45 ns | 11.04 ns |  2.20 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,153.5 ns |  9.34 ns |  8.74 ns |  1.47 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   894.4 ns |  1.61 ns |  1.43 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,203.4 ns |  4.62 ns |  4.10 ns |  1.53 |    0.01 |      - |     - |     - |         - |
