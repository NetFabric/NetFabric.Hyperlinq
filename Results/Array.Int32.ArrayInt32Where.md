## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  81.24 ns | 0.146 ns | 0.137 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.50 ns | 0.171 ns | 0.160 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 512.35 ns | 0.556 ns | 0.434 ns |  6.31 |    0.01 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 344.85 ns | 0.751 ns | 0.628 ns |  4.24 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 419.29 ns | 1.516 ns | 1.418 ns |  5.16 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 325.80 ns | 1.120 ns | 1.048 ns |  4.01 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 176.18 ns | 0.180 ns | 0.151 ns |  2.17 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 378.16 ns | 0.840 ns | 0.744 ns |  4.65 |    0.01 |      - |     - |     - |         - |
