## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |   470.9 ns |  5.39 ns |  4.78 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 2,380.0 ns |  9.24 ns |  7.71 ns |  5.05 |    0.06 | 0.0153 |     - |     - |      32 B |
|        Linq | 1000 |   100 | 1,641.5 ns | 14.17 ns | 13.25 ns |  3.49 |    0.06 | 0.1183 |     - |     - |     248 B |
|  LinqFaster | 1000 |   100 | 1,438.6 ns | 17.15 ns | 16.04 ns |  3.06 |    0.03 | 6.7329 |     - |     - |   14096 B |
|  StructLinq | 1000 |   100 | 1,519.7 ns |  5.52 ns |  4.89 ns |  3.23 |    0.03 | 0.0763 |     - |     - |     160 B |
|   Hyperlinq | 1000 |   100 |   703.6 ns |  6.93 ns |  5.41 ns |  1.49 |    0.03 |      - |     - |     - |         - |
