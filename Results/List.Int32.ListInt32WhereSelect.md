## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   104.6 ns |  0.25 ns |  0.21 ns |   104.6 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   507.0 ns | 10.14 ns | 23.70 ns |   506.6 ns |  4.89 |    0.27 |      - |     - |     - |         - |
|                 Linq |   100 | 1,282.5 ns | 25.65 ns | 56.30 ns | 1,271.9 ns | 12.11 |    0.54 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 |   719.3 ns | 13.14 ns | 11.65 ns |   718.4 ns |  6.88 |    0.11 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 |   798.2 ns |  3.16 ns |  2.81 ns |   797.9 ns |  7.63 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 |   677.4 ns | 13.16 ns | 26.59 ns |   677.8 ns |  6.46 |    0.22 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   185.1 ns |  0.64 ns |  0.54 ns |   185.0 ns |  1.77 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   759.2 ns | 34.15 ns | 91.15 ns |   731.8 ns |  6.75 |    0.25 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   192.4 ns |  0.53 ns |  0.47 ns |   192.3 ns |  1.84 |    0.01 |      - |     - |     - |         - |
