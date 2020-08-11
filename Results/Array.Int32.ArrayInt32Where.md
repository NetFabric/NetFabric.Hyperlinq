## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  80.72 ns | 0.083 ns | 0.078 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.65 ns | 0.091 ns | 0.085 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 456.49 ns | 1.164 ns | 1.089 ns |  5.66 |    0.02 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 348.78 ns | 0.804 ns | 0.753 ns |  4.32 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 405.87 ns | 0.548 ns | 0.457 ns |  5.03 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 359.90 ns | 0.238 ns | 0.186 ns |  4.46 |    0.00 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 175.73 ns | 0.240 ns | 0.200 ns |  2.18 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 406.92 ns | 0.166 ns | 0.139 ns |  5.04 |    0.01 |      - |     - |     - |         - |
