## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    76.85 ns |  0.722 ns |  0.564 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    92.79 ns |  0.771 ns |  0.721 ns |  1.21 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 |   661.57 ns |  4.774 ns |  4.232 ns |  8.61 |    0.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   304.07 ns |  2.477 ns |  2.317 ns |  3.96 |    0.04 |      - |     - |     - |         - |
|               LinqAF |   100 | 1,185.87 ns | 12.955 ns | 12.118 ns | 15.46 |    0.23 |      - |     - |     - |         - |
|           StructLinq |   100 |   416.58 ns |  2.746 ns |  2.568 ns |  5.43 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   191.28 ns |  1.162 ns |  0.971 ns |  2.49 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   199.76 ns |  1.264 ns |  1.121 ns |  2.60 |    0.03 |      - |     - |     - |         - |
