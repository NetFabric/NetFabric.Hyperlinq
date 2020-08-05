## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|               Method | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  57.28 ns | 0.637 ns | 0.596 ns |  57.14 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  43.78 ns | 0.495 ns | 0.463 ns |  43.98 ns |  0.76 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 649.68 ns | 4.615 ns | 3.854 ns | 648.74 ns | 11.35 |    0.14 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 255.15 ns | 5.087 ns | 9.922 ns | 250.82 ns |  4.40 |    0.17 | 0.2027 |     - |     - |     424 B |
|           StructLinq |   100 | 271.10 ns | 2.368 ns | 2.215 ns | 270.22 ns |  4.73 |    0.07 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 161.33 ns | 3.230 ns | 4.200 ns | 159.56 ns |  2.82 |    0.07 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 252.98 ns | 2.937 ns | 2.748 ns | 253.90 ns |  4.42 |    0.07 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 246.90 ns | 1.860 ns | 1.648 ns | 246.50 ns |  4.31 |    0.05 |      - |     - |     - |         - |
