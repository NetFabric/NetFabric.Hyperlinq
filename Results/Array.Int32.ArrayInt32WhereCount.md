## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  80.43 ns | 0.196 ns | 0.183 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.43 ns | 0.167 ns | 0.156 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 628.64 ns | 1.847 ns | 1.542 ns |  7.82 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 246.35 ns | 0.610 ns | 0.570 ns |  3.06 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 287.33 ns | 0.560 ns | 0.497 ns |  3.57 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 373.26 ns | 0.987 ns | 0.875 ns |  4.64 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 176.85 ns | 0.265 ns | 0.247 ns |  2.20 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 184.30 ns | 0.393 ns | 0.349 ns |  2.29 |    0.00 |      - |     - |     - |         - |
