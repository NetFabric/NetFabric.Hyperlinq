## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop | 1000 |   100 |   517.8 ns |  1.50 ns |  1.40 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,878.2 ns | 20.88 ns | 18.51 ns | 11.35 |    0.04 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 | 1,707.5 ns |  5.18 ns |  4.59 ns |  3.30 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 2,571.8 ns | 31.67 ns | 28.07 ns |  4.97 |    0.06 | 6.3133 |     - |     - |   13224 B |
|               LinqAF | 1000 |   100 | 9,409.1 ns | 79.19 ns | 74.07 ns | 18.17 |    0.14 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   703.8 ns |  1.80 ns |  1.60 ns |  1.36 |    0.00 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |   581.0 ns |  3.95 ns |  3.70 ns |  1.12 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   706.8 ns |  1.91 ns |  1.79 ns |  1.36 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   587.1 ns |  2.30 ns |  2.04 ns |  1.13 |    0.01 |      - |     - |     - |         - |
