## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   823.7 ns |  9.36 ns |  8.29 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 |   880.9 ns |  4.82 ns |  4.28 ns |  1.07 |    0.01 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,262.8 ns |  7.14 ns |  6.33 ns |  1.53 |    0.02 | 2.5234 |     - |     - |   5.16 KB |
|           LinqFaster |   100 | 1,196.9 ns |  7.31 ns |  6.48 ns |  1.45 |    0.01 | 3.8700 |     - |     - |   7.91 KB |
|               LinqAF |   100 | 1,931.4 ns | 18.75 ns | 15.66 ns |  2.34 |    0.02 | 2.4414 |     - |     - |   4.99 KB |
|           StructLinq |   100 | 1,306.9 ns |  6.48 ns |  5.75 ns |  1.59 |    0.02 | 1.0281 |     - |     - |    2.1 KB |
| StructLinq_IFunction |   100 |   880.2 ns | 17.12 ns | 16.01 ns |  1.07 |    0.02 | 0.9823 |     - |     - |   2.01 KB |
|            Hyperlinq |   100 | 1,295.2 ns | 12.39 ns | 11.59 ns |  1.57 |    0.03 | 1.0166 |     - |     - |   2.08 KB |
