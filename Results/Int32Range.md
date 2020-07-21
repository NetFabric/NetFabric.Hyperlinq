## Int32Range

### Source
[Int32Range.cs](../LinqBenchmarks/Int32/Range/Int32Range.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  34.27 ns | 0.327 ns | 0.290 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 484.50 ns | 3.961 ns | 3.511 ns | 14.14 |    0.18 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 426.09 ns | 3.397 ns | 2.837 ns | 12.44 |    0.17 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |     0 |   100 | 126.68 ns | 0.627 ns | 0.587 ns |  3.69 |    0.03 | 0.2027 |     - |     - |     424 B |
|           StructLinq |     0 |   100 |  40.56 ns | 0.227 ns | 0.190 ns |  1.18 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 |  41.11 ns | 0.409 ns | 0.362 ns |  1.20 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |     0 |   100 | 171.67 ns | 1.014 ns | 0.949 ns |  5.01 |    0.05 |      - |     - |     - |         - |
|        Hyperlinq_For |     0 |   100 |  63.26 ns | 0.501 ns | 0.444 ns |  1.85 |    0.02 |      - |     - |     - |         - |
