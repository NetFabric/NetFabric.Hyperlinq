## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   115.4 ns |  0.71 ns |  0.63 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   378.3 ns |  5.15 ns |  4.56 ns |  3.28 |    0.04 |      - |     - |     - |         - |
|                 Linq |   100 | 1,167.2 ns | 22.69 ns | 21.22 ns | 10.14 |    0.17 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 |   809.0 ns | 10.84 ns |  9.61 ns |  7.01 |    0.09 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 1,112.5 ns | 17.97 ns | 15.01 ns |  9.65 |    0.16 |      - |     - |     - |         - |
|           StructLinq |   100 |   537.6 ns | 10.74 ns | 16.07 ns |  4.58 |    0.15 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   202.1 ns |  0.71 ns |  0.66 ns |  1.75 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   500.7 ns |  9.35 ns |  9.19 ns |  4.34 |    0.09 |      - |     - |     - |         - |
