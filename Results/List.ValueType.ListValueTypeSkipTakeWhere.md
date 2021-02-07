## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   474.0 ns |   0.81 ns |   0.67 ns |   474.0 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,323.8 ns |  19.32 ns |  17.12 ns | 5,321.9 ns | 11.23 |    0.04 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,545.9 ns |  10.59 ns |   8.84 ns | 1,548.5 ns |  3.26 |    0.02 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,370.2 ns |  28.91 ns |  27.04 ns | 2,379.0 ns |  5.01 |    0.06 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 9,469.4 ns | 187.76 ns | 484.68 ns | 9,649.6 ns | 18.35 |    0.61 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   641.3 ns |   1.10 ns |   0.97 ns |   641.6 ns |  1.35 |    0.00 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   523.0 ns |   1.51 ns |   1.41 ns |   522.7 ns |  1.10 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   515.9 ns |   1.37 ns |   1.22 ns |   516.3 ns |  1.09 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   469.0 ns |   0.88 ns |   0.82 ns |   468.8 ns |  0.99 |    0.00 |      - |     - |     - |         - |
