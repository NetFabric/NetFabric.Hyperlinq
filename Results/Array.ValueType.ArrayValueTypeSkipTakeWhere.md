## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|              ForLoop | 1000 |   100 |   443.1 ns |  1.78 ns |  1.58 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,984.4 ns | 20.59 ns | 18.26 ns |  6.74 |    0.05 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,770.1 ns |  8.61 ns |  7.64 ns |  3.99 |    0.02 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,618.7 ns | 11.20 ns | 10.47 ns |  3.65 |    0.03 | 6.7329 |     - |     - |   14096 B |
|               LinqAF | 1000 |   100 | 5,722.9 ns | 21.80 ns | 19.33 ns | 12.92 |    0.06 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 2,102.8 ns | 11.57 ns | 10.82 ns |  4.75 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 2,046.3 ns | 12.05 ns | 10.06 ns |  4.62 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   690.3 ns |  1.77 ns |  1.65 ns |  1.56 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   595.8 ns |  2.53 ns |  2.37 ns |  1.34 |    0.01 |      - |     - |     - |         - |
