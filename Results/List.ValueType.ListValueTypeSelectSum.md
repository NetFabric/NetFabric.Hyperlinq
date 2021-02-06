## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
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
|               Method | Count |        Mean |     Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   186.30 ns |  0.485 ns |   0.405 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   536.42 ns | 14.432 ns |  41.639 ns |  2.75 |    0.14 |      - |     - |     - |         - |
|                 Linq |   100 | 1,718.49 ns | 38.832 ns | 113.275 ns |  9.32 |    0.51 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 |   552.89 ns | 13.072 ns |  38.544 ns |  2.98 |    0.20 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,523.27 ns | 30.453 ns |  81.286 ns |  8.09 |    0.45 |      - |     - |     - |         - |
|           StructLinq |   100 |   396.82 ns |  7.958 ns |  21.786 ns |  2.12 |    0.15 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |    83.72 ns |  0.301 ns |   0.281 ns |  0.45 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   371.22 ns |  7.366 ns |  21.017 ns |  1.99 |    0.13 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |    79.24 ns |  0.391 ns |   0.326 ns |  0.43 |    0.00 |      - |     - |     - |         - |
