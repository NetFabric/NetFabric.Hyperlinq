## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              ForLoop |   100 |  81.21 ns | 0.175 ns | 0.146 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  81.08 ns | 0.088 ns | 0.078 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 616.54 ns | 2.221 ns | 1.969 ns |  7.59 |    0.03 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 418.72 ns | 1.099 ns | 0.918 ns |  5.16 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 596.67 ns | 1.047 ns | 0.874 ns |  7.35 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 527.81 ns | 0.613 ns | 0.543 ns |  6.50 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 196.87 ns | 0.341 ns | 0.302 ns |  2.42 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 542.34 ns | 0.951 ns | 0.890 ns |  6.68 |    0.01 |      - |     - |     - |         - |
