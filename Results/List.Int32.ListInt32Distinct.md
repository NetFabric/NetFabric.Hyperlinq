## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3,315.9 ns | 26.37 ns | 24.66 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 4,130.7 ns | 34.17 ns | 30.29 ns |  1.25 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7,556.1 ns | 59.28 ns | 55.45 ns |  2.28 |    0.02 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |   814.8 ns |  6.88 ns |  6.10 ns |  0.25 |    0.00 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 9,680.4 ns | 60.27 ns | 53.43 ns |  2.92 |    0.03 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 4,067.5 ns | 38.04 ns | 29.70 ns |  1.23 |    0.01 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |          4 |   100 | 4,225.0 ns | 43.07 ns | 38.18 ns |  1.27 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 4,263.8 ns | 27.85 ns | 24.69 ns |  1.29 |    0.01 |      - |     - |     - |         - |
