## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  62.57 ns | 0.149 ns | 0.125 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  48.25 ns | 0.085 ns | 0.071 ns |  0.77 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 677.11 ns | 0.602 ns | 0.470 ns | 10.82 |    0.02 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 270.40 ns | 0.801 ns | 0.710 ns |  4.32 |    0.02 | 0.2027 |     - |     - |     424 B |
|               LinqAF |   100 | 564.98 ns | 0.855 ns | 0.758 ns |  9.03 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 289.70 ns | 0.533 ns | 0.416 ns |  4.63 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 174.30 ns | 0.306 ns | 0.287 ns |  2.78 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 266.70 ns | 0.210 ns | 0.164 ns |  4.26 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 325.06 ns | 1.324 ns | 1.238 ns |  5.19 |    0.03 |      - |     - |     - |         - |
