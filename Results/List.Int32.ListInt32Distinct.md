## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |  3.691 μs | 0.0157 μs | 0.0131 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 |  4.389 μs | 0.0136 μs | 0.0120 μs |  1.19 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 10.923 μs | 0.1976 μs | 0.3077 μs |  2.98 |    0.08 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |  1.028 μs | 0.0197 μs | 0.0295 μs |  0.27 |    0.01 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 12.119 μs | 0.1444 μs | 0.1350 μs |  3.28 |    0.04 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 |  5.736 μs | 0.1118 μs | 0.1567 μs |  1.55 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 |  5.337 μs | 0.1060 μs | 0.1885 μs |  1.45 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |  6.689 μs | 0.1328 μs | 0.3079 μs |  1.78 |    0.06 |      - |     - |     - |         - |
