## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  75.36 ns | 0.995 ns | 0.931 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  75.42 ns | 0.724 ns | 0.677 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 453.82 ns | 6.986 ns | 5.833 ns |  6.02 |    0.12 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 292.19 ns | 2.796 ns | 2.616 ns |  3.88 |    0.05 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 361.29 ns | 1.659 ns | 1.471 ns |  4.79 |    0.07 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 163.97 ns | 0.614 ns | 0.575 ns |  2.18 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 331.73 ns | 2.566 ns | 2.003 ns |  4.40 |    0.06 |      - |     - |     - |         - |
