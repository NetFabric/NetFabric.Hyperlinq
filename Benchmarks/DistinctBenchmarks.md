## DistinctBenchmarks

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
|                         Method |           Categories | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 | 2.495 μs | 0.0144 μs | 0.0135 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|                Hyperlinq_Array |                Array |   100 | 1.662 μs | 0.0110 μs | 0.0103 μs |  0.67 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 | 1.713 μs | 0.0077 μs | 0.0068 μs |  0.69 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 | 1.767 μs | 0.0068 μs | 0.0057 μs |  0.71 |      - |     - |     - |         - |
|                                |                      |       |          |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 2.791 μs | 0.0118 μs | 0.0105 μs |  1.00 | 2.0561 |     - |     - |    4304 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 1.592 μs | 0.0145 μs | 0.0136 μs |  0.57 |      - |     - |     - |         - |
|                                |                      |       |          |           |           |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 2.714 μs | 0.0261 μs | 0.0204 μs |  1.00 | 2.0561 |     - |     - |    4304 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 1.640 μs | 0.0147 μs | 0.0130 μs |  0.61 |      - |     - |     - |         - |
|                                |                      |       |          |           |           |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 2.725 μs | 0.0135 μs | 0.0113 μs |  1.00 | 2.0561 |     - |     - |    4304 B |
|           Hyperlinq_List_Value |           List_Value |   100 | 2.087 μs | 0.0124 μs | 0.0116 μs |  0.77 |      - |     - |     - |         - |
|                                |                      |       |          |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 2.600 μs | 0.0158 μs | 0.0132 μs |  1.00 | 2.0638 |     - |     - |    4320 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 2.091 μs | 0.0260 μs | 0.0230 μs |  0.81 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |          |           |           |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 2.487 μs | 0.0225 μs | 0.0199 μs |  1.00 | 2.0561 |     - |     - |    4304 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 2.065 μs | 0.0179 μs | 0.0167 μs |  0.83 | 0.0114 |     - |     - |      24 B |
|                                |                      |       |          |           |           |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 2.424 μs | 0.0260 μs | 0.0243 μs |  1.00 | 2.0561 |     - |     - |    4304 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 | 1.969 μs | 0.0149 μs | 0.0132 μs |  0.81 |      - |     - |     - |         - |
