## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

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
|              ForLoop |   100 |  62.60 ns | 0.141 ns | 0.117 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  63.03 ns | 0.174 ns | 0.154 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 680.95 ns | 0.674 ns | 0.527 ns | 10.88 |    0.02 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 272.92 ns | 1.016 ns | 0.901 ns |  4.36 |    0.01 | 0.2027 |     - |     - |     424 B |
|               LinqAF |   100 | 570.88 ns | 0.518 ns | 0.433 ns |  9.12 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 291.08 ns | 0.322 ns | 0.285 ns |  4.65 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 174.40 ns | 0.085 ns | 0.066 ns |  2.79 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 266.90 ns | 0.308 ns | 0.257 ns |  4.26 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 299.18 ns | 1.477 ns | 1.233 ns |  4.78 |    0.03 |      - |     - |     - |         - |
