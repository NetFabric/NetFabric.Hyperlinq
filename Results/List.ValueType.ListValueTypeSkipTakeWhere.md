## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   490.0 ns |   1.83 ns |   1.62 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,663.4 ns |  18.34 ns |  15.31 ns |  9.51 |    0.04 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,536.8 ns |   5.62 ns |   4.70 ns |  3.14 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,296.8 ns |  37.24 ns |  31.09 ns |  4.69 |    0.06 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 8,507.4 ns | 126.00 ns | 111.69 ns | 17.36 |    0.22 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   648.9 ns |   1.51 ns |   1.41 ns |  1.32 |    0.00 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   516.2 ns |   0.85 ns |   0.71 ns |  1.05 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   516.6 ns |   1.24 ns |   1.16 ns |  1.05 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   471.9 ns |   1.99 ns |   1.86 ns |  0.96 |    0.00 |      - |     - |     - |         - |
