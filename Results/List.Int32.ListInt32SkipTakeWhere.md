## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |         Mean |      Error |       StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |     75.10 ns |   0.320 ns |     0.283 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 |  7,845.44 ns | 156.849 ns |   334.257 ns | 103.83 |    5.31 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 |  2,883.78 ns |  59.392 ns |   175.118 ns |  38.28 |    1.94 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |    958.18 ns |   6.104 ns |     5.411 ns |  12.76 |    0.10 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 14,957.38 ns | 349.809 ns | 1,025.930 ns | 193.71 |   15.74 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |    504.32 ns |  10.058 ns |    21.433 ns |   6.69 |    0.35 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |    188.61 ns |   1.391 ns |     1.233 ns |   2.51 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |    526.67 ns |  12.268 ns |    36.174 ns |   6.90 |    0.45 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |    181.30 ns |   0.758 ns |     0.633 ns |   2.41 |    0.02 |      - |     - |     - |         - |
