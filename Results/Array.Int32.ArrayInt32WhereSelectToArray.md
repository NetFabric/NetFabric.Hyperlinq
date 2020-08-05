## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|              ForLoop |   100 | 240.6 ns | 2.67 ns | 2.36 ns |  1.00 |    0.00 | 0.4168 |     - |     - |     872 B |
|          ForeachLoop |   100 | 239.5 ns | 1.65 ns | 1.55 ns |  1.00 |    0.01 | 0.4168 |     - |     - |     872 B |
|                 Linq |   100 | 556.1 ns | 3.63 ns | 3.21 ns |  2.31 |    0.03 | 0.3710 |     - |     - |     776 B |
|           LinqFaster |   100 | 372.1 ns | 1.11 ns | 0.93 ns |  1.55 |    0.02 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 599.3 ns | 1.32 ns | 1.24 ns |  2.49 |    0.02 | 0.1297 |     - |     - |     272 B |
| StructLinq_IFunction |   100 | 354.3 ns | 1.87 ns | 1.56 ns |  1.47 |    0.01 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq |   100 | 600.2 ns | 4.32 ns | 4.04 ns |  2.49 |    0.02 | 0.1068 |     - |     - |     224 B |
|       Hyperlinq_Pool |   100 | 710.0 ns | 4.65 ns | 4.35 ns |  2.95 |    0.03 | 0.0267 |     - |     - |      56 B |
