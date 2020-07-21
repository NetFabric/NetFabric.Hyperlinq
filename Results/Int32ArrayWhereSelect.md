## Int32ArrayWhereSelect

### Source
[Int32ArrayWhereSelect.cs](../LinqBenchmarks/Int32/Array/Int32ArrayWhereSelect.cs)

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
|              ForLoop |   100 |  81.07 ns | 0.424 ns | 0.354 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  76.15 ns | 0.615 ns | 0.513 ns |  0.94 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 494.25 ns | 3.311 ns | 2.935 ns |  6.10 |    0.04 | 0.0496 |     - |     - |     104 B |
|           LinqFaster |   100 | 446.20 ns | 1.905 ns | 1.689 ns |  5.51 |    0.03 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 464.79 ns | 2.217 ns | 1.966 ns |  5.73 |    0.05 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 183.46 ns | 1.473 ns | 1.378 ns |  2.26 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 488.64 ns | 4.653 ns | 4.353 ns |  6.04 |    0.05 |      - |     - |     - |         - |
