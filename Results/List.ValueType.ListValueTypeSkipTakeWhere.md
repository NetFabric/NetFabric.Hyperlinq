## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   477.7 ns |  1.18 ns |  1.11 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,355.5 ns | 30.51 ns | 27.05 ns | 11.21 |    0.07 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,852.0 ns |  6.43 ns |  5.70 ns |  3.88 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,343.2 ns | 18.73 ns | 17.52 ns |  4.90 |    0.04 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 9,263.9 ns | 83.50 ns | 78.11 ns | 19.39 |    0.17 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   656.6 ns |  1.39 ns |  1.23 ns |  1.37 |    0.00 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   520.6 ns |  1.26 ns |  1.12 ns |  1.09 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   525.1 ns |  2.36 ns |  2.09 ns |  1.10 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   491.6 ns |  0.99 ns |  0.82 ns |  1.03 |    0.00 |      - |     - |     - |         - |
