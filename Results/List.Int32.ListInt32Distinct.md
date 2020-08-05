## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3,174.3 ns | 15.14 ns | 13.43 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3,678.3 ns | 34.37 ns | 30.47 ns |  1.16 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7,011.1 ns | 82.72 ns | 69.08 ns |  2.21 |    0.02 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |   624.4 ns |  2.95 ns |  2.61 ns |  0.20 |    0.00 |      - |     - |     - |         - |
|           StructLinq |          4 |   100 | 4,921.0 ns | 35.00 ns | 32.74 ns |  1.55 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |          4 |   100 | 3,706.3 ns | 34.42 ns | 28.74 ns |  1.17 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 3,800.8 ns | 41.63 ns | 38.94 ns |  1.20 |    0.01 |      - |     - |     - |         - |
