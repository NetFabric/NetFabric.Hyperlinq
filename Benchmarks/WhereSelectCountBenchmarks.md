## WhereSelectCountBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                         Method |           Categories | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 | 442.5 ns | 2.26 ns | 2.00 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                Hyperlinq_Array |                Array |   100 | 178.5 ns | 1.12 ns | 1.00 ns |  0.40 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 | 204.6 ns | 0.89 ns | 0.79 ns |  0.46 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 | 231.6 ns | 2.06 ns | 1.83 ns |  0.52 |      - |     - |     - |         - |
|                                |                      |       |          |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 916.4 ns | 4.29 ns | 3.80 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 243.6 ns | 1.20 ns | 1.06 ns |  0.27 |      - |     - |     - |         - |
|                                |                      |       |          |         |         |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 977.9 ns | 6.32 ns | 5.60 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 213.9 ns | 1.68 ns | 1.49 ns |  0.22 |      - |     - |     - |         - |
|                                |                      |       |          |         |         |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 936.6 ns | 6.77 ns | 6.33 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|           Hyperlinq_List_Value |           List_Value |   100 | 426.2 ns | 1.69 ns | 1.49 ns |  0.46 |      - |     - |     - |         - |
|                                |                      |       |          |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 816.9 ns | 4.74 ns | 4.20 ns |  1.00 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 668.7 ns | 3.97 ns | 3.32 ns |  0.82 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 690.3 ns | 3.31 ns | 3.09 ns |  1.00 | 0.0687 |     - |     - |     144 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 548.8 ns | 3.33 ns | 3.11 ns |  0.80 | 0.0114 |     - |     - |      24 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 753.3 ns | 4.57 ns | 4.05 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 | 415.6 ns | 1.82 ns | 1.61 ns |  0.55 |      - |     - |     - |         - |
