## WhereSingleBenchmarks

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
|                     Linq_Array |                Array |   100 | 590.2 ns | 5.33 ns | 4.73 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_Array |                Array |   100 | 209.9 ns | 1.64 ns | 1.46 ns |  0.36 | 0.0305 |     - |     - |      64 B |
|                 Hyperlinq_Span |                Array |   100 | 212.6 ns | 1.68 ns | 1.40 ns |  0.36 | 0.0305 |     - |     - |      64 B |
|               Hyperlinq_Memory |                Array |   100 | 210.1 ns | 0.82 ns | 0.72 ns |  0.36 | 0.0305 |     - |     - |      64 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 747.5 ns | 5.76 ns | 5.39 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 251.4 ns | 1.42 ns | 1.33 ns |  0.34 | 0.0305 |     - |     - |      64 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 825.2 ns | 4.61 ns | 4.08 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 200.0 ns | 1.20 ns | 1.00 ns |  0.24 | 0.0305 |     - |     - |      64 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 820.2 ns | 5.30 ns | 4.96 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           Hyperlinq_List_Value |           List_Value |   100 | 453.6 ns | 1.25 ns | 1.17 ns |  0.55 | 0.0305 |     - |     - |      64 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 696.1 ns | 4.44 ns | 3.94 ns |  1.00 | 0.0496 |     - |     - |     104 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 677.3 ns | 2.70 ns | 2.40 ns |  0.97 | 0.0496 |     - |     - |     104 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 563.2 ns | 4.41 ns | 4.12 ns |  1.00 | 0.0420 |     - |     - |      88 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 608.7 ns | 4.53 ns | 4.01 ns |  1.08 | 0.0420 |     - |     - |      88 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 601.6 ns | 4.93 ns | 4.61 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 | 373.2 ns | 1.93 ns | 1.71 ns |  0.62 | 0.0305 |     - |     - |      64 B |
