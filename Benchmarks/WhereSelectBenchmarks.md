## WhereSelectBenchmarks

### Source
[WhereSelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectBenchmarks.cs)

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
|                          Method |           Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------- |--------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                      Linq_Array |                Array |   100 |   661.4 ns |  5.30 ns |  4.70 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                StructLinq_Array |                Array |   100 |   536.6 ns |  4.78 ns |  4.47 ns |  0.81 |      - |     - |     - |         - |
|                 Hyperlinq_Array |                Array |   100 |   565.9 ns |  3.98 ns |  3.52 ns |  0.86 |      - |     - |     - |         - |
|                  Hyperlinq_Span |                Array |   100 |   540.8 ns |  5.23 ns |  4.89 ns |  0.82 |      - |     - |     - |         - |
|                Hyperlinq_Memory |                Array |   100 |   584.0 ns |  1.71 ns |  1.43 ns |  0.88 |      - |     - |     - |         - |
|                                 |                      |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,520.4 ns |  8.24 ns |  7.30 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Enumerable_Value |     Enumerable_Value |   100 | 1,468.1 ns |  8.57 ns |  7.60 ns |  0.97 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   671.4 ns |  4.07 ns |  3.61 ns |  0.44 |      - |     - |     - |         - |
|                                 |                      |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Value |     Collection_Value |   100 | 1,551.2 ns |  7.80 ns |  6.51 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Collection_Value |     Collection_Value |   100 | 1,430.9 ns |  8.06 ns |  7.54 ns |  0.92 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Value |     Collection_Value |   100 |   756.5 ns |  6.17 ns |  5.77 ns |  0.49 |      - |     - |     - |         - |
|                                 |                      |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Value |           List_Value |   100 | 1,567.9 ns | 12.75 ns | 11.93 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|           StructLinq_List_Value |           List_Value |   100 | 1,480.8 ns |  9.30 ns |  8.24 ns |  0.94 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Value |           List_Value |   100 | 1,052.2 ns |  6.60 ns |  6.18 ns |  0.67 |      - |     - |     - |         - |
|                                 |                      |       |            |          |          |       |        |       |       |           |
|       Linq_Enumerable_Reference | Enumerable_Reference |   100 | 1,245.4 ns |  8.29 ns |  7.75 ns |  1.00 | 0.0725 |     - |     - |     152 B |
| StructLinq_Enumerable_Reference | Enumerable_Reference |   100 | 1,166.4 ns |  6.94 ns |  6.15 ns |  0.94 | 0.0153 |     - |     - |      32 B |
|  Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 1,183.1 ns |  9.07 ns |  8.48 ns |  0.95 | 0.0153 |     - |     - |      32 B |
|                                 |                      |       |            |          |          |       |        |       |       |           |
|       Linq_Collection_Reference | Collection_Reference |   100 | 1,246.2 ns |  6.66 ns |  6.23 ns |  1.00 | 0.0725 |     - |     - |     152 B |
| StructLinq_Collection_Reference | Collection_Reference |   100 | 1,174.2 ns |  7.61 ns |  6.75 ns |  0.94 | 0.0153 |     - |     - |      32 B |
|  Hyperlinq_Collection_Reference | Collection_Reference |   100 | 1,219.4 ns |  5.41 ns |  5.06 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|                                 |                      |       |            |          |          |       |        |       |       |           |
|             Linq_List_Reference |       List_Reference |   100 | 1,277.3 ns |  5.25 ns |  4.91 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|       StructLinq_List_Reference |       List_Reference |   100 | 1,160.6 ns |  7.29 ns |  6.46 ns |  0.91 | 0.0153 |     - |     - |      32 B |
|        Hyperlinq_List_Reference |       List_Reference |   100 | 1,050.4 ns |  4.02 ns |  3.35 ns |  0.82 |      - |     - |     - |         - |
