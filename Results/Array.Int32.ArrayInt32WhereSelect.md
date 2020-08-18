## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              ForLoop |   100 |  80.40 ns | 0.149 ns | 0.125 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  80.34 ns | 0.139 ns | 0.116 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 591.87 ns | 1.863 ns | 1.743 ns |  7.36 |    0.02 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 418.37 ns | 2.660 ns | 2.488 ns |  5.20 |    0.03 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 558.41 ns | 0.627 ns | 0.523 ns |  6.95 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 527.78 ns | 0.264 ns | 0.206 ns |  6.56 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 196.07 ns | 0.497 ns | 0.465 ns |  2.44 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 548.78 ns | 0.989 ns | 0.925 ns |  6.83 |    0.01 |      - |     - |     - |         - |
