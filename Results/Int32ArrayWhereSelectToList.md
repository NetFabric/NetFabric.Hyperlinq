## Int32ArrayWhereSelectToList

### Source
[Int32ArrayWhereSelectToList.cs](../LinqBenchmarks/Int32/Array/Int32ArrayWhereSelectToList.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 214.7 ns | 1.67 ns | 1.31 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|          ForeachLoop |   100 | 213.5 ns | 1.41 ns | 1.10 ns |  0.99 |    0.01 | 0.3097 |     - |     - |     648 B |
|                 Linq |   100 | 497.0 ns | 2.89 ns | 2.41 ns |  2.32 |    0.02 | 0.3595 |     - |     - |     752 B |
|           LinqFaster |   100 | 369.6 ns | 3.24 ns | 3.03 ns |  1.72 |    0.02 | 0.4320 |     - |     - |     904 B |
|           StructLinq |   100 | 623.0 ns | 3.12 ns | 2.92 ns |  2.90 |    0.02 | 0.3328 |     - |     - |     696 B |
| StructLinq_IFunction |   100 | 310.2 ns | 2.88 ns | 2.69 ns |  1.44 |    0.02 | 0.3328 |     - |     - |     696 B |
|            Hyperlinq |   100 | 678.0 ns | 4.23 ns | 3.75 ns |  3.15 |    0.02 | 0.1564 |     - |     - |     328 B |
