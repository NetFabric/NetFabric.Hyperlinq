## Range

### Source
[Range.cs](../LinqBenchmarks/Range.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  33.58 ns | 0.192 ns | 0.170 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 443.00 ns | 0.953 ns | 0.844 ns | 13.19 |    0.08 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 393.24 ns | 1.075 ns | 1.006 ns | 11.71 |    0.07 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |     0 |   100 | 134.10 ns | 0.518 ns | 0.432 ns |  3.99 |    0.03 | 0.2027 |     - |     - |     424 B |
|           StructLinq |     0 |   100 |  39.80 ns | 0.182 ns | 0.142 ns |  1.18 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 |  40.01 ns | 0.186 ns | 0.165 ns |  1.19 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |     0 |   100 | 168.47 ns | 0.384 ns | 0.340 ns |  5.02 |    0.03 |      - |     - |     - |         - |
|        Hyperlinq_For |     0 |   100 |  61.68 ns | 0.318 ns | 0.282 ns |  1.84 |    0.01 |      - |     - |     - |         - |
