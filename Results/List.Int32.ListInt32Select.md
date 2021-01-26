## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|              ForLoop |   100 |   113.7 ns |  0.50 ns |  0.44 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   339.9 ns |  2.95 ns |  2.47 ns |  2.99 |    0.03 |      - |     - |     - |         - |
|                 Linq |   100 | 1,088.2 ns | 17.52 ns | 15.53 ns |  9.57 |    0.15 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 |   568.2 ns | 11.26 ns | 12.04 ns |  4.99 |    0.12 | 0.2174 |     - |     - |     456 B |
|               LinqAF |   100 | 1,015.3 ns | 11.87 ns | 11.11 ns |  8.93 |    0.10 |      - |     - |     - |         - |
|           StructLinq |   100 |   320.2 ns |  5.11 ns |  4.78 ns |  2.82 |    0.05 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   179.2 ns |  0.46 ns |  0.43 ns |  1.58 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 |   277.7 ns |  3.85 ns |  3.60 ns |  2.44 |    0.03 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 |   354.9 ns |  6.73 ns |  6.61 ns |  3.12 |    0.07 |      - |     - |     - |         - |
