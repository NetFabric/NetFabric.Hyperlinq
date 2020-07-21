## Int32ArrayWhereCount

### Source
[Int32ArrayWhereCount.cs](../LinqBenchmarks/Int32/Array/Int32ArrayWhereCount.cs)

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
|              ForLoop |   100 |  79.53 ns | 0.350 ns | 0.292 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  65.89 ns | 0.584 ns | 0.547 ns |  0.83 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 627.13 ns | 3.186 ns | 2.824 ns |  7.88 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 244.53 ns | 1.742 ns | 1.629 ns |  3.07 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 328.38 ns | 2.225 ns | 1.858 ns |  4.13 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 164.52 ns | 0.971 ns | 0.811 ns |  2.07 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 175.42 ns | 2.804 ns | 2.486 ns |  2.20 |    0.03 |      - |     - |     - |         - |
