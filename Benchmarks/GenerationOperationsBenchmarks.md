## GenerationOperationsBenchmarks

### Source
[GenerationOperationsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/GenerationOperationsBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
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
|           Method | Categories | Count |       Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |----------- |------ |-----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|       Linq_Range |      Range |   100 | 457.549 ns | 3.0944 ns | 2.7431 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|       StructLinq |      Range |   100 |  41.095 ns | 0.3385 ns | 0.3166 ns |  0.09 |      - |     - |     - |         - |
|  Hyperlinq_Range |      Range |   100 |  46.453 ns | 0.1033 ns | 0.0916 ns |  0.10 |      - |     - |     - |         - |
|                  |            |       |            |           |           |       |        |       |       |           |
|      Linq_Repeat |     Repeat |   100 | 407.395 ns | 2.6346 ns | 2.2000 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|        Ix_Repeat |     Repeat |   100 | 475.628 ns | 3.4044 ns | 3.1845 ns |  1.17 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Repeat |     Repeat |   100 | 150.969 ns | 1.0694 ns | 1.0003 ns |  0.37 |      - |     - |     - |         - |
|                  |            |       |            |           |           |       |        |       |       |           |
|        Ix_Return |     Return |   100 |  23.929 ns | 0.1654 ns | 0.1381 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Return |     Return |   100 |   5.639 ns | 0.0671 ns | 0.0627 ns |  0.24 |      - |     - |     - |         - |
|                  |            |       |            |           |           |       |        |       |       |           |
|        Ix_Create |     Create |   100 | 620.301 ns | 3.0596 ns | 2.7123 ns |  1.00 | 0.0534 |     - |     - |     112 B |
| Hyperlinq_Create |     Create |   100 | 165.858 ns | 0.8936 ns | 0.8359 ns |  0.27 | 0.0305 |     - |     - |      64 B |
