## WhereCountBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|                         Method |           Job |       Runtime |           Categories | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------- |-------------- |--------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array | .NET Core 3.1 | .NET Core 3.1 |                Array |   100 | 590.1 ns |  2.23 ns |  1.86 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_Count | .NET Core 3.1 | .NET Core 3.1 |                Array |   100 | 344.2 ns |  1.52 ns |  1.42 ns |  0.58 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Count_IFunction | .NET Core 3.1 | .NET Core 3.1 |                Array |   100 | 199.1 ns |  0.75 ns |  0.71 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array | .NET Core 3.1 | .NET Core 3.1 |                Array |   100 | 179.7 ns |  1.10 ns |  0.92 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|                 Hyperlinq_Span | .NET Core 3.1 | .NET Core 3.1 |                Array |   100 | 231.5 ns |  1.94 ns |  1.82 ns |  0.39 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_Memory | .NET Core 3.1 | .NET Core 3.1 |                Array |   100 | 205.8 ns |  0.71 ns |  0.63 ns |  0.35 |    0.00 |      - |     - |     - |         - |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|          Linq_Enumerable_Value | .NET Core 3.1 | .NET Core 3.1 |     Enumerable_Value |   100 | 860.4 ns |  3.79 ns |  2.96 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value | .NET Core 3.1 | .NET Core 3.1 |     Enumerable_Value |   100 | 219.1 ns |  1.81 ns |  1.61 ns |  0.25 |    0.00 |      - |     - |     - |         - |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|          Linq_Collection_Value | .NET Core 3.1 | .NET Core 3.1 |     Collection_Value |   100 | 843.2 ns |  5.54 ns |  5.18 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Collection_Value | .NET Core 3.1 | .NET Core 3.1 |     Collection_Value |   100 | 220.0 ns |  1.28 ns |  1.19 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|                Linq_List_Value | .NET Core 3.1 | .NET Core 3.1 |           List_Value |   100 | 843.8 ns |  2.16 ns |  2.02 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|           Hyperlinq_List_Value | .NET Core 3.1 | .NET Core 3.1 |           List_Value |   100 | 410.9 ns |  1.45 ns |  1.29 ns |  0.49 |    0.00 |      - |     - |     - |         - |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|      Linq_Enumerable_Reference | .NET Core 3.1 | .NET Core 3.1 | Enumerable_Reference |   100 | 620.4 ns |  2.24 ns |  2.10 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | .NET Core 3.1 | .NET Core 3.1 | Enumerable_Reference |   100 | 587.9 ns |  2.55 ns |  1.99 ns |  0.95 |    0.00 | 0.0191 |     - |     - |      40 B |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|      Linq_Collection_Reference | .NET Core 3.1 | .NET Core 3.1 | Collection_Reference |   100 | 562.9 ns |  4.09 ns |  3.83 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
| Hyperlinq_Collection_Reference | .NET Core 3.1 | .NET Core 3.1 | Collection_Reference |   100 | 646.5 ns | 12.51 ns | 15.37 ns |  1.15 |    0.03 | 0.0114 |     - |     - |      24 B |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|            Linq_List_Reference | .NET Core 3.1 | .NET Core 3.1 |       List_Reference |   100 | 601.4 ns |  3.06 ns |  2.86 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_List_Reference | .NET Core 3.1 | .NET Core 3.1 |       List_Reference |   100 | 444.5 ns |  8.81 ns | 10.82 ns |  0.74 |    0.02 |      - |     - |     - |         - |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|                     Linq_Array | .NET Core 5.0 | .NET Core 5.0 |                Array |   100 | 640.4 ns | 11.43 ns | 20.01 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_Count | .NET Core 5.0 | .NET Core 5.0 |                Array |   100 | 365.1 ns |  3.07 ns |  2.88 ns |  0.56 |    0.02 |      - |     - |     - |         - |
|     StructLinq_Count_IFunction | .NET Core 5.0 | .NET Core 5.0 |                Array |   100 | 164.9 ns |  0.60 ns |  0.54 ns |  0.25 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq_Array | .NET Core 5.0 | .NET Core 5.0 |                Array |   100 | 198.6 ns |  0.48 ns |  0.40 ns |  0.30 |    0.01 |      - |     - |     - |         - |
|                 Hyperlinq_Span | .NET Core 5.0 | .NET Core 5.0 |                Array |   100 | 224.5 ns |  1.11 ns |  0.93 ns |  0.34 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_Memory | .NET Core 5.0 | .NET Core 5.0 |                Array |   100 | 197.3 ns |  1.27 ns |  1.12 ns |  0.30 |    0.01 |      - |     - |     - |         - |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|          Linq_Enumerable_Value | .NET Core 5.0 | .NET Core 5.0 |     Enumerable_Value |   100 | 870.0 ns |  6.26 ns |  5.55 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value | .NET Core 5.0 | .NET Core 5.0 |     Enumerable_Value |   100 | 241.3 ns |  1.90 ns |  1.78 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|          Linq_Collection_Value | .NET Core 5.0 | .NET Core 5.0 |     Collection_Value |   100 | 832.7 ns |  2.68 ns |  2.24 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Collection_Value | .NET Core 5.0 | .NET Core 5.0 |     Collection_Value |   100 | 210.7 ns |  1.91 ns |  1.69 ns |  0.25 |    0.00 |      - |     - |     - |         - |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|                Linq_List_Value | .NET Core 5.0 | .NET Core 5.0 |           List_Value |   100 | 813.7 ns |  2.84 ns |  2.66 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|           Hyperlinq_List_Value | .NET Core 5.0 | .NET Core 5.0 |           List_Value |   100 | 430.9 ns |  2.35 ns |  1.96 ns |  0.53 |    0.00 |      - |     - |     - |         - |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|      Linq_Enumerable_Reference | .NET Core 5.0 | .NET Core 5.0 | Enumerable_Reference |   100 | 663.5 ns |  2.78 ns |  2.60 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | .NET Core 5.0 | .NET Core 5.0 | Enumerable_Reference |   100 | 611.1 ns |  4.20 ns |  3.72 ns |  0.92 |    0.01 | 0.0191 |     - |     - |      40 B |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|      Linq_Collection_Reference | .NET Core 5.0 | .NET Core 5.0 | Collection_Reference |   100 | 596.9 ns |  2.17 ns |  1.92 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
| Hyperlinq_Collection_Reference | .NET Core 5.0 | .NET Core 5.0 | Collection_Reference |   100 | 577.3 ns |  3.01 ns |  2.81 ns |  0.97 |    0.01 | 0.0114 |     - |     - |      24 B |
|                                |               |               |                      |       |          |          |          |       |         |        |       |       |           |
|            Linq_List_Reference | .NET Core 5.0 | .NET Core 5.0 |       List_Reference |   100 | 546.6 ns |  3.88 ns |  3.44 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_List_Reference | .NET Core 5.0 | .NET Core 5.0 |       List_Reference |   100 | 432.7 ns |  1.15 ns |  1.07 ns |  0.79 |    0.01 |      - |     - |     - |         - |
