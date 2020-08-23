## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   877.8 ns |  1.78 ns |  1.67 ns |   877.7 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,425.5 ns | 10.23 ns |  9.57 ns | 1,422.8 ns |  1.62 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,628.0 ns | 13.41 ns | 12.54 ns | 1,628.0 ns |  1.85 |    0.02 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,757.2 ns | 35.00 ns | 88.44 ns | 1,714.7 ns |  2.09 |    0.10 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,041.7 ns | 12.04 ns | 10.05 ns | 2,043.5 ns |  2.33 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,162.7 ns |  7.27 ns |  6.80 ns | 1,162.7 ns |  1.32 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   899.4 ns |  6.41 ns |  6.00 ns |   897.6 ns |  1.02 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,210.0 ns | 10.26 ns |  9.60 ns | 1,207.6 ns |  1.38 |    0.01 |      - |     - |     - |         - |
