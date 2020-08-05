## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   876.9 ns |  5.62 ns |  4.69 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 |   897.6 ns |  7.58 ns |  7.09 ns |  1.02 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,300.4 ns | 10.62 ns |  9.41 ns |  1.48 |    0.01 | 2.5234 |     - |     - |   5.16 KB |
|           LinqFaster |   100 | 1,180.1 ns | 10.67 ns |  9.46 ns |  1.35 |    0.01 | 3.8700 |     - |     - |   7.91 KB |
|           StructLinq |   100 | 1,355.0 ns | 12.53 ns | 11.10 ns |  1.55 |    0.02 | 1.0052 |     - |     - |   2.05 KB |
| StructLinq_IFunction |   100 |   884.6 ns |  4.10 ns |  3.63 ns |  1.01 |    0.01 | 1.0052 |     - |     - |   2.05 KB |
|            Hyperlinq |   100 | 1,301.7 ns | 13.93 ns | 12.35 ns |  1.48 |    0.02 | 1.0166 |     - |     - |   2.08 KB |
