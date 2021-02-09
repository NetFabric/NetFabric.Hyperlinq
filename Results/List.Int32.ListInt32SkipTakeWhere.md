## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|              ForLoop | 1000 |   100 |     75.11 ns |   0.274 ns |     0.229 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 |  8,183.36 ns | 163.298 ns |   322.335 ns | 111.59 |    3.90 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 |  2,971.85 ns |  63.298 ns |   185.642 ns |  40.51 |    2.70 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |    962.61 ns |   8.984 ns |     7.964 ns |  12.82 |    0.10 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 16,536.32 ns | 399.983 ns | 1,179.359 ns | 219.41 |   13.41 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |    511.05 ns |  10.197 ns |    21.731 ns |   6.77 |    0.33 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |    185.28 ns |   0.519 ns |     0.460 ns |   2.47 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |    560.20 ns |  16.053 ns |    47.333 ns |   7.34 |    0.74 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |    183.20 ns |   0.566 ns |     0.502 ns |   2.44 |    0.01 |      - |     - |     - |         - |
