## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   105.0 ns |  0.30 ns |  0.27 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 3,110.4 ns | 16.37 ns | 15.32 ns | 29.62 |    0.17 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,536.9 ns |  3.81 ns |  3.56 ns | 14.64 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   432.0 ns |  1.65 ns |  1.38 ns |  4.12 |    0.01 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,991.8 ns |  4.15 ns |  3.68 ns | 28.50 |    0.08 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,299.8 ns |  2.15 ns |  1.79 ns | 12.38 |    0.04 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,111.7 ns |  1.71 ns |  1.52 ns | 10.59 |    0.03 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq | 1000 |   100 |   400.6 ns |  0.50 ns |  0.47 ns |  3.82 |    0.01 |      - |     - |     - |         - |
