## WhereBenchmarks

### Source
[WhereBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereBenchmarks.cs)

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
|                          Method |           Categories | Count |       Mean |    Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------- |--------------------- |------ |-----------:|---------:|--------:|------:|-------:|------:|------:|----------:|
|                      Linq_Array |                Array |   100 |   508.7 ns |  3.68 ns | 3.26 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                StructLinq_Array |                Array |   100 |   460.1 ns |  6.11 ns | 5.71 ns |  0.90 |      - |     - |     - |         - |
|                 Hyperlinq_Array |                Array |   100 |   358.8 ns |  2.50 ns | 2.22 ns |  0.71 |      - |     - |     - |         - |
|                  Hyperlinq_Span |                Array |   100 |   409.5 ns |  3.00 ns | 2.66 ns |  0.80 |      - |     - |     - |         - |
|                Hyperlinq_Memory |                Array |   100 |   339.2 ns |  2.97 ns | 2.77 ns |  0.67 |      - |     - |     - |         - |
|                                 |                      |       |            |          |         |       |        |       |       |           |
|           Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,452.5 ns | 10.03 ns | 9.39 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Value |     Enumerable_Value |   100 | 1,343.8 ns | 10.21 ns | 9.55 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   364.3 ns |  1.96 ns | 1.83 ns |  0.25 |      - |     - |     - |         - |
|                                 |                      |       |            |          |         |       |        |       |       |           |
|           Linq_Collection_Value |     Collection_Value |   100 | 1,444.5 ns | 11.20 ns | 9.93 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Value |     Collection_Value |   100 | 1,356.4 ns |  9.63 ns | 8.54 ns |  0.94 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Value |     Collection_Value |   100 |   349.7 ns |  1.58 ns | 1.23 ns |  0.24 |      - |     - |     - |         - |
|                                 |                      |       |            |          |         |       |        |       |       |           |
|                 Linq_List_Value |           List_Value |   100 | 1,449.5 ns |  9.07 ns | 8.48 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Value |           List_Value |   100 | 1,333.7 ns |  8.95 ns | 7.93 ns |  0.92 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Value |           List_Value |   100 |   812.0 ns |  3.63 ns | 3.22 ns |  0.56 |      - |     - |     - |         - |
|                                 |                      |       |            |          |         |       |        |       |       |           |
|       Linq_Enumerable_Reference | Enumerable_Reference |   100 | 1,043.3 ns |  4.19 ns | 3.92 ns |  1.00 | 0.0420 |     - |     - |      88 B |
| StructLinq_Enumerable_Reference | Enumerable_Reference |   100 |   826.2 ns |  3.28 ns | 3.07 ns |  0.79 | 0.0153 |     - |     - |      32 B |
|  Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   970.4 ns |  7.55 ns | 6.69 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|                                 |                      |       |            |          |         |       |        |       |       |           |
|       Linq_Collection_Reference | Collection_Reference |   100 | 1,026.8 ns | 10.63 ns | 9.95 ns |  1.00 | 0.0420 |     - |     - |      88 B |
| StructLinq_Collection_Reference | Collection_Reference |   100 |   848.1 ns |  5.70 ns | 4.76 ns |  0.83 | 0.0153 |     - |     - |      32 B |
|  Hyperlinq_Collection_Reference | Collection_Reference |   100 |   961.2 ns |  6.05 ns | 5.37 ns |  0.94 | 0.0153 |     - |     - |      32 B |
|                                 |                      |       |            |          |         |       |        |       |       |           |
|             Linq_List_Reference |       List_Reference |   100 | 1,043.2 ns |  5.18 ns | 4.59 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|       StructLinq_List_Reference |       List_Reference |   100 |   875.8 ns |  4.42 ns | 3.92 ns |  0.84 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference |       List_Reference |   100 |   813.4 ns |  4.69 ns | 3.92 ns |  0.78 |      - |     - |     - |         - |
