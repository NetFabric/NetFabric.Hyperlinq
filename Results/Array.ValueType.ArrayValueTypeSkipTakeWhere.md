## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   418.0 ns |  2.65 ns |  2.48 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,694.5 ns | 24.78 ns | 23.18 ns |  6.45 |    0.07 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,648.6 ns | 13.55 ns | 12.67 ns |  3.94 |    0.04 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 | 1,456.6 ns | 14.08 ns | 13.17 ns |  3.48 |    0.04 | 6.7329 |     - |     - |   14096 B |
|               LinqAF | 1000 |   100 | 6,102.2 ns | 58.98 ns | 55.17 ns | 14.60 |    0.15 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 2,013.1 ns |  7.95 ns |  7.43 ns |  4.82 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,904.1 ns | 10.99 ns |  9.18 ns |  4.56 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   705.6 ns |  5.53 ns |  5.17 ns |  1.69 |    0.01 |      - |     - |     - |         - |
