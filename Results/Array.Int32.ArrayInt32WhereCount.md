## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  85.06 ns | 0.090 ns | 0.080 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  84.96 ns | 0.091 ns | 0.085 ns |  1.00 |      - |     - |     - |         - |
|                 Linq |   100 | 641.16 ns | 0.610 ns | 0.476 ns |  7.54 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 284.90 ns | 1.230 ns | 1.151 ns |  3.35 |      - |     - |     - |         - |
|               LinqAF |   100 | 229.90 ns | 0.444 ns | 0.415 ns |  2.70 |      - |     - |     - |         - |
|           StructLinq |   100 | 404.11 ns | 0.738 ns | 0.654 ns |  4.75 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 179.61 ns | 0.361 ns | 0.320 ns |  2.11 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 183.05 ns | 0.146 ns | 0.122 ns |  2.15 |      - |     - |     - |         - |
