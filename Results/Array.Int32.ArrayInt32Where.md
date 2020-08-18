## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|              ForLoop |   100 |  80.47 ns | 0.305 ns | 0.285 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.43 ns | 0.189 ns | 0.167 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 516.16 ns | 1.128 ns | 1.000 ns |  6.41 |    0.03 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 325.09 ns | 1.761 ns | 1.561 ns |  4.04 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 419.15 ns | 1.067 ns | 0.998 ns |  5.21 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 374.88 ns | 0.832 ns | 0.778 ns |  4.66 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 177.24 ns | 0.349 ns | 0.326 ns |  2.20 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 407.45 ns | 0.881 ns | 0.824 ns |  5.06 |    0.02 |      - |     - |     - |         - |
