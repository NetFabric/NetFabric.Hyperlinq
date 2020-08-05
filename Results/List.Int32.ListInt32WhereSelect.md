## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|              ForLoop |   100 | 105.6 ns | 0.48 ns | 0.38 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 214.6 ns | 1.97 ns | 1.85 ns |  2.03 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 791.6 ns | 4.94 ns | 4.38 ns |  7.49 |    0.07 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 510.7 ns | 3.16 ns | 2.80 ns |  4.84 |    0.03 | 0.3090 |     - |     - |     648 B |
|           StructLinq |   100 | 428.9 ns | 1.15 ns | 0.96 ns |  4.06 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 183.8 ns | 1.36 ns | 1.27 ns |  1.75 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 445.5 ns | 1.87 ns | 1.66 ns |  4.22 |    0.03 |      - |     - |     - |         - |
