## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|            Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop |     0 |   100 |  34.30 ns | 0.275 ns | 0.214 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop |     0 |   100 | 505.98 ns | 4.064 ns | 3.802 ns | 14.74 |    0.08 | 0.0267 |     - |     - |      56 B |
|              Linq |     0 |   100 | 427.34 ns | 2.119 ns | 1.878 ns | 12.48 |    0.07 | 0.0191 |     - |     - |      40 B |
|        LinqFaster |     0 |   100 | 124.48 ns | 1.068 ns | 0.999 ns |  3.63 |    0.04 | 0.2027 |     - |     - |     424 B |
|        StructLinq |     0 |   100 |  40.31 ns | 0.134 ns | 0.125 ns |  1.18 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach |     0 |   100 | 169.74 ns | 0.616 ns | 0.576 ns |  4.95 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For |     0 |   100 |  62.38 ns | 0.264 ns | 0.234 ns |  1.82 |    0.01 |      - |     - |     - |         - |
