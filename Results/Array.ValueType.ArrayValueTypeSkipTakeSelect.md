## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|            Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 | 1.524 μs | 0.0172 μs | 0.0161 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 3.837 μs | 0.0275 μs | 0.0257 μs |  2.52 |    0.03 | 0.0153 |     - |     - |      32 B |
|              Linq | 1000 |   100 | 2.569 μs | 0.0213 μs | 0.0199 μs |  1.69 |    0.02 | 0.1183 |     - |     - |     248 B |
|        LinqFaster | 1000 |   100 | 2.535 μs | 0.0126 μs | 0.0118 μs |  1.66 |    0.02 | 5.7678 |     - |     - |   12072 B |
|        StructLinq | 1000 |   100 | 2.835 μs | 0.0113 μs | 0.0100 μs |  1.86 |    0.02 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Foreach | 1000 |   100 | 1.891 μs | 0.0035 μs | 0.0033 μs |  1.24 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 | 1.910 μs | 0.0091 μs | 0.0080 μs |  1.25 |    0.02 |      - |     - |     - |         - |
