## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  44.76 ns | 0.235 ns | 0.208 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  45.02 ns | 0.497 ns | 0.440 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 661.74 ns | 7.268 ns | 6.442 ns | 14.78 |    0.14 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 300.49 ns | 2.045 ns | 1.913 ns |  6.72 |    0.06 | 0.2027 |     - |     - |     424 B |
|               LinqAF |   100 | 551.31 ns | 6.357 ns | 5.946 ns | 12.31 |    0.17 |      - |     - |     - |         - |
|           StructLinq |   100 | 258.84 ns | 3.953 ns | 3.504 ns |  5.78 |    0.07 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 161.52 ns | 1.412 ns | 1.251 ns |  3.61 |    0.04 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 304.89 ns | 4.283 ns | 4.006 ns |  6.81 |    0.09 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 273.67 ns | 1.178 ns | 0.984 ns |  6.11 |    0.04 |      - |     - |     - |         - |
