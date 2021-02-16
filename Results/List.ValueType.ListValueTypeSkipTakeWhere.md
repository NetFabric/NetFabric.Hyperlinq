## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   492.7 ns |  2.94 ns |  2.45 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,360.4 ns | 22.10 ns | 19.59 ns | 10.88 |    0.06 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,831.8 ns |  4.50 ns |  3.99 ns |  3.72 |    0.02 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,344.5 ns | 27.31 ns | 22.81 ns |  4.76 |    0.06 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 9,348.3 ns | 69.45 ns | 64.97 ns | 19.00 |    0.13 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   652.5 ns |  2.16 ns |  1.91 ns |  1.32 |    0.01 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   519.3 ns |  1.04 ns |  0.92 ns |  1.05 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   584.3 ns |  1.85 ns |  1.55 ns |  1.19 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   511.0 ns |  1.65 ns |  1.46 ns |  1.04 |    0.01 |      - |     - |     - |         - |
