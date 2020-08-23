## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 252.2 ns | 2.56 ns | 2.39 ns |  1.00 |    0.00 | 0.3095 |     - |     - |     648 B |
|          ForeachLoop |   100 | 248.9 ns | 1.67 ns | 1.39 ns |  0.99 |    0.01 | 0.3095 |     - |     - |     648 B |
|                 Linq |   100 | 512.0 ns | 4.64 ns | 4.34 ns |  2.03 |    0.03 | 0.3595 |     - |     - |     752 B |
|           LinqFaster |   100 | 406.6 ns | 1.38 ns | 1.15 ns |  1.61 |    0.02 | 0.4320 |     - |     - |     904 B |
|               LinqAF |   100 | 833.5 ns | 5.25 ns | 4.91 ns |  3.31 |    0.03 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 | 678.2 ns | 5.01 ns | 4.68 ns |  2.69 |    0.03 | 0.1678 |     - |     - |     352 B |
| StructLinq_IFunction |   100 | 397.6 ns | 2.59 ns | 2.29 ns |  1.58 |    0.02 | 0.1221 |     - |     - |     256 B |
|            Hyperlinq |   100 | 701.1 ns | 5.35 ns | 4.47 ns |  2.78 |    0.03 | 0.1564 |     - |     - |     328 B |
