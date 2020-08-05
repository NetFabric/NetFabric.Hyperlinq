## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 216.2 ns | 1.52 ns | 1.35 ns |  1.00 |    0.00 | 0.3097 |     - |     - |     648 B |
|          ForeachLoop |   100 | 227.0 ns | 1.37 ns | 1.21 ns |  1.05 |    0.01 | 0.3097 |     - |     - |     648 B |
|                 Linq |   100 | 472.3 ns | 1.62 ns | 1.43 ns |  2.18 |    0.02 | 0.3595 |     - |     - |     752 B |
|           LinqFaster |   100 | 425.9 ns | 1.55 ns | 1.29 ns |  1.97 |    0.01 | 0.4320 |     - |     - |     904 B |
|           StructLinq |   100 | 607.9 ns | 3.54 ns | 3.31 ns |  2.81 |    0.02 | 0.1450 |     - |     - |     304 B |
| StructLinq_IFunction |   100 | 353.8 ns | 2.29 ns | 2.14 ns |  1.64 |    0.01 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq |   100 | 714.0 ns | 2.79 ns | 2.33 ns |  3.31 |    0.02 | 0.1564 |     - |     - |     328 B |
