## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |  4,194.6 ns | 15.07 ns | 13.36 ns |  1.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 |  4,846.7 ns |  7.77 ns |  6.49 ns |  1.16 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 |  8,758.5 ns | 29.42 ns | 24.56 ns |  2.09 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |    920.1 ns |  1.25 ns |  1.17 ns |  0.22 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 11,421.7 ns | 18.05 ns | 16.01 ns |  2.72 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 |  6,139.1 ns |  8.61 ns |  6.72 ns |  1.46 |      - |     - |     - |         - |
| StructLinq_IFunction |          4 |   100 |  4,326.7 ns |  7.97 ns |  7.07 ns |  1.03 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |  4,447.0 ns |  3.78 ns |  3.16 ns |  1.06 |      - |     - |     - |         - |
