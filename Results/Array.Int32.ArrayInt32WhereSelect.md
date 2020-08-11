## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

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
|              ForLoop |   100 |  81.46 ns | 0.098 ns | 0.092 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.63 ns | 0.134 ns | 0.119 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 585.87 ns | 0.759 ns | 0.593 ns |  7.19 |    0.01 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 466.97 ns | 0.971 ns | 0.811 ns |  5.73 |    0.01 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 557.86 ns | 1.767 ns | 1.653 ns |  6.85 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 512.65 ns | 0.641 ns | 0.568 ns |  6.29 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 194.27 ns | 0.179 ns | 0.139 ns |  2.38 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 518.68 ns | 0.395 ns | 0.330 ns |  6.37 |    0.01 |      - |     - |     - |         - |
