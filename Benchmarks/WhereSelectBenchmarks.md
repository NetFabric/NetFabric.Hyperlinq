## WhereSelectBenchmarks

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
|                         Method |           Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |   548.2 ns | 2.85 ns | 2.66 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                Hyperlinq_Array |                Array |   100 |   475.3 ns | 1.81 ns | 1.70 ns |  0.87 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |   514.6 ns | 4.09 ns | 3.82 ns |  0.94 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |   513.4 ns | 2.55 ns | 2.38 ns |  0.94 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,114.3 ns | 6.13 ns | 5.73 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   538.3 ns | 4.24 ns | 3.31 ns |  0.48 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 1,190.1 ns | 6.93 ns | 6.49 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |   510.5 ns | 6.86 ns | 5.73 ns |  0.43 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 1,156.8 ns | 6.60 ns | 6.17 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|           Hyperlinq_List_Value |           List_Value |   100 |   842.8 ns | 2.45 ns | 2.29 ns |  0.73 |      - |     - |     - |         - |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 1,040.3 ns | 4.48 ns | 3.97 ns |  1.00 | 0.0763 |     - |     - |     160 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   969.4 ns | 4.84 ns | 4.29 ns |  0.93 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |   997.6 ns | 5.93 ns | 5.25 ns |  1.00 | 0.0687 |     - |     - |     144 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   913.3 ns | 3.45 ns | 3.23 ns |  0.92 | 0.0114 |     - |     - |      24 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   958.6 ns | 4.60 ns | 3.84 ns |  1.00 | 0.0687 |     - |     - |     144 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   784.5 ns | 5.16 ns | 4.82 ns |  0.82 |      - |     - |     - |         - |
