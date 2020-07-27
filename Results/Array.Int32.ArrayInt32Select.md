## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta20](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta20)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |   100 |  58.90 ns | 0.631 ns | 0.590 ns |  1.00 |    0.00 |      - |     - |     - |         - |              0 |                       0 |
|          ForeachLoop |   100 |  43.69 ns | 0.525 ns | 0.465 ns |  0.74 |    0.01 |      - |     - |     - |         - |              0 |                       0 |
|                 Linq |   100 | 648.14 ns | 5.940 ns | 5.557 ns | 11.00 |    0.10 | 0.0229 |     - |     - |      48 B |              0 |                       1 |
|           LinqFaster |   100 | 246.77 ns | 2.605 ns | 2.437 ns |  4.19 |    0.06 | 0.2027 |     - |     - |     424 B |              1 |                       1 |
|           StructLinq |   100 | 226.35 ns | 2.078 ns | 1.842 ns |  3.84 |    0.05 |      - |     - |     - |         - |              0 |                       0 |
| StructLinq_IFunction |   100 | 157.74 ns | 1.303 ns | 1.219 ns |  2.68 |    0.03 |      - |     - |     - |         - |              0 |                       0 |
|    Hyperlinq_Foreach |   100 | 250.28 ns | 1.991 ns | 1.765 ns |  4.25 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
|        Hyperlinq_For |   100 | 244.56 ns | 1.565 ns | 1.387 ns |  4.15 |    0.04 |      - |     - |     - |         - |              0 |                       0 |
