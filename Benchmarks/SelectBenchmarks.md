## SelectBenchmarks

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
|                           Method |           Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------- |--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                       Linq_Array |                Array |   100 |   688.4 ns | 1.89 ns | 1.68 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                 StructLinq_Array |                Array |   100 |   249.9 ns | 1.10 ns | 0.92 ns |  0.36 |      - |     - |     - |         - |
|              Hyperlinq_Array_For |                Array |   100 |   276.9 ns | 1.86 ns | 1.65 ns |  0.40 |      - |     - |     - |         - |
|          Hyperlinq_Array_Foreach |                Array |   100 |   303.3 ns | 1.02 ns | 0.95 ns |  0.44 |      - |     - |     - |         - |
|               Hyperlinq_Span_For |                Array |   100 |   250.7 ns | 1.36 ns | 1.27 ns |  0.36 |      - |     - |     - |         - |
|           Hyperlinq_Span_Foreach |                Array |   100 |   280.5 ns | 1.88 ns | 1.76 ns |  0.41 |      - |     - |     - |         - |
|             Hyperlinq_Memory_For |                Array |   100 |   433.3 ns | 2.78 ns | 2.32 ns |  0.63 |      - |     - |     - |         - |
|         Hyperlinq_Memory_Foreach |                Array |   100 |   283.6 ns | 2.12 ns | 1.98 ns |  0.41 |      - |     - |     - |         - |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|            Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,169.1 ns | 5.97 ns | 5.59 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|      StructLinq_Enumerable_Value |     Enumerable_Value |   100 |   811.0 ns | 3.43 ns | 3.20 ns |  0.69 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   370.5 ns | 2.47 ns | 2.31 ns |  0.32 |      - |     - |     - |         - |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|            Linq_Collection_Value |     Collection_Value |   100 | 1,182.1 ns | 6.49 ns | 6.07 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|      StructLinq_Collection_Value |     Collection_Value |   100 |   757.8 ns | 2.81 ns | 2.34 ns |  0.64 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_Collection_Value |     Collection_Value |   100 |   382.8 ns | 1.46 ns | 1.36 ns |  0.32 |      - |     - |     - |         - |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|                  Linq_List_Value |           List_Value |   100 | 1,181.8 ns | 6.36 ns | 5.64 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|            StructLinq_List_Value |           List_Value |   100 |   810.9 ns | 4.42 ns | 4.14 ns |  0.69 | 0.0114 |     - |     - |      24 B |
|         Hyperlinq_List_Value_For |           List_Value |   100 |   521.1 ns | 4.55 ns | 4.03 ns |  0.44 |      - |     - |     - |         - |
|     Hyperlinq_List_Value_Foreach |           List_Value |   100 |   555.4 ns | 5.90 ns | 5.52 ns |  0.47 |      - |     - |     - |         - |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|        Linq_Enumerable_Reference | Enumerable_Reference |   100 | 1,062.3 ns | 8.50 ns | 7.53 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|  StructLinq_Enumerable_Reference | Enumerable_Reference |   100 |   685.4 ns | 3.17 ns | 2.97 ns |  0.65 | 0.0191 |     - |     - |      40 B |
|   Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   743.1 ns | 6.91 ns | 6.13 ns |  0.70 | 0.0191 |     - |     - |      40 B |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|        Linq_Collection_Reference | Collection_Reference |   100 |   954.2 ns | 5.91 ns | 5.24 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|  StructLinq_Collection_Reference | Collection_Reference |   100 |   620.8 ns | 4.02 ns | 3.76 ns |  0.65 | 0.0114 |     - |     - |      24 B |
|   Hyperlinq_Collection_Reference | Collection_Reference |   100 |   639.7 ns | 3.68 ns | 3.45 ns |  0.67 | 0.0114 |     - |     - |      24 B |
|                                  |                      |       |            |         |         |       |        |       |       |           |
|              Linq_List_Reference |       List_Reference |   100 |   968.6 ns | 3.94 ns | 3.49 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|        StructLinq_List_Reference |       List_Reference |   100 |   615.1 ns | 4.35 ns | 3.85 ns |  0.64 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_List_Reference_For |       List_Reference |   100 |   621.5 ns | 3.31 ns | 3.09 ns |  0.64 |      - |     - |     - |         - |
| Hyperlinq_List_Reference_Foreach |       List_Reference |   100 |   545.1 ns | 4.64 ns | 4.34 ns |  0.56 |      - |     - |     - |         - |
