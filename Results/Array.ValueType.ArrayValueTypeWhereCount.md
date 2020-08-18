## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|              ForLoop |   100 |  97.38 ns | 0.209 ns | 0.175 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  97.32 ns | 0.075 ns | 0.066 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 819.27 ns | 2.173 ns | 1.927 ns |  8.41 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 298.08 ns | 2.535 ns | 2.371 ns |  3.06 |    0.03 |      - |     - |     - |         - |
|               LinqAF |   100 | 667.94 ns | 0.866 ns | 0.723 ns |  6.86 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 565.50 ns | 1.302 ns | 1.154 ns |  5.81 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 223.14 ns | 0.883 ns | 0.737 ns |  2.29 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 240.15 ns | 0.719 ns | 0.638 ns |  2.47 |    0.01 |      - |     - |     - |         - |
