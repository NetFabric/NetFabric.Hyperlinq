## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    97.14 ns |  0.884 ns |  0.827 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,642.43 ns | 17.703 ns | 16.559 ns | 27.20 |    0.26 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,342.84 ns | 13.573 ns | 12.697 ns | 13.82 |    0.22 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   375.21 ns |  6.383 ns |  5.971 ns |  3.86 |    0.07 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,552.56 ns | 23.825 ns | 22.286 ns | 26.28 |    0.35 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   437.14 ns |  3.385 ns |  3.166 ns |  4.50 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   167.33 ns |  1.405 ns |  1.314 ns |  1.72 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   352.88 ns |  4.556 ns |  3.805 ns |  3.63 |    0.05 |      - |     - |     - |         - |
