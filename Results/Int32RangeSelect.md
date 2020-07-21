## Int32RangeSelect

### Source
[Int32RangeSelect.cs](../LinqBenchmarks/Int32/Range/Int32RangeSelect.cs)

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
|              ForLoop |     0 |   100 |  40.42 ns | 0.357 ns | 0.317 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 481.10 ns | 5.344 ns | 4.737 ns | 11.90 |    0.18 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 590.69 ns | 3.515 ns | 3.288 ns | 14.61 |    0.10 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 345.77 ns | 2.577 ns | 2.152 ns |  8.55 |    0.07 | 0.4053 |     - |     - |     848 B |
|           StructLinq |     0 |   100 | 275.94 ns | 3.513 ns | 3.114 ns |  6.83 |    0.08 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 | 172.53 ns | 1.362 ns | 1.274 ns |  4.27 |    0.04 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |     0 |   100 | 326.50 ns | 3.122 ns | 2.768 ns |  8.08 |    0.08 |      - |     - |     - |         - |
|        Hyperlinq_For |     0 |   100 | 367.56 ns | 2.203 ns | 2.060 ns |  9.09 |    0.09 |      - |     - |     - |         - |
