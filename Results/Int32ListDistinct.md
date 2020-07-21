## Int32ListDistinct

### Source
[Int32ListDistinct.cs](../LinqBenchmarks/Int32/List/Int32ListDistinct.cs)

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
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   826.3 ns |  2.22 ns |  1.97 ns |  1.00 |    0.00 | 0.6304 |     - |     - |    1320 B |
|          ForeachLoop |          4 |   100 |   987.2 ns |  4.03 ns |  3.57 ns |  1.19 |    0.01 | 0.6294 |     - |     - |    1320 B |
|                 Linq |          4 |   100 | 1,816.2 ns | 11.23 ns |  9.38 ns |  2.20 |    0.01 | 0.5569 |     - |     - |    1168 B |
|           LinqFaster |          4 |   100 |   148.3 ns |  1.04 ns |  0.97 ns |  0.18 |    0.00 |      - |     - |     - |         - |
|           StructLinq |          4 |   100 | 1,456.7 ns | 13.80 ns | 14.76 ns |  1.77 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |          4 |   100 | 1,184.9 ns | 11.37 ns | 10.08 ns |  1.43 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 1,139.5 ns |  8.45 ns |  7.90 ns |  1.38 |    0.01 |      - |     - |     - |         - |
