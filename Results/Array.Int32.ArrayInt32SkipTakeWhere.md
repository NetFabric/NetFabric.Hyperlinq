## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   132.4 ns | 0.44 ns | 0.41 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 3,110.2 ns | 2.63 ns | 2.05 ns | 23.50 |    0.08 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,509.1 ns | 5.49 ns | 4.87 ns | 11.40 |    0.06 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   429.7 ns | 3.51 ns | 2.93 ns |  3.25 |    0.02 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 3,043.6 ns | 1.64 ns | 1.28 ns | 22.99 |    0.06 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,323.6 ns | 3.88 ns | 3.63 ns | 10.00 |    0.05 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,152.9 ns | 1.89 ns | 1.58 ns |  8.71 |    0.03 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq | 1000 |   100 |   390.5 ns | 0.62 ns | 0.55 ns |  2.95 |    0.01 |      - |     - |     - |         - |
