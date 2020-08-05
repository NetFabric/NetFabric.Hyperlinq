## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  75.62 ns | 0.858 ns | 0.802 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  75.77 ns | 0.631 ns | 0.590 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 539.52 ns | 3.951 ns | 3.696 ns |  7.14 |    0.09 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 385.24 ns | 2.603 ns | 2.435 ns |  5.10 |    0.08 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 450.23 ns | 3.616 ns | 3.205 ns |  5.95 |    0.06 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 182.31 ns | 0.709 ns | 0.664 ns |  2.41 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 497.35 ns | 4.410 ns | 4.125 ns |  6.58 |    0.04 |      - |     - |     - |         - |
