## Int32ArrayWhere

### Source
[Int32ArrayWhere.cs](../LinqBenchmarks/Int32/Array/Int32ArrayWhere.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  68.10 ns | 0.852 ns | 0.756 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.52 ns | 0.618 ns | 0.516 ns |  0.96 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 446.92 ns | 5.679 ns | 5.034 ns |  6.56 |    0.08 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 300.81 ns | 2.902 ns | 2.715 ns |  4.42 |    0.06 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 312.76 ns | 3.200 ns | 2.837 ns |  4.59 |    0.06 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 163.43 ns | 1.606 ns | 1.502 ns |  2.40 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 360.64 ns | 6.971 ns | 5.443 ns |  5.30 |    0.09 |      - |     - |     - |         - |
